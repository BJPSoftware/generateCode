namespace GenerateCode
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gboxConString = new System.Windows.Forms.GroupBox();
            this.txtDbName = new System.Windows.Forms.TextBox();
            this.lblDbName = new System.Windows.Forms.Label();
            this.btnConnectServer = new System.Windows.Forms.Button();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.lblDbServer = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.lblPwd = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.gboxTableName = new System.Windows.Forms.GroupBox();
            this.listViewTableName = new System.Windows.Forms.ListView();
            this.gboxFields = new System.Windows.Forms.GroupBox();
            this.gridFields = new System.Windows.Forms.DataGridView();
            this.txtColName = new System.Windows.Forms.TextBox();
            this.lblColName = new System.Windows.Forms.Label();
            this.txtOrderIndex = new System.Windows.Forms.TextBox();
            this.lblOrderIndex = new System.Windows.Forms.Label();
            this.lblInputType = new System.Windows.Forms.Label();
            this.txtDicCode = new System.Windows.Forms.TextBox();
            this.lblDicCode = new System.Windows.Forms.Label();
            this.cmbboxInputType = new System.Windows.Forms.ComboBox();
            this.chkColGrid = new System.Windows.Forms.CheckBox();
            this.lblColGrid = new System.Windows.Forms.Label();
            this.chkEQuery = new System.Windows.Forms.CheckBox();
            this.lblEQuery = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.lblQQuery = new System.Windows.Forms.Label();
            this.lblColDesc = new System.Windows.Forms.Label();
            this.txtColDesc = new System.Windows.Forms.TextBox();
            this.btnSaveField = new System.Windows.Forms.Button();
            this.gboxCreateParam = new System.Windows.Forms.GroupBox();
            this.txtUUID = new System.Windows.Forms.TextBox();
            this.btnSelectJsTTDir = new System.Windows.Forms.Button();
            this.btnSelectJavaTTDir = new System.Windows.Forms.Button();
            this.txtJsTemplateDir = new System.Windows.Forms.TextBox();
            this.txtJavaTemplateDir = new System.Windows.Forms.TextBox();
            this.lblJavaTemplate = new System.Windows.Forms.Label();
            this.lblJsTemplate = new System.Windows.Forms.Label();
            this.btnCreateJava = new System.Windows.Forms.Button();
            this.btnSelectProjectDir = new System.Windows.Forms.Button();
            this.txtProjectDir = new System.Windows.Forms.TextBox();
            this.lblProjectDir = new System.Windows.Forms.Label();
            this.txtMenuConfig = new System.Windows.Forms.TextBox();
            this.lblMenuConfig = new System.Windows.Forms.Label();
            this.fbDialogDir = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelectJsDir = new System.Windows.Forms.Button();
            this.txtJsDir = new System.Windows.Forms.TextBox();
            this.lblJsDir = new System.Windows.Forms.Label();
            this.btnCreateJs = new System.Windows.Forms.Button();
            this.gboxConString.SuspendLayout();
            this.gboxTableName.SuspendLayout();
            this.gboxFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFields)).BeginInit();
            this.gboxCreateParam.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxConString
            // 
            this.gboxConString.Controls.Add(this.txtDbName);
            this.gboxConString.Controls.Add(this.lblDbName);
            this.gboxConString.Controls.Add(this.btnConnectServer);
            this.gboxConString.Controls.Add(this.txtServer);
            this.gboxConString.Controls.Add(this.lblDbServer);
            this.gboxConString.Controls.Add(this.txtPwd);
            this.gboxConString.Controls.Add(this.lblPwd);
            this.gboxConString.Controls.Add(this.txtUserName);
            this.gboxConString.Controls.Add(this.lblUserName);
            this.gboxConString.Location = new System.Drawing.Point(19, 13);
            this.gboxConString.Name = "gboxConString";
            this.gboxConString.Size = new System.Drawing.Size(492, 85);
            this.gboxConString.TabIndex = 1;
            this.gboxConString.TabStop = false;
            this.gboxConString.Text = "数据库连接参数";
            // 
            // txtDbName
            // 
            this.txtDbName.Location = new System.Drawing.Point(272, 23);
            this.txtDbName.Name = "txtDbName";
            this.txtDbName.Size = new System.Drawing.Size(100, 21);
            this.txtDbName.TabIndex = 8;
            this.txtDbName.Text = "sdfz_develop";
            // 
            // lblDbName
            // 
            this.lblDbName.AutoSize = true;
            this.lblDbName.Location = new System.Drawing.Point(219, 28);
            this.lblDbName.Name = "lblDbName";
            this.lblDbName.Size = new System.Drawing.Size(53, 12);
            this.lblDbName.TabIndex = 7;
            this.lblDbName.Text = "数据库：";
            this.lblDbName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnConnectServer
            // 
            this.btnConnectServer.Location = new System.Drawing.Point(395, 37);
            this.btnConnectServer.Name = "btnConnectServer";
            this.btnConnectServer.Size = new System.Drawing.Size(75, 23);
            this.btnConnectServer.TabIndex = 6;
            this.btnConnectServer.Text = "连接";
            this.btnConnectServer.UseVisualStyleBackColor = true;
            this.btnConnectServer.Click += new System.EventHandler(this.btnConnectServer_Click);
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(106, 23);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(100, 21);
            this.txtServer.TabIndex = 5;
            this.txtServer.Text = "(local)";
            // 
            // lblDbServer
            // 
            this.lblDbServer.AutoSize = true;
            this.lblDbServer.Location = new System.Drawing.Point(15, 28);
            this.lblDbServer.Name = "lblDbServer";
            this.lblDbServer.Size = new System.Drawing.Size(89, 12);
            this.lblDbServer.TabIndex = 4;
            this.lblDbServer.Text = "数据库服务器：";
            this.lblDbServer.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(271, 55);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(100, 21);
            this.txtPwd.TabIndex = 3;
            this.txtPwd.Text = "sql2008";
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(222, 60);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(47, 12);
            this.lblPwd.TabIndex = 2;
            this.lblPwd.Text = "密 码：";
            this.lblPwd.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(106, 55);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 21);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Text = "sa";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(57, 60);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(53, 12);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "用户名：";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // gboxTableName
            // 
            this.gboxTableName.Controls.Add(this.listViewTableName);
            this.gboxTableName.Location = new System.Drawing.Point(19, 105);
            this.gboxTableName.Name = "gboxTableName";
            this.gboxTableName.Size = new System.Drawing.Size(492, 706);
            this.gboxTableName.TabIndex = 2;
            this.gboxTableName.TabStop = false;
            this.gboxTableName.Text = "数据表";
            // 
            // listViewTableName
            // 
            this.listViewTableName.Location = new System.Drawing.Point(6, 20);
            this.listViewTableName.Name = "listViewTableName";
            this.listViewTableName.Size = new System.Drawing.Size(480, 680);
            this.listViewTableName.TabIndex = 0;
            this.listViewTableName.UseCompatibleStateImageBehavior = false;
            this.listViewTableName.View = System.Windows.Forms.View.List;
            this.listViewTableName.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewTableName_ItemSelectionChanged);
            // 
            // gboxFields
            // 
            this.gboxFields.Controls.Add(this.gridFields);
            this.gboxFields.Location = new System.Drawing.Point(527, 226);
            this.gboxFields.Name = "gboxFields";
            this.gboxFields.Size = new System.Drawing.Size(915, 579);
            this.gboxFields.TabIndex = 3;
            this.gboxFields.TabStop = false;
            this.gboxFields.Text = "表字段";
            // 
            // gridFields
            // 
            this.gridFields.AllowUserToAddRows = false;
            this.gridFields.AllowUserToDeleteRows = false;
            this.gridFields.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFields.Location = new System.Drawing.Point(7, 20);
            this.gridFields.Name = "gridFields";
            this.gridFields.RowTemplate.Height = 23;
            this.gridFields.Size = new System.Drawing.Size(902, 532);
            this.gridFields.TabIndex = 0;
            this.gridFields.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFields_CellClick);
            // 
            // txtColName
            // 
            this.txtColName.Location = new System.Drawing.Point(64, 20);
            this.txtColName.Name = "txtColName";
            this.txtColName.Size = new System.Drawing.Size(120, 21);
            this.txtColName.TabIndex = 7;
            // 
            // lblColName
            // 
            this.lblColName.AutoSize = true;
            this.lblColName.Location = new System.Drawing.Point(17, 25);
            this.lblColName.Name = "lblColName";
            this.lblColName.Size = new System.Drawing.Size(53, 12);
            this.lblColName.TabIndex = 6;
            this.lblColName.Text = "列名称：";
            // 
            // txtOrderIndex
            // 
            this.txtOrderIndex.Location = new System.Drawing.Point(259, 20);
            this.txtOrderIndex.Name = "txtOrderIndex";
            this.txtOrderIndex.Size = new System.Drawing.Size(120, 21);
            this.txtOrderIndex.TabIndex = 13;
            // 
            // lblOrderIndex
            // 
            this.lblOrderIndex.AutoSize = true;
            this.lblOrderIndex.Location = new System.Drawing.Point(212, 25);
            this.lblOrderIndex.Name = "lblOrderIndex";
            this.lblOrderIndex.Size = new System.Drawing.Size(53, 12);
            this.lblOrderIndex.TabIndex = 12;
            this.lblOrderIndex.Text = "顺序号：";
            // 
            // lblInputType
            // 
            this.lblInputType.AutoSize = true;
            this.lblInputType.Location = new System.Drawing.Point(405, 25);
            this.lblInputType.Name = "lblInputType";
            this.lblInputType.Size = new System.Drawing.Size(65, 12);
            this.lblInputType.TabIndex = 16;
            this.lblInputType.Text = "输入方式：";
            // 
            // txtDicCode
            // 
            this.txtDicCode.Location = new System.Drawing.Point(646, 19);
            this.txtDicCode.Name = "txtDicCode";
            this.txtDicCode.Size = new System.Drawing.Size(120, 21);
            this.txtDicCode.TabIndex = 19;
            // 
            // lblDicCode
            // 
            this.lblDicCode.AutoSize = true;
            this.lblDicCode.Location = new System.Drawing.Point(599, 24);
            this.lblDicCode.Name = "lblDicCode";
            this.lblDicCode.Size = new System.Drawing.Size(53, 12);
            this.lblDicCode.TabIndex = 18;
            this.lblDicCode.Text = "输入码：";
            // 
            // cmbboxInputType
            // 
            this.cmbboxInputType.FormattingEnabled = true;
            this.cmbboxInputType.Items.AddRange(new object[] {
            "手工输入",
            "数据字典"});
            this.cmbboxInputType.Location = new System.Drawing.Point(462, 20);
            this.cmbboxInputType.Name = "cmbboxInputType";
            this.cmbboxInputType.Size = new System.Drawing.Size(120, 20);
            this.cmbboxInputType.TabIndex = 22;
            // 
            // chkColGrid
            // 
            this.chkColGrid.AutoSize = true;
            this.chkColGrid.Location = new System.Drawing.Point(97, 51);
            this.chkColGrid.Name = "chkColGrid";
            this.chkColGrid.Size = new System.Drawing.Size(36, 16);
            this.chkColGrid.TabIndex = 25;
            this.chkColGrid.Text = "是";
            this.chkColGrid.UseVisualStyleBackColor = true;
            // 
            // lblColGrid
            // 
            this.lblColGrid.AutoSize = true;
            this.lblColGrid.Location = new System.Drawing.Point(17, 53);
            this.lblColGrid.Name = "lblColGrid";
            this.lblColGrid.Size = new System.Drawing.Size(77, 12);
            this.lblColGrid.TabIndex = 24;
            this.lblColGrid.Text = "列  表  列：";
            // 
            // chkEQuery
            // 
            this.chkEQuery.AutoSize = true;
            this.chkEQuery.Location = new System.Drawing.Point(422, 53);
            this.chkEQuery.Name = "chkEQuery";
            this.chkEQuery.Size = new System.Drawing.Size(36, 16);
            this.chkEQuery.TabIndex = 29;
            this.chkEQuery.Text = "是";
            this.chkEQuery.UseVisualStyleBackColor = true;
            // 
            // lblEQuery
            // 
            this.lblEQuery.AutoSize = true;
            this.lblEQuery.Location = new System.Drawing.Point(347, 55);
            this.lblEQuery.Name = "lblEQuery";
            this.lblEQuery.Size = new System.Drawing.Size(77, 12);
            this.lblEQuery.TabIndex = 28;
            this.lblEQuery.Text = "高级查询列：";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(284, 53);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(36, 16);
            this.checkBox3.TabIndex = 27;
            this.checkBox3.Text = "是";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // lblQQuery
            // 
            this.lblQQuery.AutoSize = true;
            this.lblQQuery.Location = new System.Drawing.Point(209, 55);
            this.lblQQuery.Name = "lblQQuery";
            this.lblQQuery.Size = new System.Drawing.Size(77, 12);
            this.lblQQuery.TabIndex = 26;
            this.lblQQuery.Text = "快速查询列：";
            // 
            // lblColDesc
            // 
            this.lblColDesc.AutoSize = true;
            this.lblColDesc.Location = new System.Drawing.Point(475, 53);
            this.lblColDesc.Name = "lblColDesc";
            this.lblColDesc.Size = new System.Drawing.Size(53, 12);
            this.lblColDesc.TabIndex = 34;
            this.lblColDesc.Text = "列说明：";
            // 
            // txtColDesc
            // 
            this.txtColDesc.Location = new System.Drawing.Point(522, 48);
            this.txtColDesc.Name = "txtColDesc";
            this.txtColDesc.Size = new System.Drawing.Size(387, 21);
            this.txtColDesc.TabIndex = 35;
            // 
            // btnSaveField
            // 
            this.btnSaveField.Location = new System.Drawing.Point(794, 17);
            this.btnSaveField.Name = "btnSaveField";
            this.btnSaveField.Size = new System.Drawing.Size(75, 23);
            this.btnSaveField.TabIndex = 36;
            this.btnSaveField.Text = "保  存";
            this.btnSaveField.UseVisualStyleBackColor = true;
            this.btnSaveField.Click += new System.EventHandler(this.btnSaveField_Click);
            // 
            // gboxCreateParam
            // 
            this.gboxCreateParam.Controls.Add(this.btnSelectJsDir);
            this.gboxCreateParam.Controls.Add(this.txtJsDir);
            this.gboxCreateParam.Controls.Add(this.lblJsDir);
            this.gboxCreateParam.Controls.Add(this.txtUUID);
            this.gboxCreateParam.Controls.Add(this.btnSelectJsTTDir);
            this.gboxCreateParam.Controls.Add(this.btnCreateJs);
            this.gboxCreateParam.Controls.Add(this.btnSelectJavaTTDir);
            this.gboxCreateParam.Controls.Add(this.txtJsTemplateDir);
            this.gboxCreateParam.Controls.Add(this.txtJavaTemplateDir);
            this.gboxCreateParam.Controls.Add(this.lblJavaTemplate);
            this.gboxCreateParam.Controls.Add(this.lblJsTemplate);
            this.gboxCreateParam.Controls.Add(this.btnCreateJava);
            this.gboxCreateParam.Controls.Add(this.btnSelectProjectDir);
            this.gboxCreateParam.Controls.Add(this.txtProjectDir);
            this.gboxCreateParam.Controls.Add(this.lblProjectDir);
            this.gboxCreateParam.Controls.Add(this.txtMenuConfig);
            this.gboxCreateParam.Controls.Add(this.lblMenuConfig);
            this.gboxCreateParam.Location = new System.Drawing.Point(520, 14);
            this.gboxCreateParam.Name = "gboxCreateParam";
            this.gboxCreateParam.Size = new System.Drawing.Size(916, 104);
            this.gboxCreateParam.TabIndex = 37;
            this.gboxCreateParam.TabStop = false;
            // 
            // txtUUID
            // 
            this.txtUUID.Location = new System.Drawing.Point(559, 75);
            this.txtUUID.Name = "txtUUID";
            this.txtUUID.Size = new System.Drawing.Size(100, 21);
            this.txtUUID.TabIndex = 37;
            this.txtUUID.Visible = false;
            // 
            // btnSelectJsTTDir
            // 
            this.btnSelectJsTTDir.Location = new System.Drawing.Point(624, 46);
            this.btnSelectJsTTDir.Name = "btnSelectJsTTDir";
            this.btnSelectJsTTDir.Size = new System.Drawing.Size(64, 23);
            this.btnSelectJsTTDir.TabIndex = 14;
            this.btnSelectJsTTDir.Text = "目录选择";
            this.btnSelectJsTTDir.UseVisualStyleBackColor = true;
            this.btnSelectJsTTDir.Click += new System.EventHandler(this.btnSelectJsTTDir_Click);
            // 
            // btnSelectJavaTTDir
            // 
            this.btnSelectJavaTTDir.Location = new System.Drawing.Point(624, 21);
            this.btnSelectJavaTTDir.Name = "btnSelectJavaTTDir";
            this.btnSelectJavaTTDir.Size = new System.Drawing.Size(64, 23);
            this.btnSelectJavaTTDir.TabIndex = 12;
            this.btnSelectJavaTTDir.Text = "目录选择";
            this.btnSelectJavaTTDir.UseVisualStyleBackColor = true;
            this.btnSelectJavaTTDir.Click += new System.EventHandler(this.btnSelectJavaTTDir_Click);
            // 
            // txtJsTemplateDir
            // 
            this.txtJsTemplateDir.Location = new System.Drawing.Point(446, 46);
            this.txtJsTemplateDir.Name = "txtJsTemplateDir";
            this.txtJsTemplateDir.Size = new System.Drawing.Size(172, 21);
            this.txtJsTemplateDir.TabIndex = 11;
            // 
            // txtJavaTemplateDir
            // 
            this.txtJavaTemplateDir.Location = new System.Drawing.Point(446, 20);
            this.txtJavaTemplateDir.Name = "txtJavaTemplateDir";
            this.txtJavaTemplateDir.Size = new System.Drawing.Size(172, 21);
            this.txtJavaTemplateDir.TabIndex = 10;
            this.txtJavaTemplateDir.Text = "e:\\netCode\\generateCode\\FrmGenerate\\Template\\";
            // 
            // lblJavaTemplate
            // 
            this.lblJavaTemplate.AutoSize = true;
            this.lblJavaTemplate.Location = new System.Drawing.Point(384, 26);
            this.lblJavaTemplate.Name = "lblJavaTemplate";
            this.lblJavaTemplate.Size = new System.Drawing.Size(65, 12);
            this.lblJavaTemplate.TabIndex = 9;
            this.lblJavaTemplate.Text = "JAVA模板：";
            this.lblJavaTemplate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblJsTemplate
            // 
            this.lblJsTemplate.AutoSize = true;
            this.lblJsTemplate.Location = new System.Drawing.Point(396, 53);
            this.lblJsTemplate.Name = "lblJsTemplate";
            this.lblJsTemplate.Size = new System.Drawing.Size(53, 12);
            this.lblJsTemplate.TabIndex = 8;
            this.lblJsTemplate.Text = "JS模板：";
            this.lblJsTemplate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnCreateJava
            // 
            this.btnCreateJava.Location = new System.Drawing.Point(801, 20);
            this.btnCreateJava.Name = "btnCreateJava";
            this.btnCreateJava.Size = new System.Drawing.Size(101, 23);
            this.btnCreateJava.TabIndex = 7;
            this.btnCreateJava.Text = "生成JAVA代码";
            this.btnCreateJava.UseVisualStyleBackColor = true;
            this.btnCreateJava.Click += new System.EventHandler(this.btnCreateJava_Click);
            // 
            // btnSelectProjectDir
            // 
            this.btnSelectProjectDir.Location = new System.Drawing.Point(297, 21);
            this.btnSelectProjectDir.Name = "btnSelectProjectDir";
            this.btnSelectProjectDir.Size = new System.Drawing.Size(75, 23);
            this.btnSelectProjectDir.TabIndex = 6;
            this.btnSelectProjectDir.Text = "目录选择";
            this.btnSelectProjectDir.UseVisualStyleBackColor = true;
            this.btnSelectProjectDir.Click += new System.EventHandler(this.btnSelectProjectDir_Click);
            // 
            // txtProjectDir
            // 
            this.txtProjectDir.Location = new System.Drawing.Point(78, 23);
            this.txtProjectDir.Name = "txtProjectDir";
            this.txtProjectDir.Size = new System.Drawing.Size(213, 21);
            this.txtProjectDir.TabIndex = 5;
            this.txtProjectDir.Text = "e:\\temp\\";
            // 
            // lblProjectDir
            // 
            this.lblProjectDir.AutoSize = true;
            this.lblProjectDir.Location = new System.Drawing.Point(15, 28);
            this.lblProjectDir.Name = "lblProjectDir";
            this.lblProjectDir.Size = new System.Drawing.Size(65, 12);
            this.lblProjectDir.TabIndex = 4;
            this.lblProjectDir.Text = "工程目录：";
            this.lblProjectDir.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtMenuConfig
            // 
            this.txtMenuConfig.Location = new System.Drawing.Point(78, 75);
            this.txtMenuConfig.Name = "txtMenuConfig";
            this.txtMenuConfig.Size = new System.Drawing.Size(294, 21);
            this.txtMenuConfig.TabIndex = 1;
            this.txtMenuConfig.Text = "salary.salaryitem";
            // 
            // lblMenuConfig
            // 
            this.lblMenuConfig.AutoSize = true;
            this.lblMenuConfig.Location = new System.Drawing.Point(16, 80);
            this.lblMenuConfig.Name = "lblMenuConfig";
            this.lblMenuConfig.Size = new System.Drawing.Size(65, 12);
            this.lblMenuConfig.TabIndex = 0;
            this.lblMenuConfig.Text = "模块配置：";
            this.lblMenuConfig.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // fbDialogDir
            // 
            this.fbDialogDir.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.fbDialogDir.SelectedPath = "E:\\";
            this.fbDialogDir.ShowNewFolderButton = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtColName);
            this.groupBox1.Controls.Add(this.lblColName);
            this.groupBox1.Controls.Add(this.btnSaveField);
            this.groupBox1.Controls.Add(this.txtOrderIndex);
            this.groupBox1.Controls.Add(this.txtColDesc);
            this.groupBox1.Controls.Add(this.lblOrderIndex);
            this.groupBox1.Controls.Add(this.lblColDesc);
            this.groupBox1.Controls.Add(this.cmbboxInputType);
            this.groupBox1.Controls.Add(this.chkEQuery);
            this.groupBox1.Controls.Add(this.lblInputType);
            this.groupBox1.Controls.Add(this.lblEQuery);
            this.groupBox1.Controls.Add(this.txtDicCode);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.lblDicCode);
            this.groupBox1.Controls.Add(this.lblQQuery);
            this.groupBox1.Controls.Add(this.lblColGrid);
            this.groupBox1.Controls.Add(this.chkColGrid);
            this.groupBox1.Location = new System.Drawing.Point(527, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(915, 81);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "字段调整";
            // 
            // btnSelectJsDir
            // 
            this.btnSelectJsDir.Location = new System.Drawing.Point(297, 48);
            this.btnSelectJsDir.Name = "btnSelectJsDir";
            this.btnSelectJsDir.Size = new System.Drawing.Size(75, 23);
            this.btnSelectJsDir.TabIndex = 40;
            this.btnSelectJsDir.Text = "目录选择";
            this.btnSelectJsDir.UseVisualStyleBackColor = true;
            this.btnSelectJsDir.Click += new System.EventHandler(this.btnSelectJsDir_Click);
            // 
            // txtJsDir
            // 
            this.txtJsDir.Location = new System.Drawing.Point(78, 50);
            this.txtJsDir.Name = "txtJsDir";
            this.txtJsDir.Size = new System.Drawing.Size(213, 21);
            this.txtJsDir.TabIndex = 39;
            this.txtJsDir.Text = "e:\\javaCode\\sdfz_develop\\school-web\\src\\main\\webapp\\static\\core\\coreApp";
            // 
            // lblJsDir
            // 
            this.lblJsDir.AutoSize = true;
            this.lblJsDir.Location = new System.Drawing.Point(26, 55);
            this.lblJsDir.Name = "lblJsDir";
            this.lblJsDir.Size = new System.Drawing.Size(53, 12);
            this.lblJsDir.TabIndex = 38;
            this.lblJsDir.Text = "JS目录：";
            this.lblJsDir.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnCreateJs
            // 
            this.btnCreateJs.Location = new System.Drawing.Point(801, 45);
            this.btnCreateJs.Name = "btnCreateJs";
            this.btnCreateJs.Size = new System.Drawing.Size(101, 23);
            this.btnCreateJs.TabIndex = 13;
            this.btnCreateJs.Text = "生成JS代码";
            this.btnCreateJs.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1465, 823);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gboxCreateParam);
            this.Controls.Add(this.gboxFields);
            this.Controls.Add(this.gboxTableName);
            this.Controls.Add(this.gboxConString);
            this.Name = "FrmMain";
            this.Text = "代码生成器";
            this.gboxConString.ResumeLayout(false);
            this.gboxConString.PerformLayout();
            this.gboxTableName.ResumeLayout(false);
            this.gboxFields.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridFields)).EndInit();
            this.gboxCreateParam.ResumeLayout(false);
            this.gboxCreateParam.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gboxConString;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnConnectServer;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label lblDbServer;
        private System.Windows.Forms.TextBox txtDbName;
        private System.Windows.Forms.Label lblDbName;
        private System.Windows.Forms.GroupBox gboxTableName;
        private System.Windows.Forms.ListView listViewTableName;
        private System.Windows.Forms.GroupBox gboxFields;
        private System.Windows.Forms.DataGridView gridFields;
        private System.Windows.Forms.TextBox txtColName;
        private System.Windows.Forms.Label lblColName;
        private System.Windows.Forms.TextBox txtOrderIndex;
        private System.Windows.Forms.Label lblOrderIndex;
        private System.Windows.Forms.Label lblInputType;
        private System.Windows.Forms.TextBox txtDicCode;
        private System.Windows.Forms.Label lblDicCode;
        private System.Windows.Forms.ComboBox cmbboxInputType;
        private System.Windows.Forms.CheckBox chkColGrid;
        private System.Windows.Forms.Label lblColGrid;
        private System.Windows.Forms.CheckBox chkEQuery;
        private System.Windows.Forms.Label lblEQuery;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label lblQQuery;
        private System.Windows.Forms.Label lblColDesc;
        private System.Windows.Forms.TextBox txtColDesc;
        private System.Windows.Forms.Button btnSaveField;
        private System.Windows.Forms.GroupBox gboxCreateParam;
        private System.Windows.Forms.Label lblJavaTemplate;
        private System.Windows.Forms.Label lblJsTemplate;
        private System.Windows.Forms.Button btnCreateJava;
        private System.Windows.Forms.Button btnSelectProjectDir;
        private System.Windows.Forms.TextBox txtProjectDir;
        private System.Windows.Forms.Label lblProjectDir;
        private System.Windows.Forms.TextBox txtMenuConfig;
        private System.Windows.Forms.Label lblMenuConfig;
        private System.Windows.Forms.Button btnSelectJsTTDir;
        private System.Windows.Forms.Button btnSelectJavaTTDir;
        private System.Windows.Forms.TextBox txtJsTemplateDir;
        private System.Windows.Forms.TextBox txtJavaTemplateDir;
        private System.Windows.Forms.FolderBrowserDialog fbDialogDir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtUUID;
        private System.Windows.Forms.Button btnSelectJsDir;
        private System.Windows.Forms.TextBox txtJsDir;
        private System.Windows.Forms.Label lblJsDir;
        private System.Windows.Forms.Button btnCreateJs;
    }
}