using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BJP.Framework.Code;
using BJP.Framework.Utility;
using System.Configuration;
using System.IO;

namespace GenerateCode
{
    public partial class FrmMain : Form
    {
        private string connString = string.Empty;
        private string selTableName = string.Empty;
        private string selTableComm = string.Empty;
        public string modelPackageName = string.Empty;  //实体层包名
        public string daoPackageName = string.Empty;    //dao层包名
        public string servicePackageName = string.Empty;    //service层包名
        public string controllerPackageName = string.Empty;  //controller层包名

        public string modelFileDir = string.Empty; //model代码保存目录
        public string daoFileDir = string.Empty;   //dao层代码保存目录
        public string serviceFileDir = string.Empty;   //service层代码保存目录
        public string controllerFileDir = string.Empty;   //controller层代码保存目录
        public string jsFileDir = string.Empty;  //前端Js代码保存目录

        private DataTable dtColumns = null;
        private EntityClassInfo entityInfo = new EntityClassInfo();
        private CreateService thisService = new CreateService();
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnSelectProjectDir_Click(object sender, EventArgs e)
        {
            fbDialogDir.Description = "工程目录选择";
            if (fbDialogDir.ShowDialog() == DialogResult.OK) {
                txtProjectDir.Text = fbDialogDir.SelectedPath;
            }
        }
        private void btnSelectJsDir_Click(object sender, EventArgs e)
        {
            fbDialogDir.Description = "JS代码目录选择";
            if (fbDialogDir.ShowDialog() == DialogResult.OK)
            {
                txtJsDir.Text = fbDialogDir.SelectedPath;
            }
        }
        private void btnSelectJavaTTDir_Click(object sender, EventArgs e)
        {
            fbDialogDir.Description = "JAVA模板目录选择";
            if (fbDialogDir.ShowDialog() == DialogResult.OK)
            {
                txtJavaTemplateDir.Text = fbDialogDir.SelectedPath;
            }
        }

        private void btnSelectJsTTDir_Click(object sender, EventArgs e)
        {
            fbDialogDir.Description = "JS模板目录选择";
            if (fbDialogDir.ShowDialog() == DialogResult.OK)
            {
                txtJsTemplateDir.Text = fbDialogDir.SelectedPath;
            }
        }
        private void btnConnectServer_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string userPwd = txtPwd.Text;
            string dbName = txtDbName.Text;
            string serverName = txtServer.Text;
            string tableName = string.Empty;
            string tableLabel = string.Empty;

            connString = "Provider=SQLOLEDB;Data Source={0};UID={1};pwd={2};DATABASE={3};";
            connString = string.Format(connString, serverName, userName, userPwd, dbName);

