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
            this.mnuFileCreateNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPortalVacancies = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindowCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindowLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindowLayoutArrangeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuWindowLayoutCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindowLayoutTileH = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindowLayoutTileV = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindowShowAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindowHideAll = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHowToWork = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAboutProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuPortalVacancies,
            this.mnuWindowCloseAll,
            this.mnuHelp});
            resources.ApplyResources(this.mnuMain, "mnuMain");
            this.mnuMain.Name = "mnuMain";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileCreateNew,
            this.mnuFileOpen,
            this.toolStripSeparator1,
            this.mnuFileSettings});
            this.mnuFile.Name = "mnuFile";
            resources.ApplyResources(this.mnuFile, "mnuFile");
            // 
            // mnuFileCreateNew
            // 
            this.mnuFileCreateNew.Name = "mnuFileCreateNew";
            resources.ApplyResources(this.mnuFileCreateNew, "mnuFileCreateNew");
            this.mnuFileCreateNew.Click += new System.EventHandler(this.mnuFileCreateNew_Click);
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            resources.ApplyResources(this.mnuFileOpen, "mnuFileOpen");
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
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
            // mnuWindowCloseAll
            // 
            this.mnuWindowCloseAll.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuWindowLayout,
            this.mnuWindowShowAll,
            this.mnuWindowHideAll,
            this.closeAllToolStripMenuItem});
            this.mnuWindowCloseAll.Name = "mnuWindowCloseAll";
            resources.ApplyResources(this.mnuWindowCloseAll, "mnuWindowCloseAll");
            // 
            // mnuWindowLayout
            // 
            this.mnuWindowLayout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuWindowLayoutArrangeIcons,
            this.toolStripSeparator4,
            this.mnuWindowLayoutCascade,
            this.mnuWindowLayoutTileH,
            this.mnuWindowLayoutTileV});
            this.mnuWindowLayout.Name = "mnuWindowLayout";
            resources.ApplyResources(this.mnuWindowLayout, "mnuWindowLayout");
            // 
            // mnuWindowLayoutArrangeIcons
            // 
            this.mnuWindowLayoutArrangeIcons.Name = "mnuWindowLayoutArrangeIcons";
            resources.ApplyResources(this.mnuWindowLayoutArrangeIcons, "mnuWindowLayoutArrangeIcons");
            this.mnuWindowLayoutArrangeIcons.Click += new System.EventHandler(this.mnuWindowLayoutArrangeIcons_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // mnuWindowLayoutCascade
            // 
            this.mnuWindowLayoutCascade.Name = "mnuWindowLayoutCascade";
            resources.ApplyResources(this.mnuWindowLayoutCascade, "mnuWindowLayoutCascade");
            this.mnuWindowLayoutCascade.Click += new System.EventHandler(this.mnuWindowLayoutCascade_Click);
            // 
            // mnuWindowLayoutTileH
            // 
            this.mnuWindowLayoutTileH.Name = "mnuWindowLayoutTileH";
            resources.ApplyResources(this.mnuWindowLayoutTileH, "mnuWindowLayoutTileH");
            this.mnuWindowLayoutTileH.Click += new System.EventHandler(this.mnuWindowLayoutTileH_Click);
            // 
            // mnuWindowLayoutTileV
            // 
            this.mnuWindowLayoutTileV.Name = "mnuWindowLayoutTileV";
            resources.ApplyResources(this.mnuWindowLayoutTileV, "mnuWindowLayoutTileV");
            this.mnuWindowLayoutTileV.Click += new System.EventHandler(this.mnuWindowLayoutTileV_Click);
            // 
            // mnuWindowShowAll
            // 
            this.mnuWindowShowAll.Name = "mnuWindowShowAll";
            resources.ApplyResources(this.mnuWindowShowAll, "mnuWindowShowAll");
            this.mnuWindowShowAll.Click += new System.EventHandler(this.mnuWindowShowAll_Click);
            // 
            // mnuWindowHideAll
            // 
            this.mnuWindowHideAll.Name = "mnuWindowHideAll";
            resources.ApplyResources(this.mnuWindowHideAll, "mnuWindowHideAll");
            this.mnuWindowHideAll.Click += new System.EventHandler(this.mnuWindowHideAll_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            resources.ApplyResources(this.closeAllToolStripMenuItem, "closeAllToolStripMenuItem");
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
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
            // worker
            // 
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mnuMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
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
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowCloseAll;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowLayout;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowLayoutArrangeIcons;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowLayoutCascade;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowLayoutTileH;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowLayoutTileV;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowShowAll;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowHideAll;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker worker;
    }
}

