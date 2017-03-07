namespace GenerateCode
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserPwd = new System.Windows.Forms.Label();
            this.txtUserPwd = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtDbName = new System.Windows.Forms.TextBox();
            this.lblDbName = new System.Windows.Forms.Label();
            this.lvTabeleName = new System.Windows.Forms.ListView();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProjectDir = new System.Windows.Forms.TextBox();
            this.txtModelTwo = new System.Windows.Forms.TextBox();
            this.lblModelTwo = new System.Windows.Forms.Label();
            this.lboxInfo = new System.Windows.Forms.ListBox();
            this.txtModelOne = new System.Windows.Forms.TextBox();
            this.lblModelOne = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtJsName = new System.Windows.Forms.TextBox();
            this.lblJsMode = new System.Windows.Forms.Label();
            this.btnCreateAfter = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(13, 13);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(89, 12);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "数据库用户名：";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(109, 3);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 21);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Text = "sa";
            // 
            // lblUserPwd
            // 
            this.lblUserPwd.AutoSize = true;
            this.lblUserPwd.Location = new System.Drawing.Point(780, 20);
            this.lblUserPwd.Name = "lblUserPwd";
            this.lblUserPwd.Size = new System.Drawing.Size(71, 12);
            this.lblUserPwd.TabIndex = 2;
            this.lblUserPwd.Text = "数据库密码:";
            // 
            // txtUserPwd
            // 
            this.txtUserPwd.Location = new System.Drawing.Point(857, 16);
            this.txtUserPwd.Name = "txtUserPwd";
            this.txtUserPwd.Size = new System.Drawing.Size(100, 21);
            this.txtUserPwd.TabIndex = 3;
            this.txtUserPwd.Text = "sql2008";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(1142, 9);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "连 接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtDbName
            // 
            this.txtDbName.Location = new System.Drawing.Point(1031, 13);
            this.txtDbName.Name = "txtDbName";
            this.txtDbName.Size = new System.Drawing.Size(100, 21);
            this.txtDbName.TabIndex = 6;
            this.txtDbName.Text = "dbZsdx_develop";
            // 
            // lblDbName
            // 
            this.lblDbName.AutoSize = true;
            this.lblDbName.Location = new System.Drawing.Point(966, 20);
            this.lblDbName.Name = "lblDbName";
            this.lblDbName.Size = new System.Drawing.Size(59, 12);
            this.lblDbName.TabIndex = 5;
            this.lblDbName.Text = "数据库名:";
            // 
            // lvTabeleName
            // 
            this.lvTabeleName.CheckBoxes = true;
            this.lvTabeleName.FullRowSelect = true;
            this.lvTabeleName.Location = new System.Drawing.Point(12, 30);
            this.lvTabeleName.Name = "lvTabeleName";
            this.lvTabeleName.Size = new System.Drawing.Size(561, 574);
            this.lvTabeleName.TabIndex = 7;
            this.lvTabeleName.UseCompatibleStateImageBehavior = false;
            this.lvTabeleName.View = System.Windows.Forms.View.List;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(1031, 49);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 8;
            this.btnCreate.Text = "生成前端";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(943, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 27;
            this.label7.Text = "项目目录：";
            // 
            // txtProjectDir
            // 
            this.txtProjectDir.Location = new System.Drawing.Point(1014, 85);
            this.txtProjectDir.Name = "txtProjectDir";
            this.txtProjectDir.Size = new System.Drawing.Size(203, 21);
            this.txtProjectDir.TabIndex = 26;
            this.txtProjectDir.Text = "e:\\javacode\\zsdx_develop\\";
            // 
            // txtModelTwo
            // 
            this.txtModelTwo.Location = new System.Drawing.Point(657, 81);
            this.txtModelTwo.Name = "txtModelTwo";
            this.txtModelTwo.Size = new System.Drawing.Size(258, 21);
            this.txtModelTwo.TabIndex = 25;
            this.txtModelTwo.Text = "salary";
            // 
            // lblModelTwo
            // 
            this.lblModelTwo.AutoSize = true;
            this.lblModelTwo.Location = new System.Drawing.Point(579, 86);
            this.lblModelTwo.Name = "lblModelTwo";
            this.lblModelTwo.Size = new System.Drawing.Size(65, 12);
            this.lblModelTwo.TabIndex = 24;
            this.lblModelTwo.Text = "二级模块：";
            // 
            // lboxInfo
            // 
            this.lboxInfo.FormattingEnabled = true;
            this.lboxInfo.ItemHeight = 12;
            this.lboxInfo.Location = new System.Drawing.Point(581, 184);
            this.lboxInfo.Name = "lboxInfo";
            this.lboxInfo.Size = new System.Drawing.Size(636, 328);
            this.lboxInfo.TabIndex = 28;
            // 
            // txtModelOne
            // 
            this.txtModelOne.Location = new System.Drawing.Point(657, 51);
            this.txtModelOne.Name = "txtModelOne";
            this.txtModelOne.Size = new System.Drawing.Size(258, 21);
            this.txtModelOne.TabIndex = 30;
            this.txtModelOne.Text = "salary";
            // 
            // lblModelOne
            // 
            this.lblModelOne.AutoSize = true;
            this.lblModelOne.Location = new System.Drawing.Point(579, 56);
            this.lblModelOne.Name = "lblModelOne";
            this.lblModelOne.Size = new System.Drawing.Size(65, 12);
            this.lblModelOne.TabIndex = 29;
            this.lblModelOne.Text = "一级模块：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(593, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "服务器：";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(637, 12);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(137, 21);
            this.txtServer.TabIndex = 32;
            this.txtServer.Text = "(local)";
            // 
            // txtJsName
            // 
            this.txtJsName.Location = new System.Drawing.Point(657, 108);
            this.txtJsName.Name = "txtJsName";
            this.txtJsName.Size = new System.Drawing.Size(258, 21);
            this.txtJsName.TabIndex = 34;
            this.txtJsName.Text = "salaryitem";
            // 
            // lblJsMode
            // 
            this.lblJsMode.AutoSize = true;
            this.lblJsMode.Location = new System.Drawing.Point(579, 113);
            this.lblJsMode.Name = "lblJsMode";
            this.lblJsMode.Size = new System.Drawing.Size(53, 12);
            this.lblJsMode.TabIndex = 33;
            this.lblJsMode.Text = "Js模块：";
            // 
            // btnCreateAfter
            // 
            this.btnCreateAfter.Location = new System.Drawing.Point(945, 51);
            this.btnCreateAfter.Name = "btnCreateAfter";
            this.btnCreateAfter.Size = new System.Drawing.Size(75, 23);
            this.btnCreateAfter.TabIndex = 35;
            this.btnCreateAfter.Text = "生成后端";
            this.btnCreateAfter.UseVisualStyleBackColor = true;
            this.btnCreateAfter.Click += new System.EventHandler(this.btnCreateAfter_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1125, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 36;
            this.button1.Text = "生成新前端";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 616);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCreateAfter);
            this.Controls.Add(this.txtJsName);
            this.Controls.Add(this.lblJsMode);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtModelOne);
            this.Controls.Add(this.lblModelOne);
            this.Controls.Add(this.lboxInfo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtProjectDir);
            this.Controls.Add(this.txtModelTwo);
            this.Controls.Add(this.lblModelTwo);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lvTabeleName);
            this.Controls.Add(this.txtDbName);
            this.Controls.Add(this.lblDbName);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtUserPwd);
            this.Controls.Add(this.lblUserPwd);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUserName);
            this.Name = "frmMain";
            this.Text = "代码生成参数设置";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserPwd;
        private System.Windows.Forms.TextBox txtUserPwd;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtDbName;
        private System.Windows.Forms.Label lblDbName;
        private System.Windows.Forms.ListView lvTabeleName;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtProjectDir;
        private System.Windows.Forms.TextBox txtModelTwo;
        private System.Windows.Forms.Label lblModelTwo;
        private System.Windows.Forms.ListBox lboxInfo;
        private System.Windows.Forms.TextBox txtModelOne;
        private System.Windows.Forms.Label lblModelOne;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtJsName;
        private System.Windows.Forms.Label lblJsMode;
        private System.Windows.Forms.Button btnCreateAfter;
        private System.Windows.Forms.Button button1;
    }
}

