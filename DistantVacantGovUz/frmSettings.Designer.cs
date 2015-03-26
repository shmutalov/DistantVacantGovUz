namespace DistantVacantGovUz
{
    partial class frmSettings
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
            this.btnSave = new System.Windows.Forms.Button();
            this.grpConnection = new System.Windows.Forms.GroupBox();
            this.lblProxyPort = new System.Windows.Forms.Label();
            this.txtProxyPort = new System.Windows.Forms.TextBox();
            this.txtProxyPassword = new System.Windows.Forms.TextBox();
            this.lblProxyPassword = new System.Windows.Forms.Label();
            this.txtProxyUser = new System.Windows.Forms.TextBox();
            this.lblProxyUser = new System.Windows.Forms.Label();
            this.txtProxyHost = new System.Windows.Forms.TextBox();
            this.lblProxyHost = new System.Windows.Forms.Label();
            this.chkUseProxy = new System.Windows.Forms.CheckBox();
            this.grpConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(308, 159);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(142, 31);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpConnection
            // 
            this.grpConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpConnection.Controls.Add(this.lblProxyPort);
            this.grpConnection.Controls.Add(this.txtProxyPort);
            this.grpConnection.Controls.Add(this.txtProxyPassword);
            this.grpConnection.Controls.Add(this.lblProxyPassword);
            this.grpConnection.Controls.Add(this.txtProxyUser);
            this.grpConnection.Controls.Add(this.lblProxyUser);
            this.grpConnection.Controls.Add(this.txtProxyHost);
            this.grpConnection.Controls.Add(this.lblProxyHost);
            this.grpConnection.Controls.Add(this.chkUseProxy);
            this.grpConnection.Location = new System.Drawing.Point(12, 12);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Size = new System.Drawing.Size(438, 138);
            this.grpConnection.TabIndex = 6;
            this.grpConnection.TabStop = false;
            this.grpConnection.Text = "Connection";
            // 
            // lblProxyPort
            // 
            this.lblProxyPort.Location = new System.Drawing.Point(309, 47);
            this.lblProxyPort.Name = "lblProxyPort";
            this.lblProxyPort.Size = new System.Drawing.Size(54, 13);
            this.lblProxyPort.TabIndex = 8;
            this.lblProxyPort.Text = "Port";
            this.lblProxyPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProxyPort
            // 
            this.txtProxyPort.Location = new System.Drawing.Point(369, 44);
            this.txtProxyPort.Name = "txtProxyPort";
            this.txtProxyPort.Size = new System.Drawing.Size(58, 20);
            this.txtProxyPort.TabIndex = 2;
            // 
            // txtProxyPassword
            // 
            this.txtProxyPassword.Location = new System.Drawing.Point(105, 102);
            this.txtProxyPassword.Name = "txtProxyPassword";
            this.txtProxyPassword.PasswordChar = '•';
            this.txtProxyPassword.Size = new System.Drawing.Size(322, 20);
            this.txtProxyPassword.TabIndex = 4;
            // 
            // lblProxyPassword
            // 
            this.lblProxyPassword.Location = new System.Drawing.Point(6, 105);
            this.lblProxyPassword.Name = "lblProxyPassword";
            this.lblProxyPassword.Size = new System.Drawing.Size(93, 13);
            this.lblProxyPassword.TabIndex = 5;
            this.lblProxyPassword.Text = "Password";
            this.lblProxyPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProxyUser
            // 
            this.txtProxyUser.Location = new System.Drawing.Point(105, 74);
            this.txtProxyUser.Name = "txtProxyUser";
            this.txtProxyUser.Size = new System.Drawing.Size(322, 20);
            this.txtProxyUser.TabIndex = 3;
            // 
            // lblProxyUser
            // 
            this.lblProxyUser.Location = new System.Drawing.Point(6, 77);
            this.lblProxyUser.Name = "lblProxyUser";
            this.lblProxyUser.Size = new System.Drawing.Size(93, 13);
            this.lblProxyUser.TabIndex = 3;
            this.lblProxyUser.Text = "Username";
            this.lblProxyUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProxyHost
            // 
            this.txtProxyHost.Location = new System.Drawing.Point(105, 44);
            this.txtProxyHost.Name = "txtProxyHost";
            this.txtProxyHost.Size = new System.Drawing.Size(198, 20);
            this.txtProxyHost.TabIndex = 1;
            // 
            // lblProxyHost
            // 
            this.lblProxyHost.Location = new System.Drawing.Point(6, 47);
            this.lblProxyHost.Name = "lblProxyHost";
            this.lblProxyHost.Size = new System.Drawing.Size(93, 13);
            this.lblProxyHost.TabIndex = 1;
            this.lblProxyHost.Text = "Proxy host";
            this.lblProxyHost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkUseProxy
            // 
            this.chkUseProxy.AutoSize = true;
            this.chkUseProxy.Checked = true;
            this.chkUseProxy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseProxy.Location = new System.Drawing.Point(6, 21);
            this.chkUseProxy.Name = "chkUseProxy";
            this.chkUseProxy.Size = new System.Drawing.Size(73, 17);
            this.chkUseProxy.TabIndex = 0;
            this.chkUseProxy.Text = "Use proxy";
            this.chkUseProxy.UseVisualStyleBackColor = true;
            this.chkUseProxy.CheckedChanged += new System.EventHandler(this.chkUseProxy_CheckedChanged);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 202);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpConnection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.grpConnection.ResumeLayout(false);
            this.grpConnection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpConnection;
        private System.Windows.Forms.Label lblProxyPort;
        private System.Windows.Forms.TextBox txtProxyPort;
        private System.Windows.Forms.TextBox txtProxyPassword;
        private System.Windows.Forms.Label lblProxyPassword;
        private System.Windows.Forms.TextBox txtProxyUser;
        private System.Windows.Forms.Label lblProxyUser;
        private System.Windows.Forms.TextBox txtProxyHost;
        private System.Windows.Forms.Label lblProxyHost;
        private System.Windows.Forms.CheckBox chkUseProxy;
    }
}