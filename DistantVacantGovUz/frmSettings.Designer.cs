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
            this.grpUpdates = new System.Windows.Forms.GroupBox();
            this.txtUpdateServer = new System.Windows.Forms.TextBox();
            this.lblUpdateServer = new System.Windows.Forms.Label();
            this.chkEnableUpdates = new System.Windows.Forms.CheckBox();
            this.grpInterface = new System.Windows.Forms.GroupBox();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.grpConnection.SuspendLayout();
            this.grpUpdates.SuspendLayout();
            this.grpInterface.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(308, 298);
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
            this.grpConnection.Location = new System.Drawing.Point(12, 153);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Size = new System.Drawing.Size(438, 136);
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
            // grpUpdates
            // 
            this.grpUpdates.Controls.Add(this.txtUpdateServer);
            this.grpUpdates.Controls.Add(this.lblUpdateServer);
            this.grpUpdates.Controls.Add(this.chkEnableUpdates);
            this.grpUpdates.Location = new System.Drawing.Point(12, 73);
            this.grpUpdates.Name = "grpUpdates";
            this.grpUpdates.Size = new System.Drawing.Size(438, 74);
            this.grpUpdates.TabIndex = 8;
            this.grpUpdates.TabStop = false;
            this.grpUpdates.Text = "Updates";
            // 
            // txtUpdateServer
            // 
            this.txtUpdateServer.Location = new System.Drawing.Point(105, 42);
            this.txtUpdateServer.Name = "txtUpdateServer";
            this.txtUpdateServer.Size = new System.Drawing.Size(322, 20);
            this.txtUpdateServer.TabIndex = 2;
            // 
            // lblUpdateServer
            // 
            this.lblUpdateServer.Location = new System.Drawing.Point(9, 41);
            this.lblUpdateServer.Name = "lblUpdateServer";
            this.lblUpdateServer.Size = new System.Drawing.Size(90, 20);
            this.lblUpdateServer.TabIndex = 1;
            this.lblUpdateServer.Text = "Update server";
            this.lblUpdateServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkEnableUpdates
            // 
            this.chkEnableUpdates.AutoSize = true;
            this.chkEnableUpdates.Location = new System.Drawing.Point(6, 19);
            this.chkEnableUpdates.Name = "chkEnableUpdates";
            this.chkEnableUpdates.Size = new System.Drawing.Size(113, 17);
            this.chkEnableUpdates.TabIndex = 0;
            this.chkEnableUpdates.Text = "Check for updates";
            this.chkEnableUpdates.UseVisualStyleBackColor = true;
            this.chkEnableUpdates.CheckedChanged += new System.EventHandler(this.chkEnableUpdates_CheckedChanged);
            // 
            // grpInterface
            // 
            this.grpInterface.Controls.Add(this.cmbLanguage);
            this.grpInterface.Controls.Add(this.lblLanguage);
            this.grpInterface.Location = new System.Drawing.Point(12, 12);
            this.grpInterface.Name = "grpInterface";
            this.grpInterface.Size = new System.Drawing.Size(438, 55);
            this.grpInterface.TabIndex = 9;
            this.grpInterface.TabStop = false;
            this.grpInterface.Text = "Interface";
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Items.AddRange(new object[] {
            "Русский",
            "O\'zbekcha",
            "English"});
            this.cmbLanguage.Location = new System.Drawing.Point(105, 19);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(322, 21);
            this.cmbLanguage.TabIndex = 1;
            // 
            // lblLanguage
            // 
            this.lblLanguage.Location = new System.Drawing.Point(6, 19);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(93, 20);
            this.lblLanguage.TabIndex = 0;
            this.lblLanguage.Text = "Language";
            this.lblLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 341);
            this.Controls.Add(this.grpInterface);
            this.Controls.Add(this.grpUpdates);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpConnection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.grpConnection.ResumeLayout(false);
            this.grpConnection.PerformLayout();
            this.grpUpdates.ResumeLayout(false);
            this.grpUpdates.PerformLayout();
            this.grpInterface.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox grpUpdates;
        private System.Windows.Forms.TextBox txtUpdateServer;
        private System.Windows.Forms.Label lblUpdateServer;
        private System.Windows.Forms.CheckBox chkEnableUpdates;
        private System.Windows.Forms.GroupBox grpInterface;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label lblLanguage;
    }
}