namespace FrmGenerate
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
            this.txtOutPath = new System.Windows.Forms.TextBox();
            this.btnSelOutPath = new System.Windows.Forms.Button();
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
            this.txtDbName.Text = "jwplatform";
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
            this.lvTabeleName.Size = new System.Drawing.Size(213, 327);
            this.lvTabeleName.TabIndex = 7;
            this.lvTabeleName.UseCompatibleStateImageBehavior = false;
            this.lvTabeleName.View = System.Windows.Forms.View.List;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(626, 45);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 8;
            this.btnCreate.Text = "生 成";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtOutPath
            // 
            this.txtOutPath.Location = new System.Drawing.Point(237, 45);
            this.txtOutPath.Name = "txtOutPath";
            this.txtOutPath.Size = new System.Drawing.Size(297, 21);
            this.txtOutPath.TabIndex = 9;
            this.txtOutPath.Text = "f:\\temp";
            // 
            // btnSelOutPath
            // 
            this.btnSelOutPath.Location = new System.Drawing.Point(542, 45);
            this.btnSelOutPath.Name = "btnSelOutPath";
            this.btnSelOutPath.Size = new System.Drawing.Size(75, 23);
            this.btnSelOutPath.TabIndex = 10;
            this.btnSelOutPath.Text = "选 择";
            this.btnSelOutPath.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 369);
            this.Controls.Add(this.btnSelOutPath);
            this.Controls.Add(this.txtOutPath);
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
        private System.Windows.Forms.TextBox txtOutPath;
        private System.Windows.Forms.Button btnSelOutPath;
    }
}

