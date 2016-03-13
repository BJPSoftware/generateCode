using System;
using System.IO;
using System.Text;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using BJP.Framework.Repository;
using BJP.Framework.Utility;
using BJP.Framework.Code;

namespace GenerateCode
{
    public partial class frmMain : Form
    {
        public string connString = string.Empty;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string userPwd = txtUserPwd.Text;
            string dbName = txtDbName.Text;
            string tableName = string.Empty;
            string tableLabel = string.Empty;

            connString = "Provider=SQLOLEDB;Data Source=(local);UID={0};pwd={1};DATABASE={2};";
            connString = string.Format(connString, userName, userPwd, dbName);

            string sql = "SELECT a.*,";
            sql += "  label = b.value,";
            sql += " PrimaryKey = KCU.COLUMN_NAME";
            sql += " FROM sys.TABLES a";
            sql += " LEFT JOIN  sys.extended_properties b on a.object_id = b.major_id and b.minor_id = 0";
            sql += " LEFT JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE KCU ON KCU.TABLE_NAME = a.name";
            sql += " INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc ON tc.TABLE_NAME = a.name AND tc.CONSTRAINT_TYPE = 'PRIMARY KEY'";
            sql += "     AND KCU.CONSTRAINT_NAME = tc.CONSTRAINT_NAME";
            sql += " WHERE a.type = 'U'";

