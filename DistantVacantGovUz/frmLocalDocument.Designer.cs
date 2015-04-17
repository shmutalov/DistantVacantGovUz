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
            this.lstVacancies = new System.Windows.Forms.ListViewEx();
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
            resources.ApplyResources(this.toolbar, "toolbar");
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
            this.toolbar.Name = "toolbar";
            // 
            // toolBtnSave
            // 
            resources.ApplyResources(this.toolBtnSave, "toolBtnSave");
            this.toolBtnSave.Image = global::DistantVacantGovUz.Properties.Resources.save_24;
            this.toolBtnSave.Name = "toolBtnSave";
            this.toolBtnSave.Click += new System.EventHandler(this.toolBtnSave_Click);
            // 
            // toolBtnSaveAs
            // 
            resources.ApplyResources(this.toolBtnSaveAs, "toolBtnSaveAs");
            this.toolBtnSaveAs.Image = global::DistantVacantGovUz.Properties.Resources.save_24;
            this.toolBtnSaveAs.Name = "toolBtnSaveAs";
            this.toolBtnSaveAs.Click += new System.EventHandler(this.toolBtnSaveAs_Click);
            // 
            // toolBtnReport
            // 
            resources.ApplyResources(this.toolBtnReport, "toolBtnReport");
            this.toolBtnReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnReportPdf,
            this.toolBtnReportXls});
            this.toolBtnReport.Image = global::DistantVacantGovUz.Properties.Resources.report_24;
            this.toolBtnReport.Name = "toolBtnReport";
            // 
            // toolBtnReportPdf
            // 
            resources.ApplyResources(this.toolBtnReportPdf, "toolBtnReportPdf");
            this.toolBtnReportPdf.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnReportPdfPrintVersionRu,
            this.toolBtnReportPdfPrintVersionUz});
            this.toolBtnReportPdf.Name = "toolBtnReportPdf";
            // 
            // toolBtnReportPdfPrintVersionRu
            // 
            resources.ApplyResources(this.toolBtnReportPdfPrintVersionRu, "toolBtnReportPdfPrintVersionRu");
            this.toolBtnReportPdfPrintVersionRu.Name = "toolBtnReportPdfPrintVersionRu";
            this.toolBtnReportPdfPrintVersionRu.Click += new System.EventHandler(this.toolBtnReportPdfPrintVersionRu_Click);
            // 
            // toolBtnReportPdfPrintVersionUz
            // 
            resources.ApplyResources(this.toolBtnReportPdfPrintVersionUz, "toolBtnReportPdfPrintVersionUz");
            this.toolBtnReportPdfPrintVersionUz.Name = "toolBtnReportPdfPrintVersionUz";
            this.toolBtnReportPdfPrintVersionUz.Click += new System.EventHandler(this.toolBtnReportPdfPrintVersionUz_Click);
            // 
            // toolBtnReportXls
            // 
            resources.ApplyResources(this.toolBtnReportXls, "toolBtnReportXls");
            this.toolBtnReportXls.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnReportXlsPrintVersionRu,
            this.toolBtnReportXlsPrintVersionUz});
            this.toolBtnReportXls.Name = "toolBtnReportXls";
            // 
            // toolBtnReportXlsPrintVersionRu
            // 
            resources.ApplyResources(this.toolBtnReportXlsPrintVersionRu, "toolBtnReportXlsPrintVersionRu");
            this.toolBtnReportXlsPrintVersionRu.Name = "toolBtnReportXlsPrintVersionRu";
            this.toolBtnReportXlsPrintVersionRu.Click += new System.EventHandler(this.toolBtnReportXlsPrintVersionRu_Click);
            // 
            // toolBtnReportXlsPrintVersionUz
            // 
            resources.ApplyResources(this.toolBtnReportXlsPrintVersionUz, "toolBtnReportXlsPrintVersionUz");
            this.toolBtnReportXlsPrintVersionUz.Name = "toolBtnReportXlsPrintVersionUz";
            this.toolBtnReportXlsPrintVersionUz.Click += new System.EventHandler(this.toolBtnReportXlsPrintVersionUz_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // toolBtnAdd
            // 
            resources.ApplyResources(this.toolBtnAdd, "toolBtnAdd");
            this.toolBtnAdd.Image = global::DistantVacantGovUz.Properties.Resources.add_24;
            this.toolBtnAdd.Name = "toolBtnAdd";
            this.toolBtnAdd.Click += new System.EventHandler(this.toolBtnAdd_Click);
            // 
            // toolBtnImportFromFile
            // 
            resources.ApplyResources(this.toolBtnImportFromFile, "toolBtnImportFromFile");
            this.toolBtnImportFromFile.Image = global::DistantVacantGovUz.Properties.Resources.import_24;
            this.toolBtnImportFromFile.Name = "toolBtnImportFromFile";
            this.toolBtnImportFromFile.Click += new System.EventHandler(this.toolBtnImportFromFile_Click);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
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
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // toolBtnUndo
            // 
            resources.ApplyResources(this.toolBtnUndo, "toolBtnUndo");
            this.toolBtnUndo.Image = global::DistantVacantGovUz.Properties.Resources.undo_24;
            this.toolBtnUndo.Name = "toolBtnUndo";
            this.toolBtnUndo.Click += new System.EventHandler(this.toolBtnUndo_Click);
            // 
            // toolBtnRedo
            // 
            resources.ApplyResources(this.toolBtnRedo, "toolBtnRedo");
            this.toolBtnRedo.Image = global::DistantVacantGovUz.Properties.Resources.redo_24;
            this.toolBtnRedo.Name = "toolBtnRedo";
            this.toolBtnRedo.Click += new System.EventHandler(this.toolBtnRedo_Click);
            // 
            // toolBtnEditSelected
            // 
            resources.ApplyResources(this.toolBtnEditSelected, "toolBtnEditSelected");
            this.toolBtnEditSelected.Image = global::DistantVacantGovUz.Properties.Resources.edit_24;
            this.toolBtnEditSelected.Name = "toolBtnEditSelected";
            this.toolBtnEditSelected.Click += new System.EventHandler(this.toolBtnEditSelected_Click);
            // 
            // toolBtnDeleteChecked
            // 
            resources.ApplyResources(this.toolBtnDeleteChecked, "toolBtnDeleteChecked");
            this.toolBtnDeleteChecked.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolBtnDeleteChecked.Image = global::DistantVacantGovUz.Properties.Resources.delete_24;
            this.toolBtnDeleteChecked.Name = "toolBtnDeleteChecked";
            this.toolBtnDeleteChecked.Click += new System.EventHandler(this.toolBtnDeleteChecked_Click);
            // 
            // lstVacancies
            // 
            resources.ApplyResources(this.lstVacancies, "lstVacancies");
            this.lstVacancies.AllowColumnReorder = true;
            this.lstVacancies.AllowDrop = true;
            this.lstVacancies.AllowRowReorder = true;
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
            this.lstVacancies.FullRowSelect = true;
            this.lstVacancies.GridLines = true;
            this.lstVacancies.HideSelection = false;
            this.lstVacancies.InsertionMarkColor = System.Drawing.Color.SteelBlue;
            this.lstVacancies.Name = "lstVacancies";
            this.lstVacancies.UseCompatibleStateImageBehavior = false;
            this.lstVacancies.View = System.Windows.Forms.View.Details;
            this.lstVacancies.BeforeRowReorder += new System.Windows.Forms.ListViewEx.BeforeRowReorderEventHandler(this.lstVacancies_BeforeRowReorder);
            this.lstVacancies.AfterRowReorder += new System.Windows.Forms.ListViewEx.AfterRowReorderEventHandler(this.lstVacancies_AfterRowReorder);
            this.lstVacancies.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstVacancies_ItemChecked);
            this.lstVacancies.SelectedIndexChanged += new System.EventHandler(this.lstVacancies_SelectedIndexChanged);
            this.lstVacancies.DoubleClick += new System.EventHandler(this.lstVacancies_DoubleClick);
            // 
            // clmnCheckbox
            // 
            resources.ApplyResources(this.clmnCheckbox, "clmnCheckbox");
            // 
            // clmnSeqNum
            // 
            resources.ApplyResources(this.clmnSeqNum, "clmnSeqNum");
            // 
            // clmnPortalVacancyId
            // 
            resources.ApplyResources(this.clmnPortalVacancyId, "clmnPortalVacancyId");
            // 
            // clmnDescriptionRu
            // 
            resources.ApplyResources(this.clmnDescriptionRu, "clmnDescriptionRu");
            // 
            // clmnDescriptionUz
            // 
            resources.ApplyResources(this.clmnDescriptionUz, "clmnDescriptionUz");
            // 
            // clmnCategory
            // 
            resources.ApplyResources(this.clmnCategory, "clmnCategory");
            // 
            // clmnSalary
            // 
            resources.ApplyResources(this.clmnSalary, "clmnSalary");
            // 
            // clmnEmployment
            // 
            resources.ApplyResources(this.clmnEmployment, "clmnEmployment");
            // 
            // clmnGender
            // 
            resources.ApplyResources(this.clmnGender, "clmnGender");
            // 
            // clmnExperience
            // 
            resources.ApplyResources(this.clmnExperience, "clmnExperience");
            // 
            // clmnEducation
            // 
            resources.ApplyResources(this.clmnEducation, "clmnEducation");
            // 
            // clmnExpireDate
            // 
            resources.ApplyResources(this.clmnExpireDate, "clmnExpireDate");
            // 
            // clmnDepartmentRu
            // 
            resources.ApplyResources(this.clmnDepartmentRu, "clmnDepartmentRu");
            // 
            // clmnSpecializationRu
            // 
            resources.ApplyResources(this.clmnSpecializationRu, "clmnSpecializationRu");
            // 
            // clmnRequirementsRu
            // 
            resources.ApplyResources(this.clmnRequirementsRu, "clmnRequirementsRu");
            // 
            // clmnInformationRu
            // 
            resources.ApplyResources(this.clmnInformationRu, "clmnInformationRu");
            // 
            // clmnDepartmentUz
            // 
            resources.ApplyResources(this.clmnDepartmentUz, "clmnDepartmentUz");
            // 
            // clmnSpecializationUz
            // 
            resources.ApplyResources(this.clmnSpecializationUz, "clmnSpecializationUz");
            // 
            // clmnRequirementsUz
            // 
            resources.ApplyResources(this.clmnRequirementsUz, "clmnRequirementsUz");
            // 
            // clmnInformationUz
            // 
            resources.ApplyResources(this.clmnInformationUz, "clmnInformationUz");
            // 
            // status
            // 
            resources.ApplyResources(this.status, "status");
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsSelectedItems});
            this.status.Name = "status";
            // 
            // stsSelectedItems
            // 
            resources.ApplyResources(this.stsSelectedItems, "stsSelectedItems");
            this.stsSelectedItems.Name = "stsSelectedItems";
            // 
            // frmLocalDocument
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.status);
            this.Controls.Add(this.lstVacancies);
            this.Controls.Add(this.toolbar);
            this.Name = "frmLocalDocument";
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolbar;
        //private System.Windows.Forms.ListView lstVacancies;
        private System.Windows.Forms.ListViewEx lstVacancies;
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