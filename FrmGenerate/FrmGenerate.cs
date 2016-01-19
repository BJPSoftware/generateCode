using System;
using System.IO;
using System.Data;
using System.Windows.Forms;
using BJP.Framework.Repository;
using BJP.Framework.Utility;
using EntityInfo;

namespace FrmGenerate
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
            string COLUMN_SQL = @"SELECT  
                Name=a.name,
                AutoIncrement=case   when   COLUMNPROPERTY(   a.id,a.name,'IsIdentity')=1   then   '是'else   '否'   end,
                IsPK=case   when   exists(SELECT   1   FROM   sysobjects   where   xtype<>'PK'   and   name   in   (
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
            try
            {
                for (int i = 0; i < lvTabeleName.CheckedItems.Count; i++)
                {
                    selTableName = lvTabeleName.CheckedItems[i].Tag.ToString();
                }
                dtColumn = dbHelper.Fill(string.Format(COLUMN_SQL, selTableName));
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取数据库失败！" + ex.Message);
                return;
            }
            EntityClassInfo entityInfo = new EntityClassInfo();
            entityInfo.tableName = selTableName;
            entityInfo.className = ConvertHelper.SplitAndToFirstUpper(selTableName, '_');
            entityInfo.packageName = "com.forestry.model.sys";
            entityInfo.dataTable = dtColumn;

            entityInfo.createColumnInfo();
            //string codeEntity = CreateCode.CreateEntityClass(entityInfo);
            ////rtxtModel.AppendText(codeEntity);
            //string codeDataAccess = CreateCode.CreateDataAccessClass(entityInfo);
            ////rtxtDAL.AppendText(codeDataAccess);
            //if (!string.IsNullOrEmpty(txtOutPath.Text))
            //{
            //    File.WriteAllText(txtOutPath.Text + entityInfo.ClassName + ".cs",
            //        codeEntity);
            //    File.WriteAllText(txtOutPath.Text + entityInfo.ClassName + "DAL.cs",
            //        codeDataAccess);
            //}
        }
    }
}
