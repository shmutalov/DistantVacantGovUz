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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
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
            this.btnAssoc = new System.Windows.Forms.Button();
            this.grpConnection.SuspendLayout();
            this.grpUpdates.SuspendLayout();
            this.grpInterface.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpConnection
            // 
            resources.ApplyResources(this.grpConnection, "grpConnection");
            this.grpConnection.Controls.Add(this.lblProxyPort);
            this.grpConnection.Controls.Add(this.txtProxyPort);
            this.grpConnection.Controls.Add(this.txtProxyPassword);
            this.grpConnection.Controls.Add(this.lblProxyPassword);
            this.grpConnection.Controls.Add(this.txtProxyUser);
            this.grpConnection.Controls.Add(this.lblProxyUser);
            this.grpConnection.Controls.Add(this.txtProxyHost);
            this.grpConnection.Controls.Add(this.lblProxyHost);
            this.grpConnection.Controls.Add(this.chkUseProxy);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.TabStop = false;
            // 
            // lblProxyPort
            // 
            resources.ApplyResources(this.lblProxyPort, "lblProxyPort");
            this.lblProxyPort.Name = "lblProxyPort";
            // 
            // txtProxyPort
            // 
            resources.ApplyResources(this.txtProxyPort, "txtProxyPort");
            this.txtProxyPort.Name = "txtProxyPort";
            // 
            // txtProxyPassword
            // 
            resources.ApplyResources(this.txtProxyPassword, "txtProxyPassword");
            this.txtProxyPassword.Name = "txtProxyPassword";
            // 
            // lblProxyPassword
            // 
            resources.ApplyResources(this.lblProxyPassword, "lblProxyPassword");
            this.lblProxyPassword.Name = "lblProxyPassword";
            // 
            // txtProxyUser
            // 
            resources.ApplyResources(this.txtProxyUser, "txtProxyUser");
            this.txtProxyUser.Name = "txtProxyUser";
            // 
            // lblProxyUser
            // 
            resources.ApplyResources(this.lblProxyUser, "lblProxyUser");
            this.lblProxyUser.Name = "lblProxyUser";
            // 
            // txtProxyHost
            // 
            resources.ApplyResources(this.txtProxyHost, "txtProxyHost");
            this.txtProxyHost.Name = "txtProxyHost";
            // 
            // lblProxyHost
            // 
            resources.ApplyResources(this.lblProxyHost, "lblProxyHost");
            this.lblProxyHost.Name = "lblProxyHost";
            // 
            // chkUseProxy
            // 
            resources.ApplyResources(this.chkUseProxy, "chkUseProxy");
            this.chkUseProxy.Checked = true;
            this.chkUseProxy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseProxy.Name = "chkUseProxy";
            this.chkUseProxy.UseVisualStyleBackColor = true;
            this.chkUseProxy.CheckedChanged += new System.EventHandler(this.chkUseProxy_CheckedChanged);
            // 
            // grpUpdates
            // 
            this.grpUpdates.Controls.Add(this.txtUpdateServer);
            this.grpUpdates.Controls.Add(this.lblUpdateServer);
            this.grpUpdates.Controls.Add(this.chkEnableUpdates);
            resources.ApplyResources(this.grpUpdates, "grpUpdates");
            this.grpUpdates.Name = "grpUpdates";
            this.grpUpdates.TabStop = false;
            // 
            // txtUpdateServer
            // 
            resources.ApplyResources(this.txtUpdateServer, "txtUpdateServer");
            this.txtUpdateServer.Name = "txtUpdateServer";
            // 
            // lblUpdateServer
            // 
            resources.ApplyResources(this.lblUpdateServer, "lblUpdateServer");
            this.lblUpdateServer.Name = "lblUpdateServer";
            // 
            // chkEnableUpdates
            // 
            resources.ApplyResources(this.chkEnableUpdates, "chkEnableUpdates");
            this.chkEnableUpdates.Name = "chkEnableUpdates";
            this.chkEnableUpdates.UseVisualStyleBackColor = true;
            this.chkEnableUpdates.CheckedChanged += new System.EventHandler(this.chkEnableUpdates_CheckedChanged);
            // 
            // grpInterface
            // 
            this.grpInterface.Controls.Add(this.cmbLanguage);
            this.grpInterface.Controls.Add(this.lblLanguage);
            resources.ApplyResources(this.grpInterface, "grpInterface");
            this.grpInterface.Name = "grpInterface";
            this.grpInterface.TabStop = false;
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Items.AddRange(new object[] {
            resources.GetString("cmbLanguage.Items"),
            resources.GetString("cmbLanguage.Items1"),
            resources.GetString("cmbLanguage.Items2")});
            resources.ApplyResources(this.cmbLanguage, "cmbLanguage");
            this.cmbLanguage.Name = "cmbLanguage";
            // 
            // lblLanguage
            // 
            resources.ApplyResources(this.lblLanguage, "lblLanguage");
            this.lblLanguage.Name = "lblLanguage";
            // 
            // btnAssoc
            // 
            resources.ApplyResources(this.btnAssoc, "btnAssoc");
            this.btnAssoc.Name = "btnAssoc";
            this.btnAssoc.UseVisualStyleBackColor = true;
            this.btnAssoc.Click += new System.EventHandler(this.btnAssoc_Click);
            // 
            // frmSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAssoc);
            this.Controls.Add(this.grpInterface);
            this.Controls.Add(this.grpUpdates);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpConnection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSettings";
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
        private System.Windows.Forms.Button btnAssoc;
    }
}