            thisService.connectionString = connString;
            DataTable dtTableName = thisService.getTableNameList();
            if ("".Equals(dtTableName))
            {
                MessageBox.Show("数据库连接错误");
            }
            else {
                listViewTableName.Clear();
                foreach (DataRow dr in dtTableName.Rows)
                {
                    tableName = dr["name"].ToString();
                    tableLabel = dr["label"].ToString() + "(" + tableName + ")";

                    if (string.IsNullOrEmpty(tableLabel))
                        tableLabel = tableName;

                    ListViewItem lvi = new ListViewItem();
                    lvi.Tag = tableName;
                    lvi.Text = tableLabel;

                    listViewTableName.Items.Add(lvi);
                }
            }
        }
        private void listViewTableName_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewTableName.SelectedItems.Count == 0) return;
            else
            {
                selTableComm = listViewTableName.SelectedItems[0].Text;
                selTableName = listViewTableName.SelectedItems[0].Tag.ToString();
                DataTable dtCoulumnList = thisService.getTabbleColumnList(selTableName);
                if (!dtCoulumnList.Equals(null))
                {
                    dtColumns = dtCoulumnList;
                    setGridView(dtCoulumnList);
                }
            }
        }

        private void gridFields_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = gridFields.CurrentCell.RowIndex;
            txtUUID.Text = gridFields.Rows[rowIndex].Cells[0].Value.ToString();
            txtColName.Text = gridFields.Rows[rowIndex].Cells[2].Value.ToString();
            txtOrderIndex.Text = gridFields.Rows[rowIndex].Cells[5].Value.ToString();
            txtDicCode.Text = gridFields.Rows[rowIndex].Cells[8].Value.ToString();
            txtColDesc.Text = gridFields.Rows[rowIndex].Cells[15].Value.ToString();
            cmbboxInputType.Text = gridFields.Rows[rowIndex].Cells[7].Value.ToString();
            // MessageBox.Show(gridFields.CurrentCell.RowIndex.ToString());
        }

        private void btnSaveField_Click(object sender, EventArgs e)
        {
            string inputType = "input";
            StringBuilder sb = new StringBuilder("UPDATE SYS_T_MENUTABLECOLUMN SET ");
            sb.Append(string.Format(" COL_NAME='{0}',",txtColName.Text));
            sb.Append(string.Format(" ORDER_INDEX='{0}',", txtOrderIndex.Text));
            sb.Append(string.Format(" DIC_CODE='{0}',", txtDicCode.Text));  
            sb.Append(string.Format(" COL_DESC='{0}',", txtColDesc.Text));
            sb.Append(string.Format(" INPUT_TYPE='{0}' ", cmbboxInputType.Text));
            sb.Append(string.Format(" WHERE COL_D='{0}'", txtUUID.Text));

            DataTable dt = thisService.resetColumn(sb.ToString(), selTableName);
            if (!dt.Equals(null))
                dtColumns = dt;
                setGridView(dt);
        }
        private void setGridView(DataTable dt)
        {
            gridFields.DataSource = dt;
            gridFields.Columns[0].HeaderText = "标识";
            gridFields.Columns[0].Visible = false;
            gridFields.Columns[1].HeaderText = "列编码";
            gridFields.Columns[2].HeaderText = "列名称";
            gridFields.Columns[3].HeaderText = "列类型";
            gridFields.Columns[3].Visible = false;
            gridFields.Columns[4].HeaderText = "列长度";
            gridFields.Columns[4].Visible = false;
            gridFields.Columns[5].HeaderText = "顺序号";
            gridFields.Columns[6].HeaderText = "小数位";
            gridFields.Columns[6].Visible = false;
            gridFields.Columns[7].HeaderText = "输入方式";
            gridFields.Columns[8].HeaderText = "输入码";
            gridFields.Columns[9].HeaderText = "主键列";
            gridFields.Columns[9].Visible = false;
            gridFields.Columns[10].HeaderText = "列表列";
            gridFields.Columns[11].HeaderText = "快速查询列";
            gridFields.Columns[12].HeaderText = "高级查询列";
            gridFields.Columns[13].HeaderText = "可编辑";
            gridFields.Columns[13].Visible = false;
            gridFields.Columns[14].HeaderText = "可为空";
            gridFields.Columns[14].Visible = false;
            gridFields.Columns[15].HeaderText = "列说明";
            gridFields.Columns[16].HeaderText = "数据表";
            gridFields.Columns[16].Visible = false;
        }

        private void btnCreateJava_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(entityInfo.tableName))
                InitCreateEntity();
            string JavaTTDir = txtJavaTemplateDir.Text;
            if (string.IsNullOrEmpty(JavaTTDir))
            {
                MessageBox.Show("请选择java代码模板路径");
                return;
            }
            string templateFile = JavaTTDir + @"Entity.tt";

            //生成实体层的代码
            CreateCodeFile(templateFile, modelFileDir);

        }

        private void CreateCodeFile(string templatePath, string saveDir)
        {
            string codeEntity = CreateCode.CreateEntityClass(entityInfo, templatePath);
            if (!Directory.Exists(saveDir))
            {
                Directory.CreateDirectory(saveDir);
            }
            File.WriteAllText(saveDir + entityInfo.className + ".java", codeEntity);
        }

        private void InitCreateEntity()
        {
            if (string.IsNullOrEmpty(modelPackageName))
                intPackageAndPath();
            if (string.IsNullOrEmpty(selTableName))
            {
                MessageBox.Show("请选择要生成代码的数据表");
                return;
            }
            
            entityInfo.tableName = selTableName;
            entityInfo.tableComment = selTableComm;
            string tempClassName = ConvertHelper.SplitAndToFirstUpper(selTableName, '_');
            string className = tempClassName.Substring(0, 1).ToUpper() + tempClassName.Substring(1, tempClassName.Length - 1);
            entityInfo.className = className;
            entityInfo.packageName = modelPackageName;
            entityInfo.daoPackageName = daoPackageName;
            entityInfo.servicePackageName = servicePackageName;
            entityInfo.controllerPackageName = controllerPackageName;
            entityInfo.dataTable = dtColumns;
            entityInfo.codeLanguage = codeLanguage.Java;
            entityInfo.jsDir = jsFileDir;

            entityInfo.createColumnInfo();
        }

        private void intPackageAndPath() {
            string projectDir = txtProjectDir.Text; //工程的主目录
            if (string.IsNullOrEmpty(projectDir)) {
                MessageBox.Show("请设置工程的主目录");
                return;
            }
            string menuConfig = txtMenuConfig.Text;
            if (string.IsNullOrEmpty(menuConfig)) {
                MessageBox.Show("请设置模块的配置参数");
                return;
            }

            string jsDir = txtJsDir.Text;
            if (string.IsNullOrEmpty(jsDir)) {
                MessageBox.Show("请JS文件的起始目录");
                return;
            }
            string projectPackageName = ConfigurationManager.AppSettings["ProjectPackageName"].ToString();
            string projectName = ConfigurationManager.AppSettings["ProjectName"].ToString();

            //根据模块的配置参数转换JAVA对应的包名
            //转换规则，去掉配置参数最后的一个.符号后的字符
            //如配置格式为:salary.salaryitem，则JAVA包为salary
            //如格式为salary.salaryset.salaryitem,则JAVA包为salary.salaryset
            string menuPackageName = menuConfig.Substring(0, menuConfig.LastIndexOf("."));
            modelPackageName = projectPackageName + ".model." + menuPackageName;
            daoPackageName = projectPackageName + ".dao." + menuPackageName;
            servicePackageName = projectPackageName + ".service." + menuPackageName;
            controllerPackageName = projectPackageName + ".controller." + menuPackageName;

            //形成最后的代码保存路径
            //项目路径+ 代码分层对应的路径 + 项目包转换后的路径+ 模块编码
            //如项目路径为e:\temp\jw\；项目包为com.zd.school.jw；模块编码为eduresources
            //对应的model层的路径为e:\temp\jw\jw-model\src\main\java\com\zd\school\jw\eduresources
            modelFileDir = projectDir + projectName + @"-model\src\main\java\" + PackageNameToDirName(modelPackageName);
            daoFileDir = projectDir + projectName + @"-dao\src\main\java\" + PackageNameToDirName(daoPackageName);
            serviceFileDir = projectDir + projectName + @"-service\src\main\java\" + PackageNameToDirName(servicePackageName);
            controllerFileDir = projectDir + projectName + @"-web\src\main\java\" + PackageNameToDirName(controllerPackageName);
            jsFileDir = jsDir + @"\" + PackageNameToDirName(menuConfig);
        }
       
        /// <summary>
        /// 将项目的包名转换成目录
        /// </summary>
        /// <param name="packageName"></param>
        /// <returns></returns>
        private string PackageNameToDirName(string packageName)
        {
            string[] listDir = packageName.Split('.');
            StringBuilder sb = new StringBuilder();
            foreach (string s in listDir)
            {
                sb.Append(s);
                sb.Append("\\");
            }

            return sb.ToString();
        }
    }
}
