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
            this.txtModuleCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lboxInfo = new System.Windows.Forms.ListBox();
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
            this.lblUserPwd.Location = new System.Drawing.Point(235, 11);
            this.lblUserPwd.Name = "lblUserPwd";
            this.lblUserPwd.Size = new System.Drawing.Size(71, 12);
            this.lblUserPwd.TabIndex = 2;
            this.lblUserPwd.Text = "数据库密码:";
            // 
            // txtUserPwd
            // 
            this.txtUserPwd.Location = new System.Drawing.Point(313, 3);
            this.txtUserPwd.Name = "txtUserPwd";
            this.txtUserPwd.Size = new System.Drawing.Size(100, 21);
            this.txtUserPwd.TabIndex = 3;
            this.txtUserPwd.Text = "sql2008";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(626, 2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "连 接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtDbName
            // 
            this.txtDbName.Location = new System.Drawing.Point(511, 3);
            this.txtDbName.Name = "txtDbName";
            this.txtDbName.Size = new System.Drawing.Size(100, 21);
            this.txtDbName.TabIndex = 6;
            this.txtDbName.Text = "dbStudy";
            // 
            // lblDbName
            // 
            this.lblDbName.AutoSize = true;
            this.lblDbName.Location = new System.Drawing.Point(433, 11);
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
            this.lvTabeleName.Size = new System.Drawing.Size(213, 574);
            this.lvTabeleName.TabIndex = 7;
            this.lvTabeleName.UseCompatibleStateImageBehavior = false;
            this.lvTabeleName.View = System.Windows.Forms.View.List;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(732, 3);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 8;
            this.btnCreate.Text = "生 成";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(574, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 27;
            this.label7.Text = "项目目录：";
            // 
            // txtProjectDir
            // 
            this.txtProjectDir.Location = new System.Drawing.Point(682, 43);
            this.txtProjectDir.Name = "txtProjectDir";
            this.txtProjectDir.Size = new System.Drawing.Size(246, 21);
            this.txtProjectDir.TabIndex = 26;
            this.txtProjectDir.Text = "e:\\temp\\jw\\";
            // 
            // txtModuleCode
            // 
            this.txtModuleCode.Location = new System.Drawing.Point(313, 45);
            this.txtModuleCode.Name = "txtModuleCode";
            this.txtModuleCode.Size = new System.Drawing.Size(258, 21);
            this.txtModuleCode.TabIndex = 25;
            this.txtModuleCode.Text = "eduresources";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(235, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 24;
            this.label8.Text = "模块编码：";
            // 
            // lboxInfo
            // 
            this.lboxInfo.FormattingEnabled = true;
            this.lboxInfo.ItemHeight = 12;
            this.lboxInfo.Location = new System.Drawing.Point(237, 81);
            this.lboxInfo.Name = "lboxInfo";
            this.lboxInfo.Size = new System.Drawing.Size(691, 520);
            this.lboxInfo.TabIndex = 28;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 616);
            this.Controls.Add(this.lboxInfo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtProjectDir);
            this.Controls.Add(this.txtModuleCode);
            this.Controls.Add(this.label8);
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
        private System.Windows.Forms.TextBox txtModuleCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lboxInfo;
    }
}

