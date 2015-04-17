namespace DistantVacantGovUz
{
    partial class frmImportPortalVacancies
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportPortalVacancies));
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
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnImport,
            this.toolStripSeparator1,
            this.toolBtnBrowse,
            this.toolTxtImportFileName});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(843, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolBtnImport
            // 
            this.toolBtnImport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolBtnImport.Enabled = false;
            this.toolBtnImport.Image = global::DistantVacantGovUz.Properties.Resources.import_24;
            this.toolBtnImport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnImport.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolBtnImport.Name = "toolBtnImport";
            this.toolBtnImport.Size = new System.Drawing.Size(71, 28);
            this.toolBtnImport.Text = "Import";
            this.toolBtnImport.ToolTipText = "Start import process of selected file to portal";
            this.toolBtnImport.Click += new System.EventHandler(this.toolBtnImport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolBtnBrowse
            // 
            this.toolBtnBrowse.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolBtnBrowse.Image = global::DistantVacantGovUz.Properties.Resources.browse_24;
            this.toolBtnBrowse.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnBrowse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnBrowse.Name = "toolBtnBrowse";
            this.toolBtnBrowse.Size = new System.Drawing.Size(73, 28);
            this.toolBtnBrowse.Text = "Browse";
            this.toolBtnBrowse.ToolTipText = "Browse vacancy file";
            this.toolBtnBrowse.Click += new System.EventHandler(this.toolBtnBrowse_Click);
            // 
            // toolTxtImportFileName
            // 
            this.toolTxtImportFileName.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolTxtImportFileName.Name = "toolTxtImportFileName";
            this.toolTxtImportFileName.Size = new System.Drawing.Size(400, 31);
            // 
            // lstVacancies
            // 
            this.lstVacancies.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstVacancies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstVacancies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnSeqNum,
            this.clmnVacancyName,
            this.clmnStatus});
            this.lstVacancies.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstVacancies.FullRowSelect = true;
            this.lstVacancies.GridLines = true;
            this.lstVacancies.HotTracking = true;
            this.lstVacancies.HoverSelection = true;
            this.lstVacancies.Location = new System.Drawing.Point(0, 34);
            this.lstVacancies.MultiSelect = false;
            this.lstVacancies.Name = "lstVacancies";
            this.lstVacancies.Size = new System.Drawing.Size(843, 494);
            this.lstVacancies.TabIndex = 1;
            this.lstVacancies.UseCompatibleStateImageBehavior = false;
            this.lstVacancies.View = System.Windows.Forms.View.Details;
            // 
            // clmnSeqNum
            // 
            this.clmnSeqNum.Text = "#";
            this.clmnSeqNum.Width = 48;
            // 
            // clmnVacancyName
            // 
            this.clmnVacancyName.Text = "Name";
            this.clmnVacancyName.Width = 250;
            // 
            // clmnStatus
            // 
            this.clmnStatus.Text = "Status";
            this.clmnStatus.Width = 500;
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 528);
            this.Controls.Add(this.lstVacancies);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmImportPortalVacancies";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import vacancies";
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