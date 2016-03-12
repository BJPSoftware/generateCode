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
            this.rtboxView = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtModelPackage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtModelMainDir = new System.Windows.Forms.TextBox();
            this.txtDaoMainDir = new System.Windows.Forms.TextBox();
            this.txtDaoPackageName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtServiceMainDir = new System.Windows.Forms.TextBox();
            this.txtServerPackageName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
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
            this.txtDbName.Text = "schooljw";
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
            // rtboxView
            // 
            this.rtboxView.Location = new System.Drawing.Point(237, 113);
            this.rtboxView.Name = "rtboxView";
            this.rtboxView.Size = new System.Drawing.Size(693, 491);
            this.rtboxView.TabIndex = 11;
            this.rtboxView.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(237, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "实体包名：";
            // 
            // txtModelPackage
            // 
            this.txtModelPackage.Location = new System.Drawing.Point(315, 34);
            this.txtModelPackage.Name = "txtModelPackage";
            this.txtModelPackage.Size = new System.Drawing.Size(258, 21);
            this.txtModelPackage.TabIndex = 13;
            this.txtModelPackage.Text = "com.zd.school.jw.model.eduresources";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(576, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "实体主目录名：";
            // 
            // txtModelMainDir
            // 
            this.txtModelMainDir.Location = new System.Drawing.Point(684, 31);
            this.txtModelMainDir.Name = "txtModelMainDir";
            this.txtModelMainDir.Size = new System.Drawing.Size(246, 21);
            this.txtModelMainDir.TabIndex = 15;
            this.txtModelMainDir.Text = "e:\\workspace\\jw\\jw-model\\src\\main\\java\\";
            // 
            // txtDaoMainDir
            // 
            this.txtDaoMainDir.Location = new System.Drawing.Point(684, 59);
            this.txtDaoMainDir.Name = "txtDaoMainDir";
            this.txtDaoMainDir.Size = new System.Drawing.Size(246, 21);
            this.txtDaoMainDir.TabIndex = 18;
            this.txtDaoMainDir.Text = "e:\\workspace\\jw\\jw-dao\\src\\main\\java\\";
            // 
            // txtDaoPackageName
            // 
            this.txtDaoPackageName.Location = new System.Drawing.Point(315, 61);
            this.txtDaoPackageName.Name = "txtDaoPackageName";
            this.txtDaoPackageName.Size = new System.Drawing.Size(258, 21);
            this.txtDaoPackageName.TabIndex = 17;
            this.txtDaoPackageName.Text = "com.zd.school.jw.dao.eduresources";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "dao包名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(576, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "dao主目录名：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(576, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "service主目录名：";
            // 
            // txtServiceMainDir
            // 
            this.txtServiceMainDir.Location = new System.Drawing.Point(684, 86);
            this.txtServiceMainDir.Name = "txtServiceMainDir";
            this.txtServiceMainDir.Size = new System.Drawing.Size(246, 21);
            this.txtServiceMainDir.TabIndex = 22;
            this.txtServiceMainDir.Text = "e:\\workspace\\jw\\jw-service\\src\\main\\java\\";
            // 
            // txtServerPackageName
            // 
            this.txtServerPackageName.Location = new System.Drawing.Point(315, 88);
            this.txtServerPackageName.Name = "txtServerPackageName";
            this.txtServerPackageName.Size = new System.Drawing.Size(258, 21);
            this.txtServerPackageName.TabIndex = 21;
            this.txtServerPackageName.Text = "com.zd.school.jw.service.eduresources";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(237, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "service包名：";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 616);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtServiceMainDir);
            this.Controls.Add(this.txtServerPackageName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDaoMainDir);
            this.Controls.Add(this.txtDaoPackageName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtModelMainDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtModelPackage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtboxView);
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
        private System.Windows.Forms.RichTextBox rtboxView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtModelPackage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtModelMainDir;
        private System.Windows.Forms.TextBox txtDaoMainDir;
        private System.Windows.Forms.TextBox txtDaoPackageName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtServiceMainDir;
        private System.Windows.Forms.TextBox txtServerPackageName;
        private System.Windows.Forms.Label label6;
    }
}