            DbHelper dbHelper = new DbHelper(connString);
            DataTable dtTableName = dbHelper.Fill(sql);
            lvTabeleName.Clear();
            foreach (DataRow dr in dtTableName.Rows)
            {
                tableName = dr["name"].ToString();
                tableLabel = dr["label"].ToString();

                if (string.IsNullOrEmpty(tableLabel))
                    tableLabel = tableName;

                ListViewItem lvi = new ListViewItem();
                lvi.Tag = tableName;
                lvi.Text = tableLabel;

                lvTabeleName.Items.Add(lvi);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            DbHelper dbHelper = new DbHelper(connString);
            DataTable dtColumn = new DataTable();
            if (lvTabeleName.CheckedItems.Count == 0) {
                MessageBox.Show("请选择要生成代码的数据表");
                return;
            }

            string entityPackageName = txtModelPackage.Text;
            if (string.IsNullOrEmpty(entityPackageName)) {
                MessageBox.Show("实体包名不能为空");
                return;
            }
            string entityMainDir = txtModelMainDir.Text;
            if (string.IsNullOrEmpty(entityMainDir))
            {
                MessageBox.Show("实体包主目录不能为空");
                return;
            }
            //实体代码存放路径
            string[] listDir = entityPackageName.Split('.');
            StringBuilder sb = new StringBuilder();
            foreach (string s in listDir) {
                sb.Append(s);
                sb.Append("\\");
            }
            string entityFileDir = entityMainDir + sb.ToString();

            //dao代码存放路径
            string daoMainDir = txtDaoMainDir.Text;
            listDir = txtDaoPackageName.Text.ToString().Split('.');
            sb.Clear();
            foreach (string s in listDir)
            {
                sb.Append(s);
                sb.Append("\\");
            }
            string daoFileDir = daoMainDir + sb.ToString();
            
            //service代码存放路径
            string serviceMainDir = txtServiceMainDir.Text;
            listDir = txtServerPackageName.Text.ToString().Split('.');
            sb.Clear();
            foreach (string s in listDir)
            {
                sb.Append(s);
                sb.Append("\\");
            }
            string serviceFileDir = serviceMainDir + sb.ToString();

            string COLUMN_SQL = @"SELECT  
                Name=a.name,
                AutoIncrement=case   when   COLUMNPROPERTY(   a.id,a.name,'IsIdentity')=1   then   '是'else   '否'   end,
                IsPK=case   when   exists(SELECT   1   FROM   sysobjects   where   xtype='PK'   and   name   in   (
                SELECT   name   FROM   sysindexes   WHERE   indid   in(
                SELECT   indid   FROM   sysindexkeys   WHERE   id   =   a.id   AND   colid=a.colid
                )))   then   '是'   else   '否'   end,
                DataType=b.name,
                BitLenght=a.length,
                MaxLength=COLUMNPROPERTY(a.id,a.name,'PRECISION'),
                Digits=isnull(COLUMNPROPERTY(a.id,a.name,'Scale'),0),
                CanNull=case   when   a.isnullable=1   then   '是'else   '否'   end,
                DefaultValue=isnull(e.text,''),
                Label=isnull(g.[value],'')
                FROM   syscolumns   a
                left   join   systypes   b   on   a.xusertype=b.xusertype
                inner   join   sysobjects   d   on   a.id=d.id     and   d.xtype='U'   and     d.name<>'dtproperties'
                left   join   syscomments   e   on   a.cdefault=e.id
                left   join   sys.extended_properties   g   on   a.id=g.major_id   and   a.colid=g.minor_id
                left   join   sys.extended_properties   f   on   d.id=f.major_id   and   f.minor_id=0
                where   d.name='{0}' 
                order   by   a.id,a.colorder
            ";
            string selTableName = string.Empty;
            string selTableComm = string.Empty;
            string tempClassName = string.Empty;
            //定义要生成的实体中需要排除的列
            //主要是业务实体继承了基实体，在业务实体中就不需要再生成这些字段的映射了
            string excludes = "CREATE_TIME,CREATE_USER,UPDATE_TIME,UPDATE_USER,VERSION,ISDELETE,ORDER_INDEX,EXT_FIELD01,EXT_FIELD02,EXT_FIELD03,EXT_FIELD04,EXT_FIELD05,NODE_LAYER,NODE_INFO,NODE_TYPE,NODE_INFOTYPE";
            try
            {
                for (int i = 0; i < lvTabeleName.CheckedItems.Count; i++)
                {
                    selTableName = lvTabeleName.CheckedItems[i].Tag.ToString();
                    selTableComm = lvTabeleName.CheckedItems[i].Text.ToString();

                    dtColumn = dbHelper.Fill(string.Format(COLUMN_SQL, selTableName));
                    EntityClassInfo entityInfo = new EntityClassInfo();
                    entityInfo.tableName = selTableName;
                    entityInfo.tableComment = selTableComm;
                    tempClassName = ConvertHelper.SplitAndToFirstUpper(selTableName, '_');
                    entityInfo.className = tempClassName.Substring(0, 1).ToUpper() + tempClassName.Substring(1, tempClassName.Length - 1);
                    entityInfo.packageName = txtModelPackage.Text;
                    entityInfo.daoPackageName = txtDaoPackageName.Text;
                    entityInfo.servicePackageName = txtServerPackageName.Text;
                    entityInfo.dataTable = dtColumn;
                    entityInfo.codeLanguage = codeLanguage.Java;
                    entityInfo.excludes = excludes;

                    string templatePath = ConfigurationManager.AppSettings["TemplateEntity"].ToString();
                    entityInfo.createColumnInfo();

                    rtboxView.Clear();
                    //生成实体层代码
                    string codeEntity = CreateCode.CreateEntityClass(entityInfo, templatePath);
                    //rtboxView.AppendText(codeEntity);
                    if (string.IsNullOrEmpty(entityFileDir)){
                        Directory.CreateDirectory(entityFileDir);
                    }
                    File.WriteAllText(entityFileDir + entityInfo.className + ".java",codeEntity);

                    //生成Dao接口层代码
                    string templatePathDao = ConfigurationManager.AppSettings["TemplateDao"].ToString();
                    String codeDao = CreateCode.CreateEntityClass(entityInfo, templatePathDao);
                    //rtboxView.AppendText(codeDao);
                    if (!Directory.Exists(daoFileDir)){
                        Directory.CreateDirectory(daoFileDir);
                    }
                    File.WriteAllText(daoFileDir + entityInfo.className + "Dao.java",codeDao);

                    //生成Dao接口实现层代码
                    string TemplateDaoImpl = ConfigurationManager.AppSettings["TemplateDaoImpl"].ToString();
                    String codeDaoImpl = CreateCode.CreateEntityClass(entityInfo, TemplateDaoImpl);
                    //rtboxView.AppendText(codeDaoImpl);
                    String daoImplFileDir = daoFileDir + @"\Impl\";
                    if (!Directory.Exists(daoImplFileDir)){
                        Directory.CreateDirectory(daoImplFileDir);
                    }
                    File.WriteAllText(daoImplFileDir + entityInfo.className + "DaoImpl.java",codeDaoImpl);

                    //生成Service接口层代码
                    String TemplateService = ConfigurationManager.AppSettings["TemplateService"].ToString();
                    String codeService = CreateCode.CreateEntityClass(entityInfo, TemplateService);
                    //rtboxView.AppendText(codeService);
                    if (!Directory.Exists(serviceFileDir))
                {
                        Directory.CreateDirectory(serviceFileDir);
                    }
                    File.WriteAllText(serviceFileDir + entityInfo.className + "Service.java",codeService);

                    //生成Service接口实现层代码
                    String TemplateServiceImpl = ConfigurationManager.AppSettings["TemplateServiceImpl"].ToString();
                    String codeServiceImpl = CreateCode.CreateEntityClass(entityInfo, TemplateServiceImpl);
                    String serviceImplFileDir = serviceFileDir + @"\Impl\";
                    rtboxView.AppendText(codeServiceImpl);

                    if (!Directory.Exists(serviceImplFileDir))
                    {
                        Directory.CreateDirectory(serviceImplFileDir);
                    }
                    File.WriteAllText(serviceImplFileDir + entityInfo.className + "ServiceImpl.java",codeServiceImpl);
                }
                MessageBox.Show("代码生成完成");
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取数据库失败！" + ex.Message);
                return;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            btnConnect_Click(this, e);
        }
    }
}
