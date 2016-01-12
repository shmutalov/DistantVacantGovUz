namespace DistantVacantGovUz.Windows
{
    partial class AboutWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutWindow));
            this.lblProgramName = new System.Windows.Forms.Label();
            this.linkProgramWebSite = new System.Windows.Forms.LinkLabel();
            this.lblAppVersion = new System.Windows.Forms.Label();
            this.lblLauncherVersion = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.imgLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProgramName
            // 
            resources.ApplyResources(this.lblProgramName, "lblProgramName");
            this.lblProgramName.ImageKey = global::DistantVacantGovUz.language.strings.mnuHelp;
            this.lblProgramName.Name = "lblProgramName";
            // 
            // linkProgramWebSite
            // 
            resources.ApplyResources(this.linkProgramWebSite, "linkProgramWebSite");
            this.linkProgramWebSite.ImageKey = global::DistantVacantGovUz.language.strings.mnuHelp;
            this.linkProgramWebSite.Name = "linkProgramWebSite";
            this.linkProgramWebSite.TabStop = true;
            this.linkProgramWebSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkProgramWebSite_LinkClicked);
            // 
            // lblAppVersion
            // 
            resources.ApplyResources(this.lblAppVersion, "lblAppVersion");
            this.lblAppVersion.ImageKey = global::DistantVacantGovUz.language.strings.mnuHelp;
            this.lblAppVersion.Name = "lblAppVersion";
            // 
            // lblLauncherVersion
            // 
            resources.ApplyResources(this.lblLauncherVersion, "lblLauncherVersion");
            this.lblLauncherVersion.ImageKey = global::DistantVacantGovUz.language.strings.mnuHelp;
            this.lblLauncherVersion.Name = "lblLauncherVersion";
            // 
            // lblAuthor
            // 
            resources.ApplyResources(this.lblAuthor, "lblAuthor");
            this.lblAuthor.ImageKey = global::DistantVacantGovUz.language.strings.mnuHelp;
            this.lblAuthor.Name = "lblAuthor";
            // 
            // imgLogo
            // 
            this.imgLogo.Image = global::DistantVacantGovUz.Properties.Resources.logo_144;
            resources.ApplyResources(this.imgLogo, "imgLogo");
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.TabStop = false;
            // 
            // AboutWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblLauncherVersion);
            this.Controls.Add(this.lblAppVersion);
            this.Controls.Add(this.linkProgramWebSite);
            this.Controls.Add(this.imgLogo);
            this.Controls.Add(this.lblProgramName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutWindow";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProgramName;
        private System.Windows.Forms.PictureBox imgLogo;
        private System.Windows.Forms.LinkLabel linkProgramWebSite;
        private System.Windows.Forms.Label lblAppVersion;
        private System.Windows.Forms.Label lblLauncherVersion;
        private System.Windows.Forms.Label lblAuthor;
    }
}