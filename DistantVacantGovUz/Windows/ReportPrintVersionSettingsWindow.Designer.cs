namespace DistantVacantGovUz.Windows
{
    partial class ReportPrintVersionSettingsWindow
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportPrintVersionSettingsWindow));
            this.txtFooter = new System.Windows.Forms.TextBox();
            this.btnEditJobTitle = new System.Windows.Forms.Button();
            this.btnDeleteSelectedJobTitle = new System.Windows.Forms.Button();
            this.btnAddJobTitle = new System.Windows.Forms.Button();
            this.lblVisas = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.clmnSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblFooter = new System.Windows.Forms.Label();
            this.lstVisas = new System.Windows.Forms.ListView();
            this.clmnJobTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtWhom = new System.Windows.Forms.TextBox();
            this.lblDocumentName = new System.Windows.Forms.Label();
            this.txtReportHeader = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtFooter
            // 
            resources.ApplyResources(this.txtFooter, "txtFooter");
            this.txtFooter.Name = "txtFooter";
            // 
            // btnEditJobTitle
            // 
            resources.ApplyResources(this.btnEditJobTitle, "btnEditJobTitle");
            this.btnEditJobTitle.Name = "btnEditJobTitle";
            this.btnEditJobTitle.UseVisualStyleBackColor = true;
            this.btnEditJobTitle.Click += new System.EventHandler(this.btnEditJobTitle_Click);
            // 
            // btnDeleteSelectedJobTitle
            // 
            resources.ApplyResources(this.btnDeleteSelectedJobTitle, "btnDeleteSelectedJobTitle");
            this.btnDeleteSelectedJobTitle.Name = "btnDeleteSelectedJobTitle";
            this.btnDeleteSelectedJobTitle.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedJobTitle.Click += new System.EventHandler(this.btnDeleteSelectedJobTitle_Click);
            // 
            // btnAddJobTitle
            // 
            resources.ApplyResources(this.btnAddJobTitle, "btnAddJobTitle");
            this.btnAddJobTitle.Name = "btnAddJobTitle";
            this.btnAddJobTitle.UseVisualStyleBackColor = true;
            this.btnAddJobTitle.Click += new System.EventHandler(this.btnAddJobTitle_Click);
            // 
            // lblVisas
            // 
            resources.ApplyResources(this.lblVisas, "lblVisas");
            this.lblVisas.Name = "lblVisas";
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // clmnSubject
            // 
            resources.ApplyResources(this.clmnSubject, "clmnSubject");
            // 
            // lblFooter
            // 
            resources.ApplyResources(this.lblFooter, "lblFooter");
            this.lblFooter.Name = "lblFooter";
            // 
            // lstVisas
            // 
            resources.ApplyResources(this.lstVisas, "lstVisas");
            this.lstVisas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnJobTitle,
            this.clmnSubject});
            this.lstVisas.FullRowSelect = true;
            this.lstVisas.GridLines = true;
            this.lstVisas.MultiSelect = false;
            this.lstVisas.Name = "lstVisas";
            this.lstVisas.UseCompatibleStateImageBehavior = false;
            this.lstVisas.View = System.Windows.Forms.View.Details;
            // 
            // clmnJobTitle
            // 
            resources.ApplyResources(this.clmnJobTitle, "clmnJobTitle");
            // 
            // txtWhom
            // 
            resources.ApplyResources(this.txtWhom, "txtWhom");
            this.txtWhom.Name = "txtWhom";
            // 
            // lblDocumentName
            // 
            resources.ApplyResources(this.lblDocumentName, "lblDocumentName");
            this.lblDocumentName.Name = "lblDocumentName";
            // 
            // txtReportHeader
            // 
            resources.ApplyResources(this.txtReportHeader, "txtReportHeader");
            this.txtReportHeader.Name = "txtReportHeader";
            // 
            // frmRptPrintVersionSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtFooter);
            this.Controls.Add(this.btnEditJobTitle);
            this.Controls.Add(this.btnDeleteSelectedJobTitle);
            this.Controls.Add(this.btnAddJobTitle);
            this.Controls.Add(this.lblVisas);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblFooter);
            this.Controls.Add(this.lstVisas);
            this.Controls.Add(this.txtWhom);
            this.Controls.Add(this.lblDocumentName);
            this.Controls.Add(this.txtReportHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReportPrintVersionSettingsWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFooter;
        private System.Windows.Forms.Button btnEditJobTitle;
        private System.Windows.Forms.Button btnDeleteSelectedJobTitle;
        private System.Windows.Forms.Button btnAddJobTitle;
        private System.Windows.Forms.Label lblVisas;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ColumnHeader clmnSubject;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.ListView lstVisas;
        private System.Windows.Forms.ColumnHeader clmnJobTitle;
        private System.Windows.Forms.TextBox txtWhom;
        private System.Windows.Forms.Label lblDocumentName;
        private System.Windows.Forms.TextBox txtReportHeader;

    }
}