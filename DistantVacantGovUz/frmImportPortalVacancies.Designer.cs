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
            this.toolTxtImportFileName = new System.Windows.Forms.ToolStripTextBox();
            this.toolBtnImport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnBrowse = new System.Windows.Forms.ToolStripButton();
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
            this.toolStrip1.Size = new System.Drawing.Size(574, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolTxtImportFileName
            // 
            this.toolTxtImportFileName.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolTxtImportFileName.Name = "toolTxtImportFileName";
            this.toolTxtImportFileName.Size = new System.Drawing.Size(400, 39);
            // 
            // toolBtnImport
            // 
            this.toolBtnImport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolBtnImport.Image = global::DistantVacantGovUz.Properties.Resources.import;
            this.toolBtnImport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnImport.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolBtnImport.Name = "toolBtnImport";
            this.toolBtnImport.Size = new System.Drawing.Size(79, 36);
            this.toolBtnImport.Text = "Import";
            this.toolBtnImport.ToolTipText = "Start import process of selected file to portal";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolBtnBrowse
            // 
            this.toolBtnBrowse.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolBtnBrowse.Image = global::DistantVacantGovUz.Properties.Resources.browse_32;
            this.toolBtnBrowse.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnBrowse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnBrowse.Name = "toolBtnBrowse";
            this.toolBtnBrowse.Size = new System.Drawing.Size(81, 36);
            this.toolBtnBrowse.Text = "Browse";
            this.toolBtnBrowse.ToolTipText = "Browse vacancy file";
            // 
            // frmImportPortalVacancies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 528);
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
    }
}