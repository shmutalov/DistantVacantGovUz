namespace DistantVacantGovUz.Windows
{
    partial class ImportPortalVacanciesWindow
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportPortalVacanciesWindow));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolBtnImport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnBrowse = new System.Windows.Forms.ToolStripButton();
            this.toolTxtImportFileName = new System.Windows.Forms.ToolStripTextBox();
            this.lstVacancies = new System.Windows.Forms.ListView();
            this.clmnSeqNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnVacancyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.workerDocumentImporter = new System.ComponentModel.BackgroundWorker();
            this.workerDocumentPreloader = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnImport,
            this.toolStripSeparator1,
            this.toolBtnBrowse,
            this.toolTxtImportFileName});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolBtnImport
            // 
            resources.ApplyResources(this.toolBtnImport, "toolBtnImport");
            this.toolBtnImport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolBtnImport.Image = global::DistantVacantGovUz.Properties.Resources.import_24;
            this.toolBtnImport.Name = "toolBtnImport";
            this.toolBtnImport.Click += new System.EventHandler(this.toolBtnImport_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // toolBtnBrowse
            // 
            resources.ApplyResources(this.toolBtnBrowse, "toolBtnBrowse");
            this.toolBtnBrowse.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolBtnBrowse.Image = global::DistantVacantGovUz.Properties.Resources.browse_24;
            this.toolBtnBrowse.Name = "toolBtnBrowse";
            this.toolBtnBrowse.Click += new System.EventHandler(this.toolBtnBrowse_Click);
            // 
            // toolTxtImportFileName
            // 
            resources.ApplyResources(this.toolTxtImportFileName, "toolTxtImportFileName");
            this.toolTxtImportFileName.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolTxtImportFileName.Name = "toolTxtImportFileName";
            // 
            // lstVacancies
            // 
            resources.ApplyResources(this.lstVacancies, "lstVacancies");
            this.lstVacancies.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstVacancies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnSeqNum,
            this.clmnVacancyName,
            this.clmnStatus});
            this.lstVacancies.FullRowSelect = true;
            this.lstVacancies.GridLines = true;
            this.lstVacancies.HideSelection = false;
            this.lstVacancies.MultiSelect = false;
            this.lstVacancies.Name = "lstVacancies";
            this.lstVacancies.UseCompatibleStateImageBehavior = false;
            this.lstVacancies.View = System.Windows.Forms.View.Details;
            // 
            // clmnSeqNum
            // 
            resources.ApplyResources(this.clmnSeqNum, "clmnSeqNum");
            // 
            // clmnVacancyName
            // 
            resources.ApplyResources(this.clmnVacancyName, "clmnVacancyName");
            // 
            // clmnStatus
            // 
            resources.ApplyResources(this.clmnStatus, "clmnStatus");
            // 
            // workerDocumentImporter
            // 
            this.workerDocumentImporter.WorkerReportsProgress = true;
            // 
            // workerDocumentPreloader
            // 
            this.workerDocumentPreloader.WorkerReportsProgress = true;
            this.workerDocumentPreloader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerDocumentPreloader_DoWork);
            this.workerDocumentPreloader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerDocumentPreloader_RunWorkerCompleted);
            // 
            // frmImportPortalVacancies
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstVacancies);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ImportPortalVacanciesWindow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox toolTxtImportFileName;
        private System.Windows.Forms.ToolStripButton toolBtnBrowse;
        private System.Windows.Forms.ToolStripButton toolBtnImport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ListView lstVacancies;
        private System.Windows.Forms.ColumnHeader clmnSeqNum;
        private System.Windows.Forms.ColumnHeader clmnVacancyName;
        private System.Windows.Forms.ColumnHeader clmnStatus;
        private System.ComponentModel.BackgroundWorker workerDocumentImporter;
        private System.ComponentModel.BackgroundWorker workerDocumentPreloader;
    }
}