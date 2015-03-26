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
            this.mnuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
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
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSystem,
            this.mnuTools,
            this.mnuWindowCloseAll});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(802, 24);
            this.mnuMain.TabIndex = 8;
            this.mnuMain.Text = "Настройки";
            // 
            // mnuSystem
            // 
            this.mnuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogin,
            this.toolStripSeparator1,
            this.mnuLogout});
            this.mnuSystem.Name = "mnuSystem";
            this.mnuSystem.Size = new System.Drawing.Size(57, 20);
            this.mnuSystem.Text = "System";
            // 
            // mnuLogin
            // 
            this.mnuLogin.Name = "mnuLogin";
            this.mnuLogin.Size = new System.Drawing.Size(115, 22);
            this.mnuLogin.Text = "Log in";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(112, 6);
            // 
            // mnuLogout
            // 
            this.mnuLogout.Enabled = false;
            this.mnuLogout.Name = "mnuLogout";
            this.mnuLogout.Size = new System.Drawing.Size(115, 22);
            this.mnuLogout.Text = "Log out";
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.mnuImportToPortal});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(48, 20);
            this.mnuTools.Text = "Tools";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(161, 6);
            // 
            // mnuImportToPortal
            // 
            this.mnuImportToPortal.Name = "mnuImportToPortal";
            this.mnuImportToPortal.Size = new System.Drawing.Size(164, 22);
            this.mnuImportToPortal.Text = "Import vacancies";
            this.mnuImportToPortal.ToolTipText = "Import vacancies to portal from file";
            this.mnuImportToPortal.Click += new System.EventHandler(this.mnuImportToPortal_Click);
            // 
            // mnuWindowCloseAll
            // 
            this.mnuWindowCloseAll.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuWindowLayout,
            this.mnuWindowOpen,
            this.mnuWindowShowAll,
            this.mnuWindowHideAll,
            this.closeAllToolStripMenuItem});
            this.mnuWindowCloseAll.Name = "mnuWindowCloseAll";
            this.mnuWindowCloseAll.Size = new System.Drawing.Size(63, 20);
            this.mnuWindowCloseAll.Text = "Window";
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
            this.mnuWindowLayout.Size = new System.Drawing.Size(120, 22);
            this.mnuWindowLayout.Text = "Layout";
            // 
            // mnuWindowLayoutArrangeIcons
            // 
            this.mnuWindowLayoutArrangeIcons.Name = "mnuWindowLayoutArrangeIcons";
            this.mnuWindowLayoutArrangeIcons.Size = new System.Drawing.Size(151, 22);
            this.mnuWindowLayoutArrangeIcons.Text = "Arrange Icons";
            this.mnuWindowLayoutArrangeIcons.Click += new System.EventHandler(this.mnuWindowLayoutArrangeIcons_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(148, 6);
            // 
            // mnuWindowLayoutCascade
            // 
            this.mnuWindowLayoutCascade.Name = "mnuWindowLayoutCascade";
            this.mnuWindowLayoutCascade.Size = new System.Drawing.Size(151, 22);
            this.mnuWindowLayoutCascade.Text = "Cascade";
            this.mnuWindowLayoutCascade.Click += new System.EventHandler(this.mnuWindowLayoutCascade_Click);
            // 
            // mnuWindowLayoutTileH
            // 
            this.mnuWindowLayoutTileH.Name = "mnuWindowLayoutTileH";
            this.mnuWindowLayoutTileH.Size = new System.Drawing.Size(151, 22);
            this.mnuWindowLayoutTileH.Text = "Tile Horizontal";
            this.mnuWindowLayoutTileH.Click += new System.EventHandler(this.mnuWindowLayoutTileH_Click);
            // 
            // mnuWindowLayoutTileV
            // 
            this.mnuWindowLayoutTileV.Name = "mnuWindowLayoutTileV";
            this.mnuWindowLayoutTileV.Size = new System.Drawing.Size(151, 22);
            this.mnuWindowLayoutTileV.Text = "Tile Vertical";
            this.mnuWindowLayoutTileV.Click += new System.EventHandler(this.mnuWindowLayoutTileV_Click);
            // 
            // mnuWindowOpen
            // 
            this.mnuWindowOpen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuWindowOpenOpenedVacs,
            this.mnuWindowOpenClosedVacs});
            this.mnuWindowOpen.Name = "mnuWindowOpen";
            this.mnuWindowOpen.Size = new System.Drawing.Size(120, 22);
            this.mnuWindowOpen.Text = "Open";
            // 
            // mnuWindowOpenOpenedVacs
            // 
            this.mnuWindowOpenOpenedVacs.Name = "mnuWindowOpenOpenedVacs";
            this.mnuWindowOpenOpenedVacs.Size = new System.Drawing.Size(171, 22);
            this.mnuWindowOpenOpenedVacs.Text = "Opened Vacancies";
            this.mnuWindowOpenOpenedVacs.Click += new System.EventHandler(this.mnuWindowOpenOpenedVacs_Click);
            // 
            // mnuWindowOpenClosedVacs
            // 
            this.mnuWindowOpenClosedVacs.Name = "mnuWindowOpenClosedVacs";
            this.mnuWindowOpenClosedVacs.Size = new System.Drawing.Size(171, 22);
            this.mnuWindowOpenClosedVacs.Text = "Closed Vacancies";
            this.mnuWindowOpenClosedVacs.Click += new System.EventHandler(this.mnuWindowOpenClosedVacs_Click);
            // 
            // mnuWindowShowAll
            // 
            this.mnuWindowShowAll.Name = "mnuWindowShowAll";
            this.mnuWindowShowAll.Size = new System.Drawing.Size(120, 22);
            this.mnuWindowShowAll.Text = "Show All";
            this.mnuWindowShowAll.Click += new System.EventHandler(this.mnuWindowShowAll_Click);
            // 
            // mnuWindowHideAll
            // 
            this.mnuWindowHideAll.Name = "mnuWindowHideAll";
            this.mnuWindowHideAll.Size = new System.Drawing.Size(120, 22);
            this.mnuWindowHideAll.Text = "Hide All";
            this.mnuWindowHideAll.Click += new System.EventHandler(this.mnuWindowHideAll_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.closeAllToolStripMenuItem.Text = "Close All";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
            // 
            // frmPortalVacancies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 478);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmPortalVacancies";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vacancies on portal";
            this.Load += new System.EventHandler(this.frmPortalVacancies_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuSystem;
        private System.Windows.Forms.ToolStripMenuItem mnuLogin;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuLogout;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
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