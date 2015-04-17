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
            this.lstVacancies.CheckBoxes = true;
            this.lstVacancies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnCheckbox,
            this.clmnVacSequenceNumber,
            this.clmnVacPortalNumber,
            this.clmnVacDescription});
            this.lstVacancies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstVacancies.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstVacancies.FullRowSelect = true;
            this.lstVacancies.GridLines = true;
            this.lstVacancies.Location = new System.Drawing.Point(0, 31);
            this.lstVacancies.MultiSelect = false;
            this.lstVacancies.Name = "lstVacancies";
            this.lstVacancies.Size = new System.Drawing.Size(584, 520);
            this.lstVacancies.TabIndex = 3;
            this.lstVacancies.UseCompatibleStateImageBehavior = false;
            this.lstVacancies.View = System.Windows.Forms.View.Details;
            this.lstVacancies.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstVacancies_ItemChecked);
            this.lstVacancies.SelectedIndexChanged += new System.EventHandler(this.lstVacancies_SelectedIndexChanged);
            // 
            // clmnCheckbox
            // 
            this.clmnCheckbox.Text = "";
            this.clmnCheckbox.Width = 32;
            // 
            // clmnVacSequenceNumber
            // 
            this.clmnVacSequenceNumber.Text = "#";
            this.clmnVacSequenceNumber.Width = 64;
            // 
            // clmnVacPortalNumber
            // 
            this.clmnVacPortalNumber.Text = "ID";
            this.clmnVacPortalNumber.Width = 96;
            // 
            // clmnVacDescription
            // 
            this.clmnVacDescription.Text = "Description";
            this.clmnVacDescription.Width = 400;
            // 
            // toolbar
            // 
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
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(584, 31);
            this.toolbar.TabIndex = 2;
            this.toolbar.Text = "toolStrip1";
            // 
            // toolBtnRefreshVacancies
            // 
            this.toolBtnRefreshVacancies.Image = global::DistantVacantGovUz.Properties.Resources.refresh_24;
            this.toolBtnRefreshVacancies.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnRefreshVacancies.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnRefreshVacancies.Name = "toolBtnRefreshVacancies";
            this.toolBtnRefreshVacancies.Size = new System.Drawing.Size(74, 28);
            this.toolBtnRefreshVacancies.Text = "Refresh";
            this.toolBtnRefreshVacancies.ToolTipText = "Refresh vacancies list";
            this.toolBtnRefreshVacancies.Click += new System.EventHandler(this.toolBtnRefreshVacancies_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolBtnExportVacancies
            // 
            this.toolBtnExportVacancies.Enabled = false;
            this.toolBtnExportVacancies.Image = global::DistantVacantGovUz.Properties.Resources.export_24_2;
            this.toolBtnExportVacancies.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnExportVacancies.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnExportVacancies.Name = "toolBtnExportVacancies";
            this.toolBtnExportVacancies.Size = new System.Drawing.Size(68, 28);
            this.toolBtnExportVacancies.Text = "Export";
            this.toolBtnExportVacancies.ToolTipText = "Export vacancies list to a file";
            this.toolBtnExportVacancies.Click += new System.EventHandler(this.toolBtnExportVacancies_Click);
            // 
            // toolBtnChangeStatus
            // 
            this.toolBtnChangeStatus.Enabled = false;
            this.toolBtnChangeStatus.Image = global::DistantVacantGovUz.Properties.Resources.key_24;
            this.toolBtnChangeStatus.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnChangeStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnChangeStatus.Name = "toolBtnChangeStatus";
            this.toolBtnChangeStatus.Size = new System.Drawing.Size(110, 28);
            this.toolBtnChangeStatus.Text = "Change status";
            this.toolBtnChangeStatus.ToolTipText = "Change checked vacancies status";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolBtnEditVacancy
            // 
            this.toolBtnEditVacancy.Enabled = false;
            this.toolBtnEditVacancy.Image = global::DistantVacantGovUz.Properties.Resources.edit_24;
            this.toolBtnEditVacancy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnEditVacancy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnEditVacancy.Name = "toolBtnEditVacancy";
            this.toolBtnEditVacancy.Size = new System.Drawing.Size(55, 28);
            this.toolBtnEditVacancy.Text = "Edit";
            this.toolBtnEditVacancy.ToolTipText = "Edit selected vacancy";
            this.toolBtnEditVacancy.Click += new System.EventHandler(this.toolBtnEditVacancy_Click);
            // 
            // toolBtnCheckAll
            // 
            this.toolBtnCheckAll.Enabled = false;
            this.toolBtnCheckAll.Image = global::DistantVacantGovUz.Properties.Resources.check_24;
            this.toolBtnCheckAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnCheckAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnCheckAll.Name = "toolBtnCheckAll";
            this.toolBtnCheckAll.Size = new System.Drawing.Size(85, 28);
            this.toolBtnCheckAll.Text = "Check All";
            this.toolBtnCheckAll.ToolTipText = "Check All Vacancies";
            this.toolBtnCheckAll.Click += new System.EventHandler(this.toolBtnCheckAll_Click);
            // 
            // toolBtnUncheckAll
            // 
            this.toolBtnUncheckAll.Enabled = false;
            this.toolBtnUncheckAll.Image = global::DistantVacantGovUz.Properties.Resources.uncheck_24;
            this.toolBtnUncheckAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnUncheckAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnUncheckAll.Name = "toolBtnUncheckAll";
            this.toolBtnUncheckAll.Size = new System.Drawing.Size(98, 28);
            this.toolBtnUncheckAll.Text = "Uncheck All";
            this.toolBtnUncheckAll.ToolTipText = "Uncheck all vacancies";
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 551);
            this.Controls.Add(this.lstVacancies);
            this.Controls.Add(this.toolbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOpenedVacancies";
            this.Text = "Opened vacancies";
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