namespace DistantVacantGovUz
{
    partial class frmPortalVacancies
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPortalVacancies));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImportToPortal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindowCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindowLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindowLayoutArrangeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuWindowLayoutCascade = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindowLayoutTileH = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindowLayoutTileV = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindowOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindowOpenOpenedVacs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindowOpenClosedVacs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindowShowAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindowHideAll = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            resources.ApplyResources(this.mnuMain, "mnuMain");
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTools,
            this.mnuWindowCloseAll});
            this.mnuMain.Name = "mnuMain";
            // 
            // mnuTools
            // 
            resources.ApplyResources(this.mnuTools, "mnuTools");
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuImportToPortal});
            this.mnuTools.Name = "mnuTools";
            // 
            // mnuImportToPortal
            // 
            resources.ApplyResources(this.mnuImportToPortal, "mnuImportToPortal");
            this.mnuImportToPortal.Name = "mnuImportToPortal";
            this.mnuImportToPortal.Click += new System.EventHandler(this.mnuImportToPortal_Click);
            // 
            // mnuWindowCloseAll
            // 
            resources.ApplyResources(this.mnuWindowCloseAll, "mnuWindowCloseAll");
            this.mnuWindowCloseAll.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuWindowLayout,
            this.mnuWindowOpen,
            this.mnuWindowShowAll,
            this.mnuWindowHideAll,
            this.closeAllToolStripMenuItem});
            this.mnuWindowCloseAll.Name = "mnuWindowCloseAll";
            // 
            // mnuWindowLayout
            // 
            resources.ApplyResources(this.mnuWindowLayout, "mnuWindowLayout");
            this.mnuWindowLayout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuWindowLayoutArrangeIcons,
            this.toolStripSeparator4,
            this.mnuWindowLayoutCascade,
            this.mnuWindowLayoutTileH,
            this.mnuWindowLayoutTileV});
            this.mnuWindowLayout.Name = "mnuWindowLayout";
            // 
            // mnuWindowLayoutArrangeIcons
            // 
            resources.ApplyResources(this.mnuWindowLayoutArrangeIcons, "mnuWindowLayoutArrangeIcons");
            this.mnuWindowLayoutArrangeIcons.Name = "mnuWindowLayoutArrangeIcons";
            this.mnuWindowLayoutArrangeIcons.Click += new System.EventHandler(this.mnuWindowLayoutArrangeIcons_Click);
            // 
            // toolStripSeparator4
            // 
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            // 
            // mnuWindowLayoutCascade
            // 
            resources.ApplyResources(this.mnuWindowLayoutCascade, "mnuWindowLayoutCascade");
            this.mnuWindowLayoutCascade.Name = "mnuWindowLayoutCascade";
            this.mnuWindowLayoutCascade.Click += new System.EventHandler(this.mnuWindowLayoutCascade_Click);
            // 
            // mnuWindowLayoutTileH
            // 
            resources.ApplyResources(this.mnuWindowLayoutTileH, "mnuWindowLayoutTileH");
            this.mnuWindowLayoutTileH.Name = "mnuWindowLayoutTileH";
            this.mnuWindowLayoutTileH.Click += new System.EventHandler(this.mnuWindowLayoutTileH_Click);
            // 
            // mnuWindowLayoutTileV
            // 
            resources.ApplyResources(this.mnuWindowLayoutTileV, "mnuWindowLayoutTileV");
            this.mnuWindowLayoutTileV.Name = "mnuWindowLayoutTileV";
            this.mnuWindowLayoutTileV.Click += new System.EventHandler(this.mnuWindowLayoutTileV_Click);
            // 
            // mnuWindowOpen
            // 
            resources.ApplyResources(this.mnuWindowOpen, "mnuWindowOpen");
            this.mnuWindowOpen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuWindowOpenOpenedVacs,
            this.mnuWindowOpenClosedVacs});
            this.mnuWindowOpen.Name = "mnuWindowOpen";
            // 
            // mnuWindowOpenOpenedVacs
            // 
            resources.ApplyResources(this.mnuWindowOpenOpenedVacs, "mnuWindowOpenOpenedVacs");
            this.mnuWindowOpenOpenedVacs.Name = "mnuWindowOpenOpenedVacs";
            this.mnuWindowOpenOpenedVacs.Click += new System.EventHandler(this.mnuWindowOpenOpenedVacs_Click);
            // 
            // mnuWindowOpenClosedVacs
            // 
            resources.ApplyResources(this.mnuWindowOpenClosedVacs, "mnuWindowOpenClosedVacs");
            this.mnuWindowOpenClosedVacs.Name = "mnuWindowOpenClosedVacs";
            this.mnuWindowOpenClosedVacs.Click += new System.EventHandler(this.mnuWindowOpenClosedVacs_Click);
            // 
            // mnuWindowShowAll
            // 
            resources.ApplyResources(this.mnuWindowShowAll, "mnuWindowShowAll");
            this.mnuWindowShowAll.Name = "mnuWindowShowAll";
            this.mnuWindowShowAll.Click += new System.EventHandler(this.mnuWindowShowAll_Click);
            // 
            // mnuWindowHideAll
            // 
            resources.ApplyResources(this.mnuWindowHideAll, "mnuWindowHideAll");
            this.mnuWindowHideAll.Name = "mnuWindowHideAll";
            this.mnuWindowHideAll.Click += new System.EventHandler(this.mnuWindowHideAll_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            resources.ApplyResources(this.closeAllToolStripMenuItem, "closeAllToolStripMenuItem");
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
            // 
            // frmPortalVacancies
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mnuMain);
            this.IsMdiContainer = true;
            this.Name = "frmPortalVacancies";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPortalVacancies_FormClosing);
            this.Load += new System.EventHandler(this.frmPortalVacancies_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuImportToPortal;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowCloseAll;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowLayout;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowLayoutTileH;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowLayoutTileV;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowLayoutArrangeIcons;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowLayoutCascade;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowShowAll;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowHideAll;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowOpenClosedVacs;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowOpenOpenedVacs;
    }
}