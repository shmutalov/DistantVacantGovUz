namespace DistantVacantGovUz
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPortalVacancies = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHowToWork = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAboutProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileCreateNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuPortalVacancies,
            this.mnuHelp});
            resources.ApplyResources(this.mnuMain, "mnuMain");
            this.mnuMain.Name = "mnuMain";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileCreateNew,
            this.toolStripSeparator1,
            this.mnuFileSettings});
            this.mnuFile.Name = "mnuFile";
            resources.ApplyResources(this.mnuFile, "mnuFile");
            // 
            // mnuFileSettings
            // 
            this.mnuFileSettings.Name = "mnuFileSettings";
            resources.ApplyResources(this.mnuFileSettings, "mnuFileSettings");
            this.mnuFileSettings.Click += new System.EventHandler(this.mnuFileSettings_Click);
            // 
            // mnuPortalVacancies
            // 
            this.mnuPortalVacancies.Name = "mnuPortalVacancies";
            resources.ApplyResources(this.mnuPortalVacancies, "mnuPortalVacancies");
            this.mnuPortalVacancies.Click += new System.EventHandler(this.mnuPortalVacancies_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHowToWork,
            this.mnuAboutProgram});
            this.mnuHelp.Name = "mnuHelp";
            resources.ApplyResources(this.mnuHelp, "mnuHelp");
            // 
            // mnuHowToWork
            // 
            this.mnuHowToWork.Name = "mnuHowToWork";
            resources.ApplyResources(this.mnuHowToWork, "mnuHowToWork");
            // 
            // mnuAboutProgram
            // 
            this.mnuAboutProgram.Name = "mnuAboutProgram";
            resources.ApplyResources(this.mnuAboutProgram, "mnuAboutProgram");
            this.mnuAboutProgram.Click += new System.EventHandler(this.mnuAboutProgram_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // mnuFileCreateNew
            // 
            this.mnuFileCreateNew.Name = "mnuFileCreateNew";
            resources.ApplyResources(this.mnuFileCreateNew, "mnuFileCreateNew");
            this.mnuFileCreateNew.Click += new System.EventHandler(this.mnuFileCreateNew_Click);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuHowToWork;
        private System.Windows.Forms.ToolStripMenuItem mnuAboutProgram;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuPortalVacancies;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuFileCreateNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

