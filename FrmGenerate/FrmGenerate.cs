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

        public string modelPackageName = string.Empty;  //实体层包名
        public string daoPackageName = string.Empty;    //dao层包名
        public string servicePackageName = string.Empty;    //service层包名
        public string controllerPackageName = string.Empty;  //controller层包名

        public string modelFileDir = string.Empty; //model代码保存目录
        public string daoFileDir = string.Empty;   //dao层代码保存目录
        public string serviceFileDir = string.Empty;   //service层代码保存目录
        public string controllerFileDir = string.Empty;   //controller层代码保存目录
        public string jsControllerFileDir = string.Empty; //前端JS的controller层代码保存目录
        public string jsViewFileDir = string.Empty; //前端JS的view层代码保存目录

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string userPwd = txtUserPwd.Text;
            string dbName = txtDbName.Text;
            string serverName = txtServer.Text;
            string tableName = string.Empty;
            string tableLabel = string.Empty;

            connString = "Provider=SQLOLEDB;Data Source={0};UID={1};pwd={2};DATABASE={3};";
            connString = string.Format(connString, serverName, userName, userPwd, dbName);
            //connString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString.ToString();//配置文件中取
            string sql = "SELECT a.*,";
            sql += "  label = b.value,";
            sql += " PrimaryKey = KCU.COLUMN_NAME";
            sql += " FROM sys.TABLES a";
            sql += " LEFT JOIN  sys.extended_properties b on a.object_id = b.major_id and b.minor_id = 0";
            sql += " LEFT JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE KCU ON KCU.TABLE_NAME = a.name";
            sql += " INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc ON tc.TABLE_NAME = a.name AND tc.CONSTRAINT_TYPE = 'PRIMARY KEY'";
            sql += "     AND KCU.CONSTRAINT_NAME = tc.CONSTRAINT_NAME";
            sql += " WHERE a.type = 'U' order by a.name";

            DbHelper dbHelper = new DbHelper(connString);
            DataTable dtTableName = dbHelper.Fill(sql);
            lvTabeleName.Clear();
            foreach (DataRow dr in dtTableName.Rows)
            {
                tableName = dr["name"].ToString();
                tableLabel = dr["label"].ToString() + "(" + tableName + ")";

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

            lboxInfo.Items.Clear();

            lboxInfo.Items.Add("正在初始化相关包名与目录...");
            intPackageAndPath();
            lboxInfo.Items.Add("初始化完成 OK");

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
            string className = string.Empty;
            //定义要生成的实体中需要排除的列
            //主要是业务实体继承了基实体，在业务实体中就不需要再生成这些字段的映射了
            string excludes = "CREATE_TIME,CREATE_USER,UPDATE_TIME,UPDATE_USER,VERSION,ISDELETE,ORDER_INDEX,EXT_FIELD01,EXT_FIELD02,EXT_FIELD03,EXT_FIELD04,EXT_FIELD05,NODE_LAYER,NODE_INFO,NODE_TYPE,NODE_INFOTYPE";
            try
            {
                for (int i = 0; i < lvTabeleName.CheckedItems.Count; i++)
                {
                    selTableName = lvTabeleName.CheckedItems[i].Tag.ToString();
                    selTableComm = lvTabeleName.CheckedItems[i].Text.ToString();

                    lboxInfo.Items.Add("处理数据表" + selTableComm  + "的相关信息...");

                    dtColumn = dbHelper.Fill(string.Format(COLUMN_SQL, selTableName));
                    EntityClassInfo entityInfo = new EntityClassInfo();
                    entityInfo.tableName = selTableName;
                    entityInfo.tableComment = selTableComm;
                    tempClassName = ConvertHelper.SplitAndToFirstUpper(selTableName, '_');
                    className = tempClassName.Substring(0, 1).ToUpper() + tempClassName.Substring(1, tempClassName.Length - 1);
                    entityInfo.className = className;
                    entityInfo.packageName = modelPackageName;
                    entityInfo.daoPackageName = daoPackageName;
                    entityInfo.servicePackageName = servicePackageName;
                    entityInfo.controllerPackageName = controllerPackageName;
                    entityInfo.dataTable = dtColumn;
                    entityInfo.codeLanguage = codeLanguage.Java;
                    entityInfo.excludes = excludes;
                    entityInfo.JsOneDirName = txtModelOne.Text;
                    entityInfo.JsTwoDirName = txtJsName.Text;

                    string templatePath = ConfigurationManager.AppSettings["TemplateEntity"].ToString();
                    entityInfo.createColumnInfo();

                    //rtboxView.Clear();
                    //生成实体层代码
                    //lboxInfo.Items.Add("生成数据表" + selTableComm + "的实体层代码...");
                    ////lboxInfo.Items.Add("实体目录：" + modelFileDir);
                    //string codeEntity = CreateCode.CreateEntityClass(entityInfo, templatePath);
                    ////rtboxView.AppendText(codeEntity);
                    //if (!Directory.Exists(modelFileDir))
                    //{
                    //    Directory.CreateDirectory(modelFileDir);
                    //}
                    //File.WriteAllText(modelFileDir + className + ".java", codeEntity);

                    ////生成Dao接口层代码
                    //lboxInfo.Items.Add("生成数据表" + selTableComm + "的dao接口层代码...");
                    //string templatePathDao = ConfigurationManager.AppSettings["TemplateDao"].ToString();
                    //String codeDao = CreateCode.CreateEntityClass(entityInfo, templatePathDao);
                    ////rtboxView.AppendText(codeDao);
                    //if (!Directory.Exists(daoFileDir))
                    //{
                    //    Directory.CreateDirectory(daoFileDir);
                    //}
                    //File.WriteAllText(daoFileDir + className + "Dao.java", codeDao);

                    ////生成Dao接口实现层代码
                    //lboxInfo.Items.Add("生成数据表" + selTableComm + "的dao接口实现层代码...");
                    //string TemplateDaoImpl = ConfigurationManager.AppSettings["TemplateDaoImpl"].ToString();
                    //String codeDaoImpl = CreateCode.CreateEntityClass(entityInfo, TemplateDaoImpl);
                    ////rtboxView.AppendText(codeDaoImpl);
                    //String daoImplFileDir = daoFileDir + @"\Impl\";
                    //if (!Directory.Exists(daoImplFileDir))
                    //{
                    //    Directory.CreateDirectory(daoImplFileDir);
                    //}
                    //File.WriteAllText(daoImplFileDir + className + "DaoImpl.java", codeDaoImpl);

                    ////生成Service接口层代码
                    //lboxInfo.Items.Add("生成数据表" + selTableComm + "的service接口层代码...");
                    //String TemplateService = ConfigurationManager.AppSettings["TemplateService"].ToString();
                    //String codeService = CreateCode.CreateEntityClass(entityInfo, TemplateService);
                    ////rtboxView.AppendText(codeService);
                    //if (!Directory.Exists(serviceFileDir))
                    //{
                    //    Directory.CreateDirectory(serviceFileDir);
                    //}
                    //File.WriteAllText(serviceFileDir + className + "Service.java", codeService);

                    ////生成Service接口实现层代码
                    //lboxInfo.Items.Add("生成数据表" + selTableComm + "的service接口实现层代码...");
                    //String TemplateServiceImpl = ConfigurationManager.AppSettings["TemplateServiceImpl"].ToString();
                    //String codeServiceImpl = CreateCode.CreateEntityClass(entityInfo, TemplateServiceImpl);
                    //String serviceImplFileDir = serviceFileDir + @"\Impl\";
                    ////rtboxView.AppendText(codeServiceImpl);

                    //if (!Directory.Exists(serviceImplFileDir))
                    //{
                    //    Directory.CreateDirectory(serviceImplFileDir);
                    //}
                    //File.WriteAllText(serviceImplFileDir + className + "ServiceImpl.java", codeServiceImpl);

                    ////生成Controller接口实现层代码
                    //lboxInfo.Items.Add("生成数据表" + selTableComm + "的controller层代码...");
                    //String TemplateController = ConfigurationManager.AppSettings["TemplateController"].ToString();
                    //String codeController = CreateCode.CreateEntityClass(entityInfo, TemplateController);
                    ////String controller = serviceFileDir + @"\Impl\";
                    ////rtboxView.AppendText(codeServiceImpl);

                    //if (!Directory.Exists(controllerFileDir))
                    //{
                    //    Directory.CreateDirectory(controllerFileDir);
                    //}
                    //File.WriteAllText(controllerFileDir + className + "Controller.java", codeController);

                    //生成前端JSController接口实现层代码
                    lboxInfo.Items.Add("生成数据表" + selTableComm + "的前端controller层代码...");
                    String JsTemplateController = ConfigurationManager.AppSettings["TemplateJsController"].ToString();
                    String JsController = CreateCode.CreateEntityClass(entityInfo, JsTemplateController);
                    //String controller = serviceFileDir + @"\Impl\";
                    //rtboxView.AppendText(codeServiceImpl);

                    if (!Directory.Exists(jsControllerFileDir))
                    {
                        Directory.CreateDirectory(jsControllerFileDir);
                    }
                    File.WriteAllText(jsControllerFileDir + "MainController.js", JsController);

                    //生成前端TemplateJsViewMain接口实现层代码
                    lboxInfo.Items.Add("生成数据表" + selTableComm + "的前端controller层代码...");
                    String TemplateJsViewMain = ConfigurationManager.AppSettings["TemplateJsViewMain"].ToString();
                    String codeTemplateJsViewMain = CreateCode.CreateEntityClass(entityInfo, TemplateJsViewMain);
                    //String controller = serviceFileDir + @"\Impl\";
                    //rtboxView.AppendText(codeServiceImpl);

                    if (!Directory.Exists(jsViewFileDir))
                    {
                        Directory.CreateDirectory(jsViewFileDir);
                    }
                    File.WriteAllText(jsViewFileDir + "mainLayout.js", codeTemplateJsViewMain);

                    //生成前端TemplateJsViewMain接口实现层代码
                    lboxInfo.Items.Add("生成数据表" + selTableComm + "的前端controller层代码...");
                    String TemplateJsViewGrid = ConfigurationManager.AppSettings["TemplateJsViewGrid"].ToString();
                    String codeTemplateJsViewGrid = CreateCode.CreateEntityClass(entityInfo, TemplateJsViewGrid);
                    //String controller = serviceFileDir + @"\Impl\";
                    //rtboxView.AppendText(codeServiceImpl);

                    if (!Directory.Exists(jsViewFileDir))
                    {
                        Directory.CreateDirectory(jsViewFileDir);
                    }
                    File.WriteAllText(jsViewFileDir + "listGrid.js", codeTemplateJsViewGrid);

                    //生成前端TemplateJsViewMain接口实现层代码
                    lboxInfo.Items.Add("生成数据表" + selTableComm + "的前端controller层代码...");
                    String TemplateJsViewDetail = ConfigurationManager.AppSettings["TemplateJsViewDetail"].ToString();
                    String codeTemplateJsViewDetail = CreateCode.CreateEntityClass(entityInfo, TemplateJsViewDetail);
                    //String controller = serviceFileDir + @"\Impl\";
                    //rtboxView.AppendText(codeServiceImpl);

                    if (!Directory.Exists(jsViewFileDir))
                    {
                        Directory.CreateDirectory(jsViewFileDir);
                    }
                    File.WriteAllText(jsViewFileDir + "detailLayout.js", codeTemplateJsViewDetail);

                    //生成前端TemplateJsViewMain接口实现层代码
                    lboxInfo.Items.Add("生成数据表" + selTableComm + "的前端controller层代码...");
                    String TemplateJsViewform = ConfigurationManager.AppSettings["TemplateJsViewform"].ToString();
                    String codeTemplateJsViewform = CreateCode.CreateEntityClass(entityInfo, TemplateJsViewform);
                    //String controller = serviceFileDir + @"\Impl\";
                    //rtboxView.AppendText(codeServiceImpl);

                    if (!Directory.Exists(jsViewFileDir))
                    {
                        Directory.CreateDirectory(jsViewFileDir);
                    }
                    File.WriteAllText(jsViewFileDir + "detailForm.js", codeTemplateJsViewform);
                }
                    lboxInfo.Items.Add("全部所选数据表的代码生成完毕！");
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

        private void intPackageAndPath()
        {
            string projectDir = txtProjectDir.Text;
            string moduleOne = txtModelOne.Text;
            string moduleTwo = txtModelTwo.Text;

            //com.zd.school
            string projectPackageName = ConfigurationManager.AppSettings["ProjectPackageName"].ToString();
            string projectName = ConfigurationManager.AppSettings["ProjectName"].ToString();

            string menuPackageName = moduleOne;
            if (moduleTwo != "") {
                menuPackageName = menuPackageName + "." + moduleTwo;
            }


            modelPackageName = projectPackageName + "." +  menuPackageName + ".model";
            daoPackageName = projectPackageName + "." + menuPackageName + ".dao";
            servicePackageName = projectPackageName + "." + menuPackageName + ".service" ;
            controllerPackageName = projectPackageName + "." + menuPackageName+ ".controller";



            //形成最后的代码保存路径
            //项目路径+ 代码分层对应的路径 + 项目包转换后的路径+ 模块编码
            //如项目路径为e:\temp\jw\；项目包为com.zd.school.jw；模块编码为eduresources
            //对应的model层的路径为e:\temp\jw\jw-model\src\main\java\com\zd\school\jw\eduresources
            modelFileDir = projectDir + projectName + @"-model\src\main\java\" + PackageNameToDirName(modelPackageName);
            daoFileDir = projectDir + projectName + @"-dao\src\main\java\" + PackageNameToDirName(daoPackageName);
            serviceFileDir = projectDir + projectName + @"-service\src\main\java\" + PackageNameToDirName(servicePackageName);
            controllerFileDir = projectDir + projectName + @"-web\src\main\java\" + PackageNameToDirName(controllerPackageName);
            jsControllerFileDir = projectDir + projectName + @"-web\src\main\webapp\static\core\coreApp\" + txtModelOne.Text + @"\" + txtJsName.Text + @"\controller\"; //前端JS的controller层代码保存目录
            //jsViewFileDir = projectDir + projectName + @"-web\src\main\webapp\static\core\coreApp\"  +txtModelOne.Text + @"\" + txtJsName.Text + @"\view\"; //前端JS的view层代码保存目录
            jsViewFileDir = projectDir + projectName + @"-web\src\main\webapp\static\core\app\" + txtModelOne.Text + @"\" + txtJsName.Text + @"\view\"; //新的前端JS的view层代码保存目录
            //core\app\good\
        }

        public string PackageNameToDirName(string packageName) {
            //将项目的包名转换成目录
            string[] listDir = packageName.Split('.');
            StringBuilder sb = new StringBuilder();
            foreach (string s in listDir)
            {
                sb.Append(s);
                sb.Append("\\");
            }

            return sb.ToString();
        }

        private void btnCreateAfter_Click(object sender, EventArgs e)
        {
            DbHelper dbHelper = new DbHelper(connString);
            DataTable dtColumn = new DataTable();
            if (lvTabeleName.CheckedItems.Count == 0)
            {
                MessageBox.Show("请选择要生成代码的数据表");
                return;
            }

            lboxInfo.Items.Clear();

            lboxInfo.Items.Add("正在初始化相关包名与目录...");
            intPackageAndPath();
            lboxInfo.Items.Add("初始化完成 OK");

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
            string className = string.Empty;
            //定义要生成的实体中需要排除的列
            //主要是业务实体继承了基实体，在业务实体中就不需要再生成这些字段的映射了
            string excludes = "CREATE_TIME,CREATE_USER,UPDATE_TIME,UPDATE_USER,VERSION,ISDELETE,ORDER_INDEX,EXT_FIELD01,EXT_FIELD02,EXT_FIELD03,EXT_FIELD04,EXT_FIELD05,NODE_LAYER,NODE_INFO,NODE_TYPE,NODE_INFOTYPE";
            try
            {
                for (int i = 0; i < lvTabeleName.CheckedItems.Count; i++)
                {
                    selTableName = lvTabeleName.CheckedItems[i].Tag.ToString();
                    selTableComm = lvTabeleName.CheckedItems[i].Text.ToString();

                    lboxInfo.Items.Add("处理数据表" + selTableComm + "的相关信息...");

                    dtColumn = dbHelper.Fill(string.Format(COLUMN_SQL, selTableName));
                    EntityClassInfo entityInfo = new EntityClassInfo();
                    entityInfo.tableName = selTableName;
                    entityInfo.tableComment = selTableComm;
                    tempClassName = ConvertHelper.SplitAndToFirstUpper(selTableName, '_');
                    className = tempClassName.Substring(0, 1).ToUpper() + tempClassName.Substring(1, tempClassName.Length - 1);
                    entityInfo.className = className;
                    entityInfo.packageName = modelPackageName;
                    entityInfo.daoPackageName = daoPackageName;
                    entityInfo.servicePackageName = servicePackageName;
                    entityInfo.controllerPackageName = controllerPackageName;
                    entityInfo.dataTable = dtColumn;
                    entityInfo.codeLanguage = codeLanguage.Java;
                    entityInfo.excludes = excludes;
                    entityInfo.JsOneDirName = txtModelOne.Text;
                    entityInfo.JsTwoDirName = txtJsName.Text;

                    string templatePath = ConfigurationManager.AppSettings["TemplateEntity"].ToString();
                    entityInfo.createColumnInfo();

                    //rtboxView.Clear();
                    //生成实体层代码
                    lboxInfo.Items.Add("生成数据表" + selTableComm + "的实体层代码...");
                    //lboxInfo.Items.Add("实体目录：" + modelFileDir);
                    string codeEntity = CreateCode.CreateEntityClass(entityInfo, templatePath);
                    //rtboxView.AppendText(codeEntity);
                    if (!Directory.Exists(modelFileDir))
                    {
                        Directory.CreateDirectory(modelFileDir);
                    }
                    File.WriteAllText(modelFileDir + className + ".java", codeEntity);

                    //生成Dao接口层代码
                    lboxInfo.Items.Add("生成数据表" + selTableComm + "的dao接口层代码...");
                    string templatePathDao = ConfigurationManager.AppSettings["TemplateDao"].ToString();
                    String codeDao = CreateCode.CreateEntityClass(entityInfo, templatePathDao);
                    //rtboxView.AppendText(codeDao);
                    if (!Directory.Exists(daoFileDir))
                    {
                        Directory.CreateDirectory(daoFileDir);
                    }
                    File.WriteAllText(daoFileDir + className + "Dao.java", codeDao);

                    //生成Dao接口实现层代码
                    lboxInfo.Items.Add("生成数据表" + selTableComm + "的dao接口实现层代码...");
                    string TemplateDaoImpl = ConfigurationManager.AppSettings["TemplateDaoImpl"].ToString();
                    String codeDaoImpl = CreateCode.CreateEntityClass(entityInfo, TemplateDaoImpl);
                    //rtboxView.AppendText(codeDaoImpl);
                    String daoImplFileDir = daoFileDir + @"\Impl\";
                    if (!Directory.Exists(daoImplFileDir))
                    {
                        Directory.CreateDirectory(daoImplFileDir);
                    }
                    File.WriteAllText(daoImplFileDir + className + "DaoImpl.java", codeDaoImpl);

                    //生成Service接口层代码
                    lboxInfo.Items.Add("生成数据表" + selTableComm + "的service接口层代码...");
                    String TemplateService = ConfigurationManager.AppSettings["TemplateService"].ToString();
                    String codeService = CreateCode.CreateEntityClass(entityInfo, TemplateService);
                    //rtboxView.AppendText(codeService);
                    if (!Directory.Exists(serviceFileDir))
                    {
                        Directory.CreateDirectory(serviceFileDir);
                    }
                    File.WriteAllText(serviceFileDir + className + "Service.java", codeService);

                    //生成Service接口实现层代码
                    lboxInfo.Items.Add("生成数据表" + selTableComm + "的service接口实现层代码...");
                    String TemplateServiceImpl = ConfigurationManager.AppSettings["TemplateServiceImpl"].ToString();
                    String codeServiceImpl = CreateCode.CreateEntityClass(entityInfo, TemplateServiceImpl);
                    String serviceImplFileDir = serviceFileDir + @"\Impl\";
                    //rtboxView.AppendText(codeServiceImpl);

                    if (!Directory.Exists(serviceImplFileDir))
                    {
                        Directory.CreateDirectory(serviceImplFileDir);
                    }
                    File.WriteAllText(serviceImplFileDir + className + "ServiceImpl.java", codeServiceImpl);

                    //生成Controller接口实现层代码
                    lboxInfo.Items.Add("生成数据表" + selTableComm + "的controller层代码...");
                    String TemplateController = ConfigurationManager.AppSettings["TemplateController"].ToString();
                    String codeController = CreateCode.CreateEntityClass(entityInfo, TemplateController);
                    //String controller = serviceFileDir + @"\Impl\";
                    //rtboxView.AppendText(codeServiceImpl);

                    if (!Directory.Exists(controllerFileDir))
                    {
                        Directory.CreateDirectory(controllerFileDir);
                    }
                    File.WriteAllText(controllerFileDir + className + "Controller.java", codeController);

                }
                lboxInfo.Items.Add("全部所选数据表的代码生成完毕！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取数据库失败！" + ex.Message);
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbHelper dbHelper = new DbHelper(connString);
            DataTable dtColumn = new DataTable();
            if (lvTabeleName.CheckedItems.Count == 0)
            {
                MessageBox.Show("请选择要生成代码的数据表");
                return;
            }

            lboxInfo.Items.Clear();

            lboxInfo.Items.Add("正在初始化相关包名与目录...");
            intPackageAndPath();
            lboxInfo.Items.Add("初始化完成 OK");

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
            string className = string.Empty;
            //定义要生成的实体中需要排除的列
            //主要是业务实体继承了基实体，在业务实体中就不需要再生成这些字段的映射了
            string excludes = "CREATE_TIME,CREATE_USER,UPDATE_TIME,UPDATE_USER,VERSION,ISDELETE,ORDER_INDEX,EXT_FIELD01,EXT_FIELD02,EXT_FIELD03,EXT_FIELD04,EXT_FIELD05,NODE_LAYER,NODE_INFO,NODE_TYPE,NODE_INFOTYPE";
            try
            {
                for (int i = 0; i < lvTabeleName.CheckedItems.Count; i++)
                {
                    selTableName = lvTabeleName.CheckedItems[i].Tag.ToString();
                    selTableComm = lvTabeleName.CheckedItems[i].Text.ToString();

                    lboxInfo.Items.Add("处理数据表" + selTableComm + "的相关信息...");

                    dtColumn = dbHelper.Fill(string.Format(COLUMN_SQL, selTableName));
                    EntityClassInfo entityInfo = new EntityClassInfo();
                    entityInfo.tableName = selTableName;
                    entityInfo.tableComment = selTableComm;
                    tempClassName = ConvertHelper.SplitAndToFirstUpper(selTableName, '_');
                    className = tempClassName.Substring(0, 1).ToUpper() + tempClassName.Substring(1, tempClassName.Length - 1);
                    entityInfo.className = className;
                    entityInfo.packageName = modelPackageName;
                    entityInfo.daoPackageName = daoPackageName;
                    entityInfo.servicePackageName = servicePackageName;
                    entityInfo.controllerPackageName = controllerPackageName;
                    entityInfo.dataTable = dtColumn;
                    entityInfo.codeLanguage = codeLanguage.Java;
                    entityInfo.excludes = excludes;
                    entityInfo.JsOneDirName = txtModelOne.Text;
                    entityInfo.JsTwoDirName = txtJsName.Text;

                    string templatePath = ConfigurationManager.AppSettings["TemplateEntity"].ToString();
                    entityInfo.createColumnInfo();


                    ////生成前端JSController接口实现层代码
                    //lboxInfo.Items.Add("生成数据表" + selTableComm + "的前端controller层代码...");
                    //String JsTemplateController = ConfigurationManager.AppSettings["TemplateJsController"].ToString();
                    //String JsController = CreateCode.CreateEntityClass(entityInfo, JsTemplateController);
                    ////String controller = serviceFileDir + @"\Impl\";
                    ////rtboxView.AppendText(codeServiceImpl);

                    //if (!Directory.Exists(jsControllerFileDir))
                    //{
                    //    Directory.CreateDirectory(jsControllerFileDir);
                    //}
                    //File.WriteAllText(jsControllerFileDir + "MainController.js", JsController);

                    //生成前端TemplateJsViewMain接口实现层代码
                    lboxInfo.Items.Add("生成数据表" + selTableComm + "的前端mainlayout代码...");
                    String TemplateJsViewMain = ConfigurationManager.AppSettings["TemplateJsViewMain"].ToString();
                    String codeTemplateJsViewMain = CreateCode.CreateEntityClass(entityInfo, TemplateJsViewMain);
                    //String controller = serviceFileDir + @"\Impl\";
                    //rtboxView.AppendText(codeServiceImpl);

                    if (!Directory.Exists(jsViewFileDir))
                    {
                        Directory.CreateDirectory(jsViewFileDir);
                    }
                    File.WriteAllText(jsViewFileDir + "MainLayout.js", codeTemplateJsViewMain);

                    //生成前端TemplateJsViewMain接口实现层代码
                    lboxInfo.Items.Add("生成数据表" + selTableComm + "的前端grid代码...");
                    String TemplateJsViewGrid = ConfigurationManager.AppSettings["TemplateJsViewGrid"].ToString();
                    String codeTemplateJsViewGrid = CreateCode.CreateEntityClass(entityInfo, TemplateJsViewGrid);
                    //String controller = serviceFileDir + @"\Impl\";
                    //rtboxView.AppendText(codeServiceImpl);

                    if (!Directory.Exists(jsViewFileDir))
                    {
                        Directory.CreateDirectory(jsViewFileDir);
                    }
                    File.WriteAllText(jsViewFileDir + "MainGrid.js", codeTemplateJsViewGrid);

                    ////生成前端TemplateJsViewMain接口实现层代码
                    //lboxInfo.Items.Add("生成数据表" + selTableComm + "的前端controller层代码...");
                    //String TemplateJsViewDetail = ConfigurationManager.AppSettings["TemplateJsViewDetail"].ToString();
                    //String codeTemplateJsViewDetail = CreateCode.CreateEntityClass(entityInfo, TemplateJsViewDetail);
                    ////String controller = serviceFileDir + @"\Impl\";
                    ////rtboxView.AppendText(codeServiceImpl);

                    //if (!Directory.Exists(jsViewFileDir))
                    //{
                    //    Directory.CreateDirectory(jsViewFileDir);
                    //}
                    //File.WriteAllText(jsViewFileDir + "detailLayout.js", codeTemplateJsViewDetail);

                    ////生成前端TemplateJsViewMain接口实现层代码
                    //lboxInfo.Items.Add("生成数据表" + selTableComm + "的前端controller层代码...");
                    //String TemplateJsViewform = ConfigurationManager.AppSettings["TemplateJsViewform"].ToString();
                    //String codeTemplateJsViewform = CreateCode.CreateEntityClass(entityInfo, TemplateJsViewform);
                    ////String controller = serviceFileDir + @"\Impl\";
                    ////rtboxView.AppendText(codeServiceImpl);

                    //if (!Directory.Exists(jsViewFileDir))
                    //{
                    //    Directory.CreateDirectory(jsViewFileDir);
                    //}
                    //File.WriteAllText(jsViewFileDir + "detailForm.js", codeTemplateJsViewform);
                }
                lboxInfo.Items.Add("全部所选数据表的代码生成完毕！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取数据库失败！" + ex.Message);
                return;
            }
        }
    }
}
