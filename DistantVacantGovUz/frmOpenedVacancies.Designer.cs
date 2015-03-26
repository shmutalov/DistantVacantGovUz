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
            this.toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstVacancies
            // 
            this.lstVacancies.CheckBoxes = true;
            this.lstVacancies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnVacSequenceNumber,
            this.clmnVacPortalNumber,
            this.clmnVacDescription});
            this.lstVacancies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstVacancies.FullRowSelect = true;
            this.lstVacancies.GridLines = true;
            this.lstVacancies.Location = new System.Drawing.Point(0, 39);
            this.lstVacancies.MultiSelect = false;
            this.lstVacancies.Name = "lstVacancies";
            this.lstVacancies.Size = new System.Drawing.Size(584, 512);
            this.lstVacancies.TabIndex = 3;
            this.lstVacancies.UseCompatibleStateImageBehavior = false;
            this.lstVacancies.View = System.Windows.Forms.View.Details;
            // 
            // clmnVacSequenceNumber
            // 
            this.clmnVacSequenceNumber.Text = "#";
            this.clmnVacSequenceNumber.Width = 36;
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
            this.toolBtnEditVacancy});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(584, 39);
            this.toolbar.TabIndex = 2;
            this.toolbar.Text = "toolStrip1";
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
            this.toolBtnEditVacancy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnEditVacancy.Name = "toolBtnEditVacancy";
            this.toolBtnEditVacancy.Size = new System.Drawing.Size(47, 36);
            this.toolBtnEditVacancy.Text = "Edit";
            this.toolBtnEditVacancy.ToolTipText = "Edit selected vacancy";
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
    }
}