namespace DistantVacantGovUz
{
    partial class frmClosedVacancies
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClosedVacancies));
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.toolBtnRefreshVacancies = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnExportVacancies = new System.Windows.Forms.ToolStripButton();
            this.toolBtnChangeStatus = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnEditVacancy = new System.Windows.Forms.ToolStripButton();
            this.toolBtnCheckAll = new System.Windows.Forms.ToolStripButton();
            this.toolBtnUncheckAll = new System.Windows.Forms.ToolStripButton();
            this.lstVacancies = new System.Windows.Forms.ListView();
            this.clmnCheckbox = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnVacSequenceNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnVacPortalNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnVacDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.workerRefreshVacancyList = new System.ComponentModel.BackgroundWorker();
            this.toolbar.SuspendLayout();
            this.SuspendLayout();
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
            this.toolbar.Size = new System.Drawing.Size(584, 39);
            this.toolbar.TabIndex = 0;
            this.toolbar.Text = "toolStrip1";
            this.toolbar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolbar_ItemClicked);
            // 
            // toolBtnRefreshVacancies
            // 
            this.toolBtnRefreshVacancies.Image = global::DistantVacantGovUz.Properties.Resources.refresh_32;
            this.toolBtnRefreshVacancies.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnRefreshVacancies.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnRefreshVacancies.Name = "toolBtnRefreshVacancies";
            this.toolBtnRefreshVacancies.Size = new System.Drawing.Size(82, 36);
            this.toolBtnRefreshVacancies.Text = "Refresh";
            this.toolBtnRefreshVacancies.ToolTipText = "Refresh vacancies list";
            this.toolBtnRefreshVacancies.Click += new System.EventHandler(this.toolBtnRefreshVacancies_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolBtnExportVacancies
            // 
            this.toolBtnExportVacancies.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnExportVacancies.Image")));
            this.toolBtnExportVacancies.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnExportVacancies.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnExportVacancies.Name = "toolBtnExportVacancies";
            this.toolBtnExportVacancies.Size = new System.Drawing.Size(76, 36);
            this.toolBtnExportVacancies.Text = "Export";
            this.toolBtnExportVacancies.ToolTipText = "Export vacancies list to a file";
            // 
            // toolBtnChangeStatus
            // 
            this.toolBtnChangeStatus.Image = global::DistantVacantGovUz.Properties.Resources.key_32;
            this.toolBtnChangeStatus.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnChangeStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnChangeStatus.Name = "toolBtnChangeStatus";
            this.toolBtnChangeStatus.Size = new System.Drawing.Size(118, 36);
            this.toolBtnChangeStatus.Text = "Change status";
            this.toolBtnChangeStatus.ToolTipText = "Change checked vacancies status";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolBtnEditVacancy
            // 
            this.toolBtnEditVacancy.Image = global::DistantVacantGovUz.Properties.Resources.edit_32;
            this.toolBtnEditVacancy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnEditVacancy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnEditVacancy.Name = "toolBtnEditVacancy";
            this.toolBtnEditVacancy.Size = new System.Drawing.Size(63, 36);
            this.toolBtnEditVacancy.Text = "Edit";
            this.toolBtnEditVacancy.ToolTipText = "Edit selected vacancy";
            // 
            // toolBtnCheckAll
            // 
            this.toolBtnCheckAll.Image = global::DistantVacantGovUz.Properties.Resources.check_green_32;
            this.toolBtnCheckAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnCheckAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnCheckAll.Name = "toolBtnCheckAll";
            this.toolBtnCheckAll.Size = new System.Drawing.Size(93, 36);
            this.toolBtnCheckAll.Text = "Check All";
            this.toolBtnCheckAll.ToolTipText = "Check All Vacancies";
            this.toolBtnCheckAll.Click += new System.EventHandler(this.toolBtnCheckAll_Click);
            // 
            // toolBtnUncheckAll
            // 
            this.toolBtnUncheckAll.Image = global::DistantVacantGovUz.Properties.Resources.check_grey_32;
            this.toolBtnUncheckAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnUncheckAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnUncheckAll.Name = "toolBtnUncheckAll";
            this.toolBtnUncheckAll.Size = new System.Drawing.Size(106, 36);
            this.toolBtnUncheckAll.Text = "Uncheck All";
            this.toolBtnUncheckAll.ToolTipText = "Uncheck all vacancies";
            this.toolBtnUncheckAll.Click += new System.EventHandler(this.toolBtnUncheckAll_Click);
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
            this.lstVacancies.Location = new System.Drawing.Point(0, 39);
            this.lstVacancies.MultiSelect = false;
            this.lstVacancies.Name = "lstVacancies";
            this.lstVacancies.Size = new System.Drawing.Size(584, 512);
            this.lstVacancies.TabIndex = 1;
            this.lstVacancies.UseCompatibleStateImageBehavior = false;
            this.lstVacancies.View = System.Windows.Forms.View.Details;
            // 
            // clmnCheckbox
            // 
            this.clmnCheckbox.Text = "";
            this.clmnCheckbox.Width = 32;
            // 
            // clmnVacSequenceNumber
            // 
            this.clmnVacSequenceNumber.Text = "#";
            this.clmnVacSequenceNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // workerRefreshVacancyList
            // 
            this.workerRefreshVacancyList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerRefreshVacancyList_DoWork);
            this.workerRefreshVacancyList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerRefreshVacancyList_RunWorkerCompleted);
            // 
            // frmClosedVacancies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 551);
            this.Controls.Add(this.lstVacancies);
            this.Controls.Add(this.toolbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmClosedVacancies";
            this.Text = "Closed vacancies";
            this.Load += new System.EventHandler(this.frmClosedVacancies_Load);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripButton toolBtnRefreshVacancies;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolBtnExportVacancies;
        private System.Windows.Forms.ToolStripButton toolBtnChangeStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolBtnEditVacancy;
        private System.Windows.Forms.ListView lstVacancies;
        private System.Windows.Forms.ColumnHeader clmnVacSequenceNumber;
        private System.Windows.Forms.ColumnHeader clmnVacPortalNumber;
        private System.Windows.Forms.ColumnHeader clmnVacDescription;
        private System.Windows.Forms.ColumnHeader clmnCheckbox;
        private System.Windows.Forms.ToolStripButton toolBtnCheckAll;
        private System.Windows.Forms.ToolStripButton toolBtnUncheckAll;
        private System.ComponentModel.BackgroundWorker workerRefreshVacancyList;
    }
}