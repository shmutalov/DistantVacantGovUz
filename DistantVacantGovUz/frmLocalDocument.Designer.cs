namespace DistantVacantGovUz
{
    partial class frmLocalDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocalDocument));
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.toolBtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolBtnSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolBtnReport = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolBtnReportPdf = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBtnReportPdfPrintVersionRu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBtnReportPdfPrintVersionUz = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBtnReportXls = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBtnReportXlsPrintVersionRu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBtnReportXlsPrintVersionUz = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolBtnImportFromFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnCheckAll = new System.Windows.Forms.ToolStripButton();
            this.toolBtnUncheckAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBtnUndo = new System.Windows.Forms.ToolStripButton();
            this.toolBtnRedo = new System.Windows.Forms.ToolStripButton();
            this.toolBtnEditSelected = new System.Windows.Forms.ToolStripButton();
            this.toolBtnDeleteChecked = new System.Windows.Forms.ToolStripButton();
            this.lstVacancies = new System.Windows.Forms.ListView();
            this.clmnCheckbox = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnSeqNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnPortalVacancyId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnDescriptionRu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnDescriptionUz = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnSalary = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnEmployment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnGender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnExperience = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnEducation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnExpireDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnDepartmentRu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnSpecializationRu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnRequirementsRu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnInformationRu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnDepartmentUz = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnSpecializationUz = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnRequirementsUz = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnInformationUz = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = new System.Windows.Forms.StatusStrip();
            this.stsSelectedItems = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolbar.SuspendLayout();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnSave,
            this.toolBtnSaveAs,
            this.toolBtnReport,
            this.toolStripSeparator1,
            this.toolBtnAdd,
            this.toolBtnImportFromFile,
            this.toolStripSeparator2,
            this.toolBtnCheckAll,
            this.toolBtnUncheckAll,
            this.toolStripSeparator3,
            this.toolBtnUndo,
            this.toolBtnRedo,
            this.toolBtnEditSelected,
            this.toolBtnDeleteChecked});
            this.toolbar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(892, 39);
            this.toolbar.TabIndex = 0;
            this.toolbar.Text = "toolStrip1";
            // 
            // toolBtnSave
            // 
            this.toolBtnSave.Image = global::DistantVacantGovUz.Properties.Resources.save_32;
            this.toolBtnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnSave.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolBtnSave.Name = "toolBtnSave";
            this.toolBtnSave.Size = new System.Drawing.Size(67, 36);
            this.toolBtnSave.Text = "Save";
            this.toolBtnSave.Click += new System.EventHandler(this.toolBtnSave_Click);
            // 
            // toolBtnSaveAs
            // 
            this.toolBtnSaveAs.Image = global::DistantVacantGovUz.Properties.Resources.save_32;
            this.toolBtnSaveAs.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnSaveAs.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolBtnSaveAs.Name = "toolBtnSaveAs";
            this.toolBtnSaveAs.Size = new System.Drawing.Size(90, 36);
            this.toolBtnSaveAs.Text = "Save as...";
            this.toolBtnSaveAs.Click += new System.EventHandler(this.toolBtnSaveAs_Click);
            // 
            // toolBtnReport
            // 
            this.toolBtnReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnReportPdf,
            this.toolBtnReportXls});
            this.toolBtnReport.Image = global::DistantVacantGovUz.Properties.Resources.report_32;
            this.toolBtnReport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnReport.Name = "toolBtnReport";
            this.toolBtnReport.Size = new System.Drawing.Size(87, 36);
            this.toolBtnReport.Text = "Report";
            // 
            // toolBtnReportPdf
            // 
            this.toolBtnReportPdf.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnReportPdfPrintVersionRu,
            this.toolBtnReportPdfPrintVersionUz});
            this.toolBtnReportPdf.Image = global::DistantVacantGovUz.Properties.Resources.pdf_doc;
            this.toolBtnReportPdf.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnReportPdf.Name = "toolBtnReportPdf";
            this.toolBtnReportPdf.Size = new System.Drawing.Size(184, 54);
            this.toolBtnReportPdf.Text = "PDF";
            // 
            // toolBtnReportPdfPrintVersionRu
            // 
            this.toolBtnReportPdfPrintVersionRu.Image = global::DistantVacantGovUz.Properties.Resources.pdf_doc;
            this.toolBtnReportPdfPrintVersionRu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnReportPdfPrintVersionRu.Name = "toolBtnReportPdfPrintVersionRu";
            this.toolBtnReportPdfPrintVersionRu.Size = new System.Drawing.Size(198, 54);
            this.toolBtnReportPdfPrintVersionRu.Text = "Print version (RU)";
            this.toolBtnReportPdfPrintVersionRu.Click += new System.EventHandler(this.toolBtnReportPdfPrintVersionRu_Click);
            // 
            // toolBtnReportPdfPrintVersionUz
            // 
            this.toolBtnReportPdfPrintVersionUz.Image = global::DistantVacantGovUz.Properties.Resources.pdf_doc;
            this.toolBtnReportPdfPrintVersionUz.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnReportPdfPrintVersionUz.Name = "toolBtnReportPdfPrintVersionUz";
            this.toolBtnReportPdfPrintVersionUz.Size = new System.Drawing.Size(198, 54);
            this.toolBtnReportPdfPrintVersionUz.Text = "Print version (UZ)";
            this.toolBtnReportPdfPrintVersionUz.Click += new System.EventHandler(this.toolBtnReportPdfPrintVersionUz_Click);
            // 
            // toolBtnReportXls
            // 
            this.toolBtnReportXls.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnReportXlsPrintVersionRu,
            this.toolBtnReportXlsPrintVersionUz});
            this.toolBtnReportXls.Image = global::DistantVacantGovUz.Properties.Resources.xls_doc;
            this.toolBtnReportXls.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnReportXls.Name = "toolBtnReportXls";
            this.toolBtnReportXls.Size = new System.Drawing.Size(184, 54);
            this.toolBtnReportXls.Text = "XLS";
            // 
            // toolBtnReportXlsPrintVersionRu
            // 
            this.toolBtnReportXlsPrintVersionRu.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnReportXlsPrintVersionRu.Image")));
            this.toolBtnReportXlsPrintVersionRu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnReportXlsPrintVersionRu.Name = "toolBtnReportXlsPrintVersionRu";
            this.toolBtnReportXlsPrintVersionRu.Size = new System.Drawing.Size(198, 54);
            this.toolBtnReportXlsPrintVersionRu.Text = "Print version (RU)";
            this.toolBtnReportXlsPrintVersionRu.Click += new System.EventHandler(this.toolBtnReportXlsPrintVersionRu_Click);
            // 
            // toolBtnReportXlsPrintVersionUz
            // 
            this.toolBtnReportXlsPrintVersionUz.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnReportXlsPrintVersionUz.Image")));
            this.toolBtnReportXlsPrintVersionUz.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnReportXlsPrintVersionUz.Name = "toolBtnReportXlsPrintVersionUz";
            this.toolBtnReportXlsPrintVersionUz.Size = new System.Drawing.Size(198, 54);
            this.toolBtnReportXlsPrintVersionUz.Text = "Print version (UZ)";
            this.toolBtnReportXlsPrintVersionUz.Click += new System.EventHandler(this.toolBtnReportXlsPrintVersionUz_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolBtnAdd
            // 
            this.toolBtnAdd.Image = global::DistantVacantGovUz.Properties.Resources.add_32;
            this.toolBtnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnAdd.Name = "toolBtnAdd";
            this.toolBtnAdd.Size = new System.Drawing.Size(65, 36);
            this.toolBtnAdd.Text = "Add";
            this.toolBtnAdd.Click += new System.EventHandler(this.toolBtnAdd_Click);
            // 
            // toolBtnImportFromFile
            // 
            this.toolBtnImportFromFile.Image = global::DistantVacantGovUz.Properties.Resources.import;
            this.toolBtnImportFromFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnImportFromFile.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolBtnImportFromFile.Name = "toolBtnImportFromFile";
            this.toolBtnImportFromFile.Size = new System.Drawing.Size(79, 36);
            this.toolBtnImportFromFile.Text = "Import";
            this.toolBtnImportFromFile.Click += new System.EventHandler(this.toolBtnImportFromFile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolBtnCheckAll
            // 
            this.toolBtnCheckAll.Image = global::DistantVacantGovUz.Properties.Resources.check_green_32;
            this.toolBtnCheckAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnCheckAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnCheckAll.Name = "toolBtnCheckAll";
            this.toolBtnCheckAll.Size = new System.Drawing.Size(93, 36);
            this.toolBtnCheckAll.Text = "Check All";
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
            this.toolBtnUncheckAll.Click += new System.EventHandler(this.toolBtnUncheckAll_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // toolBtnUndo
            // 
            this.toolBtnUndo.Enabled = false;
            this.toolBtnUndo.Image = global::DistantVacantGovUz.Properties.Resources.undo_32;
            this.toolBtnUndo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnUndo.Name = "toolBtnUndo";
            this.toolBtnUndo.Size = new System.Drawing.Size(72, 36);
            this.toolBtnUndo.Text = "Undo";
            // 
            // toolBtnRedo
            // 
            this.toolBtnRedo.Enabled = false;
            this.toolBtnRedo.Image = global::DistantVacantGovUz.Properties.Resources.redo_32;
            this.toolBtnRedo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnRedo.Name = "toolBtnRedo";
            this.toolBtnRedo.Size = new System.Drawing.Size(70, 36);
            this.toolBtnRedo.Text = "Redo";
            // 
            // toolBtnEditSelected
            // 
            this.toolBtnEditSelected.Enabled = false;
            this.toolBtnEditSelected.Image = global::DistantVacantGovUz.Properties.Resources.edit_32;
            this.toolBtnEditSelected.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnEditSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnEditSelected.Name = "toolBtnEditSelected";
            this.toolBtnEditSelected.Size = new System.Drawing.Size(63, 36);
            this.toolBtnEditSelected.Text = "Edit";
            this.toolBtnEditSelected.Click += new System.EventHandler(this.toolBtnEditSelected_Click);
            // 
            // toolBtnDeleteChecked
            // 
            this.toolBtnDeleteChecked.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolBtnDeleteChecked.Enabled = false;
            this.toolBtnDeleteChecked.Image = global::DistantVacantGovUz.Properties.Resources.delete_32;
            this.toolBtnDeleteChecked.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolBtnDeleteChecked.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnDeleteChecked.Name = "toolBtnDeleteChecked";
            this.toolBtnDeleteChecked.Size = new System.Drawing.Size(76, 36);
            this.toolBtnDeleteChecked.Text = "Delete";
            this.toolBtnDeleteChecked.Click += new System.EventHandler(this.toolBtnDeleteChecked_Click);
            // 
            // lstVacancies
            // 
            this.lstVacancies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstVacancies.CheckBoxes = true;
            this.lstVacancies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnCheckbox,
            this.clmnSeqNum,
            this.clmnPortalVacancyId,
            this.clmnDescriptionRu,
            this.clmnDescriptionUz,
            this.clmnCategory,
            this.clmnSalary,
            this.clmnEmployment,
            this.clmnGender,
            this.clmnExperience,
            this.clmnEducation,
            this.clmnExpireDate,
            this.clmnDepartmentRu,
            this.clmnSpecializationRu,
            this.clmnRequirementsRu,
            this.clmnInformationRu,
            this.clmnDepartmentUz,
            this.clmnSpecializationUz,
            this.clmnRequirementsUz,
            this.clmnInformationUz});
            this.lstVacancies.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstVacancies.FullRowSelect = true;
            this.lstVacancies.GridLines = true;
            this.lstVacancies.HideSelection = false;
            this.lstVacancies.Location = new System.Drawing.Point(0, 42);
            this.lstVacancies.Name = "lstVacancies";
            this.lstVacancies.Size = new System.Drawing.Size(892, 474);
            this.lstVacancies.TabIndex = 1;
            this.lstVacancies.UseCompatibleStateImageBehavior = false;
            this.lstVacancies.View = System.Windows.Forms.View.Details;
            this.lstVacancies.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstVacancies_ItemChecked);
            this.lstVacancies.SelectedIndexChanged += new System.EventHandler(this.lstVacancies_SelectedIndexChanged);
            this.lstVacancies.DoubleClick += new System.EventHandler(this.lstVacancies_DoubleClick);
            // 
            // clmnCheckbox
            // 
            this.clmnCheckbox.Text = "";
            this.clmnCheckbox.Width = 32;
            // 
            // clmnSeqNum
            // 
            this.clmnSeqNum.Text = "#";
            this.clmnSeqNum.Width = 50;
            // 
            // clmnPortalVacancyId
            // 
            this.clmnPortalVacancyId.Text = "Portal vacancy #";
            this.clmnPortalVacancyId.Width = 50;
            // 
            // clmnDescriptionRu
            // 
            this.clmnDescriptionRu.Text = "Description (RU)";
            this.clmnDescriptionRu.Width = 256;
            // 
            // clmnDescriptionUz
            // 
            this.clmnDescriptionUz.Text = "Description (UZ)";
            this.clmnDescriptionUz.Width = 256;
            // 
            // clmnCategory
            // 
            this.clmnCategory.Text = "Category";
            this.clmnCategory.Width = 256;
            // 
            // clmnSalary
            // 
            this.clmnSalary.Text = "Salary";
            this.clmnSalary.Width = 100;
            // 
            // clmnEmployment
            // 
            this.clmnEmployment.Text = "Employment";
            // 
            // clmnGender
            // 
            this.clmnGender.Text = "Gender";
            // 
            // clmnExperience
            // 
            this.clmnExperience.Text = "Experience";
            // 
            // clmnEducation
            // 
            this.clmnEducation.Text = "Education level";
            // 
            // clmnExpireDate
            // 
            this.clmnExpireDate.Text = "Expire date";
            // 
            // clmnDepartmentRu
            // 
            this.clmnDepartmentRu.Text = "Department (RU)";
            // 
            // clmnSpecializationRu
            // 
            this.clmnSpecializationRu.Text = "Specialization (RU)";
            // 
            // clmnRequirementsRu
            // 
            this.clmnRequirementsRu.Text = "Requirements (RU)";
            // 
            // clmnInformationRu
            // 
            this.clmnInformationRu.Text = "Information (RU)";
            // 
            // clmnDepartmentUz
            // 
            this.clmnDepartmentUz.Text = "Department (UZ)";
            // 
            // clmnSpecializationUz
            // 
            this.clmnSpecializationUz.Text = "Specialization (UZ)";
            // 
            // clmnRequirementsUz
            // 
            this.clmnRequirementsUz.Text = "Requirements (UZ)";
            // 
            // clmnInformationUz
            // 
            this.clmnInformationUz.Text = "Information (UZ)";
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsSelectedItems});
            this.status.Location = new System.Drawing.Point(0, 519);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(892, 22);
            this.status.TabIndex = 2;
            this.status.Text = "statusStrip1";
            // 
            // stsSelectedItems
            // 
            this.stsSelectedItems.Name = "stsSelectedItems";
            this.stsSelectedItems.Size = new System.Drawing.Size(63, 17);
            this.stsSelectedItems.Text = "Selected: 0";
            // 
            // frmLocalDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 541);
            this.Controls.Add(this.status);
            this.Controls.Add(this.lstVacancies);
            this.Controls.Add(this.toolbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLocalDocument";
            this.Text = "Local Vacancies";
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ListView lstVacancies;
        private System.Windows.Forms.ColumnHeader clmnCheckbox;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel stsSelectedItems;
        private System.Windows.Forms.ColumnHeader clmnSeqNum;
        private System.Windows.Forms.ColumnHeader clmnPortalVacancyId;
        private System.Windows.Forms.ColumnHeader clmnDescriptionRu;
        private System.Windows.Forms.ColumnHeader clmnDescriptionUz;
        private System.Windows.Forms.ColumnHeader clmnCategory;
        private System.Windows.Forms.ColumnHeader clmnSalary;
        private System.Windows.Forms.ColumnHeader clmnEmployment;
        private System.Windows.Forms.ColumnHeader clmnGender;
        private System.Windows.Forms.ColumnHeader clmnExperience;
        private System.Windows.Forms.ColumnHeader clmnEducation;
        private System.Windows.Forms.ColumnHeader clmnExpireDate;
        private System.Windows.Forms.ColumnHeader clmnDepartmentRu;
        private System.Windows.Forms.ColumnHeader clmnSpecializationRu;
        private System.Windows.Forms.ColumnHeader clmnRequirementsRu;
        private System.Windows.Forms.ColumnHeader clmnInformationRu;
        private System.Windows.Forms.ColumnHeader clmnDepartmentUz;
        private System.Windows.Forms.ColumnHeader clmnSpecializationUz;
        private System.Windows.Forms.ColumnHeader clmnRequirementsUz;
        private System.Windows.Forms.ColumnHeader clmnInformationUz;
        private System.Windows.Forms.ToolStripButton toolBtnSave;
        private System.Windows.Forms.ToolStripButton toolBtnSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolBtnAdd;
        private System.Windows.Forms.ToolStripButton toolBtnImportFromFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolBtnCheckAll;
        private System.Windows.Forms.ToolStripButton toolBtnUncheckAll;
        private System.Windows.Forms.ToolStripButton toolBtnEditSelected;
        private System.Windows.Forms.ToolStripButton toolBtnDeleteChecked;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolBtnUndo;
        private System.Windows.Forms.ToolStripButton toolBtnRedo;
        private System.Windows.Forms.ToolStripDropDownButton toolBtnReport;
        private System.Windows.Forms.ToolStripMenuItem toolBtnReportPdf;
        private System.Windows.Forms.ToolStripMenuItem toolBtnReportXls;
        private System.Windows.Forms.ToolStripMenuItem toolBtnReportPdfPrintVersionRu;
        private System.Windows.Forms.ToolStripMenuItem toolBtnReportPdfPrintVersionUz;
        private System.Windows.Forms.ToolStripMenuItem toolBtnReportXlsPrintVersionRu;
        private System.Windows.Forms.ToolStripMenuItem toolBtnReportXlsPrintVersionUz;

    }
}