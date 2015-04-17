namespace DistantVacantGovUz
{
    partial class frmOpenedVacancies
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpenedVacancies));
            this.lstVacancies = new System.Windows.Forms.ListView();
            this.clmnCheckbox = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnVacSequenceNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnVacPortalNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnVacDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.toolBtnRefreshVacancies = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnExportVacancies = new System.Windows.Forms.ToolStripButton();
            this.toolBtnChangeStatus = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnEditVacancy = new System.Windows.Forms.ToolStripButton();
            this.toolBtnCheckAll = new System.Windows.Forms.ToolStripButton();
            this.toolBtnUncheckAll = new System.Windows.Forms.ToolStripButton();
            this.workerRefreshVacancyList = new System.ComponentModel.BackgroundWorker();
            this.workerExportVacancies = new System.ComponentModel.BackgroundWorker();
            this.toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstVacancies
            // 
            resources.ApplyResources(this.lstVacancies, "lstVacancies");
            this.lstVacancies.CheckBoxes = true;
            this.lstVacancies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnCheckbox,
            this.clmnVacSequenceNumber,
            this.clmnVacPortalNumber,
            this.clmnVacDescription});
            this.lstVacancies.FullRowSelect = true;
            this.lstVacancies.GridLines = true;
            this.lstVacancies.MultiSelect = false;
            this.lstVacancies.Name = "lstVacancies";
            this.lstVacancies.UseCompatibleStateImageBehavior = false;
            this.lstVacancies.View = System.Windows.Forms.View.Details;
            this.lstVacancies.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstVacancies_ItemChecked);
            this.lstVacancies.SelectedIndexChanged += new System.EventHandler(this.lstVacancies_SelectedIndexChanged);
            // 
            // clmnCheckbox
            // 
            resources.ApplyResources(this.clmnCheckbox, "clmnCheckbox");
            // 
            // clmnVacSequenceNumber
            // 
            resources.ApplyResources(this.clmnVacSequenceNumber, "clmnVacSequenceNumber");
            // 
            // clmnVacPortalNumber
            // 
            resources.ApplyResources(this.clmnVacPortalNumber, "clmnVacPortalNumber");
            // 
            // clmnVacDescription
            // 
            resources.ApplyResources(this.clmnVacDescription, "clmnVacDescription");
            // 
            // toolbar
            // 
            resources.ApplyResources(this.toolbar, "toolbar");
            this.toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnRefreshVacancies,
            this.toolStripSeparator1,
            this.toolBtnExportVacancies,
            this.toolBtnChangeStatus,
            this.toolStripSeparator2,
            this.toolBtnEditVacancy,
            this.toolBtnCheckAll,
            this.toolBtnUncheckAll});
            this.toolbar.Name = "toolbar";
            // 
            // toolBtnRefreshVacancies
            // 
            resources.ApplyResources(this.toolBtnRefreshVacancies, "toolBtnRefreshVacancies");
            this.toolBtnRefreshVacancies.Image = global::DistantVacantGovUz.Properties.Resources.refresh_24;
            this.toolBtnRefreshVacancies.Name = "toolBtnRefreshVacancies";
            this.toolBtnRefreshVacancies.Click += new System.EventHandler(this.toolBtnRefreshVacancies_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // toolBtnExportVacancies
            // 
            resources.ApplyResources(this.toolBtnExportVacancies, "toolBtnExportVacancies");
            this.toolBtnExportVacancies.Image = global::DistantVacantGovUz.Properties.Resources.export_24_2;
            this.toolBtnExportVacancies.Name = "toolBtnExportVacancies";
            this.toolBtnExportVacancies.Click += new System.EventHandler(this.toolBtnExportVacancies_Click);
            // 
            // toolBtnChangeStatus
            // 
            resources.ApplyResources(this.toolBtnChangeStatus, "toolBtnChangeStatus");
            this.toolBtnChangeStatus.Image = global::DistantVacantGovUz.Properties.Resources.key_24;
            this.toolBtnChangeStatus.Name = "toolBtnChangeStatus";
            this.toolBtnChangeStatus.Click += new System.EventHandler(this.toolBtnChangeStatus_Click);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // toolBtnEditVacancy
            // 
            resources.ApplyResources(this.toolBtnEditVacancy, "toolBtnEditVacancy");
            this.toolBtnEditVacancy.Image = global::DistantVacantGovUz.Properties.Resources.edit_24;
            this.toolBtnEditVacancy.Name = "toolBtnEditVacancy";
            this.toolBtnEditVacancy.Click += new System.EventHandler(this.toolBtnEditVacancy_Click);
            // 
            // toolBtnCheckAll
            // 
            resources.ApplyResources(this.toolBtnCheckAll, "toolBtnCheckAll");
            this.toolBtnCheckAll.Image = global::DistantVacantGovUz.Properties.Resources.check_24;
            this.toolBtnCheckAll.Name = "toolBtnCheckAll";
            this.toolBtnCheckAll.Click += new System.EventHandler(this.toolBtnCheckAll_Click);
            // 
            // toolBtnUncheckAll
            // 
            resources.ApplyResources(this.toolBtnUncheckAll, "toolBtnUncheckAll");
            this.toolBtnUncheckAll.Image = global::DistantVacantGovUz.Properties.Resources.uncheck_24;
            this.toolBtnUncheckAll.Name = "toolBtnUncheckAll";
            this.toolBtnUncheckAll.Click += new System.EventHandler(this.toolBtnUncheckAll_Click);
            // 
            // workerRefreshVacancyList
            // 
            this.workerRefreshVacancyList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerRefreshVacancyList_DoWork);
            this.workerRefreshVacancyList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerRefreshVacancyList_RunWorkerCompleted);
            // 
            // workerExportVacancies
            // 
            this.workerExportVacancies.WorkerReportsProgress = true;
            this.workerExportVacancies.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerExportVacancies_DoWork);
            this.workerExportVacancies.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.workerExportVacancies_ProgressChanged);
            this.workerExportVacancies.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerExportVacancies_RunWorkerCompleted);
            // 
            // frmOpenedVacancies
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstVacancies);
            this.Controls.Add(this.toolbar);
            this.Name = "frmOpenedVacancies";
            this.Load += new System.EventHandler(this.frmOpenedVacancies_Load);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstVacancies;
        private System.Windows.Forms.ColumnHeader clmnVacSequenceNumber;
        private System.Windows.Forms.ColumnHeader clmnVacPortalNumber;
        private System.Windows.Forms.ColumnHeader clmnVacDescription;
        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripButton toolBtnRefreshVacancies;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolBtnExportVacancies;
        private System.Windows.Forms.ToolStripButton toolBtnChangeStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolBtnEditVacancy;
        private System.Windows.Forms.ToolStripButton toolBtnCheckAll;
        private System.Windows.Forms.ToolStripButton toolBtnUncheckAll;
        private System.Windows.Forms.ColumnHeader clmnCheckbox;
        private System.ComponentModel.BackgroundWorker workerRefreshVacancyList;
        private System.ComponentModel.BackgroundWorker workerExportVacancies;
    }
}