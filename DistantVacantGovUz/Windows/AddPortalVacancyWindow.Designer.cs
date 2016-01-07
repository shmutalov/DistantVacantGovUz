namespace DistantVacantGovUz.Windows
{
    partial class AddPortalVacancyWindow
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPortalVacancyWindow));
            this.btnAddMore = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tabAddVacancy = new System.Windows.Forms.TabControl();
            this.tbGeneral = new System.Windows.Forms.TabPage();
            this.dateVacExpire = new System.Windows.Forms.DateTimePicker();
            this.lblExpireDate = new System.Windows.Forms.Label();
            this.cmbVacEducation = new System.Windows.Forms.ComboBox();
            this.lblEducation = new System.Windows.Forms.Label();
            this.cmbVacExperience = new System.Windows.Forms.ComboBox();
            this.lblExperience = new System.Windows.Forms.Label();
            this.cmbVacGender = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.cmbVacEmployment = new System.Windows.Forms.ComboBox();
            this.lblEmployment = new System.Windows.Forms.Label();
            this.txtVacSalary = new System.Windows.Forms.TextBox();
            this.lblSalary = new System.Windows.Forms.Label();
            this.cmbVacCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtVacDescUZ = new System.Windows.Forms.TextBox();
            this.lblDescriptionUZ = new System.Windows.Forms.Label();
            this.txtVacDescRU = new System.Windows.Forms.TextBox();
            this.lblDescriptionRU = new System.Windows.Forms.Label();
            this.tbRussian = new System.Windows.Forms.TabPage();
            this.txtVacInformationRU = new System.Windows.Forms.TextBox();
            this.lblInformationRU = new System.Windows.Forms.Label();
            this.txtVacRequirementsRU = new System.Windows.Forms.TextBox();
            this.lblRequirementsRU = new System.Windows.Forms.Label();
            this.txtVacSpecializationRU = new System.Windows.Forms.TextBox();
            this.lblSpecializationRU = new System.Windows.Forms.Label();
            this.txtVacDepartmentRU = new System.Windows.Forms.TextBox();
            this.lblDepartmentRU = new System.Windows.Forms.Label();
            this.tbUzbek = new System.Windows.Forms.TabPage();
            this.txtVacInformationUZ = new System.Windows.Forms.TextBox();
            this.lblInformationUZ = new System.Windows.Forms.Label();
            this.txtVacRequirementsUZ = new System.Windows.Forms.TextBox();
            this.lblRequirementsUZ = new System.Windows.Forms.Label();
            this.txtVacSpecializationUZ = new System.Windows.Forms.TextBox();
            this.lblSpecializationUZ = new System.Windows.Forms.Label();
            this.txtVacDepartmentUZ = new System.Windows.Forms.TextBox();
            this.lblDepartmentUZ = new System.Windows.Forms.Label();
            this.tabAddVacancy.SuspendLayout();
            this.tbGeneral.SuspendLayout();
            this.tbRussian.SuspendLayout();
            this.tbUzbek.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddMore
            // 
            this.btnAddMore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.btnAddMore, "btnAddMore");
            this.btnAddMore.Name = "btnAddMore";
            this.btnAddMore.UseVisualStyleBackColor = false;
            this.btnAddMore.Click += new System.EventHandler(this.btnAddMore_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tabAddVacancy
            // 
            resources.ApplyResources(this.tabAddVacancy, "tabAddVacancy");
            this.tabAddVacancy.Controls.Add(this.tbGeneral);
            this.tabAddVacancy.Controls.Add(this.tbRussian);
            this.tabAddVacancy.Controls.Add(this.tbUzbek);
            this.tabAddVacancy.Name = "tabAddVacancy";
            this.tabAddVacancy.SelectedIndex = 0;
            // 
            // tbGeneral
            // 
            this.tbGeneral.Controls.Add(this.dateVacExpire);
            this.tbGeneral.Controls.Add(this.lblExpireDate);
            this.tbGeneral.Controls.Add(this.cmbVacEducation);
            this.tbGeneral.Controls.Add(this.lblEducation);
            this.tbGeneral.Controls.Add(this.cmbVacExperience);
            this.tbGeneral.Controls.Add(this.lblExperience);
            this.tbGeneral.Controls.Add(this.cmbVacGender);
            this.tbGeneral.Controls.Add(this.lblGender);
            this.tbGeneral.Controls.Add(this.cmbVacEmployment);
            this.tbGeneral.Controls.Add(this.lblEmployment);
            this.tbGeneral.Controls.Add(this.txtVacSalary);
            this.tbGeneral.Controls.Add(this.lblSalary);
            this.tbGeneral.Controls.Add(this.cmbVacCategory);
            this.tbGeneral.Controls.Add(this.lblCategory);
            this.tbGeneral.Controls.Add(this.txtVacDescUZ);
            this.tbGeneral.Controls.Add(this.lblDescriptionUZ);
            this.tbGeneral.Controls.Add(this.txtVacDescRU);
            this.tbGeneral.Controls.Add(this.lblDescriptionRU);
            resources.ApplyResources(this.tbGeneral, "tbGeneral");
            this.tbGeneral.Name = "tbGeneral";
            this.tbGeneral.UseVisualStyleBackColor = true;
            // 
            // dateVacExpire
            // 
            resources.ApplyResources(this.dateVacExpire, "dateVacExpire");
            this.dateVacExpire.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateVacExpire.Name = "dateVacExpire";
            // 
            // lblExpireDate
            // 
            resources.ApplyResources(this.lblExpireDate, "lblExpireDate");
            this.lblExpireDate.Name = "lblExpireDate";
            // 
            // cmbVacEducation
            // 
            resources.ApplyResources(this.cmbVacEducation, "cmbVacEducation");
            this.cmbVacEducation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVacEducation.FormattingEnabled = true;
            this.cmbVacEducation.Items.AddRange(new object[] {
            resources.GetString("cmbVacEducation.Items"),
            resources.GetString("cmbVacEducation.Items1"),
            resources.GetString("cmbVacEducation.Items2"),
            resources.GetString("cmbVacEducation.Items3"),
            resources.GetString("cmbVacEducation.Items4")});
            this.cmbVacEducation.Name = "cmbVacEducation";
            // 
            // lblEducation
            // 
            resources.ApplyResources(this.lblEducation, "lblEducation");
            this.lblEducation.Name = "lblEducation";
            // 
            // cmbVacExperience
            // 
            resources.ApplyResources(this.cmbVacExperience, "cmbVacExperience");
            this.cmbVacExperience.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVacExperience.FormattingEnabled = true;
            this.cmbVacExperience.Items.AddRange(new object[] {
            resources.GetString("cmbVacExperience.Items"),
            resources.GetString("cmbVacExperience.Items1"),
            resources.GetString("cmbVacExperience.Items2"),
            resources.GetString("cmbVacExperience.Items3"),
            resources.GetString("cmbVacExperience.Items4")});
            this.cmbVacExperience.Name = "cmbVacExperience";
            // 
            // lblExperience
            // 
            resources.ApplyResources(this.lblExperience, "lblExperience");
            this.lblExperience.Name = "lblExperience";
            // 
            // cmbVacGender
            // 
            resources.ApplyResources(this.cmbVacGender, "cmbVacGender");
            this.cmbVacGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVacGender.FormattingEnabled = true;
            this.cmbVacGender.Items.AddRange(new object[] {
            resources.GetString("cmbVacGender.Items"),
            resources.GetString("cmbVacGender.Items1"),
            resources.GetString("cmbVacGender.Items2")});
            this.cmbVacGender.Name = "cmbVacGender";
            // 
            // lblGender
            // 
            resources.ApplyResources(this.lblGender, "lblGender");
            this.lblGender.Name = "lblGender";
            // 
            // cmbVacEmployment
            // 
            resources.ApplyResources(this.cmbVacEmployment, "cmbVacEmployment");
            this.cmbVacEmployment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVacEmployment.FormattingEnabled = true;
            this.cmbVacEmployment.Items.AddRange(new object[] {
            resources.GetString("cmbVacEmployment.Items"),
            resources.GetString("cmbVacEmployment.Items1"),
            resources.GetString("cmbVacEmployment.Items2"),
            resources.GetString("cmbVacEmployment.Items3"),
            resources.GetString("cmbVacEmployment.Items4")});
            this.cmbVacEmployment.Name = "cmbVacEmployment";
            // 
            // lblEmployment
            // 
            resources.ApplyResources(this.lblEmployment, "lblEmployment");
            this.lblEmployment.Name = "lblEmployment";
            // 
            // txtVacSalary
            // 
            resources.ApplyResources(this.txtVacSalary, "txtVacSalary");
            this.txtVacSalary.Name = "txtVacSalary";
            // 
            // lblSalary
            // 
            resources.ApplyResources(this.lblSalary, "lblSalary");
            this.lblSalary.Name = "lblSalary";
            // 
            // cmbVacCategory
            // 
            resources.ApplyResources(this.cmbVacCategory, "cmbVacCategory");
            this.cmbVacCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVacCategory.FormattingEnabled = true;
            this.cmbVacCategory.Items.AddRange(new object[] {
            resources.GetString("cmbVacCategory.Items"),
            resources.GetString("cmbVacCategory.Items1"),
            resources.GetString("cmbVacCategory.Items2"),
            resources.GetString("cmbVacCategory.Items3"),
            resources.GetString("cmbVacCategory.Items4"),
            resources.GetString("cmbVacCategory.Items5"),
            resources.GetString("cmbVacCategory.Items6"),
            resources.GetString("cmbVacCategory.Items7"),
            resources.GetString("cmbVacCategory.Items8"),
            resources.GetString("cmbVacCategory.Items9"),
            resources.GetString("cmbVacCategory.Items10"),
            resources.GetString("cmbVacCategory.Items11"),
            resources.GetString("cmbVacCategory.Items12"),
            resources.GetString("cmbVacCategory.Items13"),
            resources.GetString("cmbVacCategory.Items14"),
            resources.GetString("cmbVacCategory.Items15"),
            resources.GetString("cmbVacCategory.Items16"),
            resources.GetString("cmbVacCategory.Items17"),
            resources.GetString("cmbVacCategory.Items18"),
            resources.GetString("cmbVacCategory.Items19"),
            resources.GetString("cmbVacCategory.Items20"),
            resources.GetString("cmbVacCategory.Items21"),
            resources.GetString("cmbVacCategory.Items22"),
            resources.GetString("cmbVacCategory.Items23"),
            resources.GetString("cmbVacCategory.Items24"),
            resources.GetString("cmbVacCategory.Items25"),
            resources.GetString("cmbVacCategory.Items26"),
            resources.GetString("cmbVacCategory.Items27"),
            resources.GetString("cmbVacCategory.Items28")});
            this.cmbVacCategory.Name = "cmbVacCategory";
            // 
            // lblCategory
            // 
            resources.ApplyResources(this.lblCategory, "lblCategory");
            this.lblCategory.Name = "lblCategory";
            // 
            // txtVacDescUZ
            // 
            resources.ApplyResources(this.txtVacDescUZ, "txtVacDescUZ");
            this.txtVacDescUZ.Name = "txtVacDescUZ";
            // 
            // lblDescriptionUZ
            // 
            resources.ApplyResources(this.lblDescriptionUZ, "lblDescriptionUZ");
            this.lblDescriptionUZ.Name = "lblDescriptionUZ";
            // 
            // txtVacDescRU
            // 
            resources.ApplyResources(this.txtVacDescRU, "txtVacDescRU");
            this.txtVacDescRU.Name = "txtVacDescRU";
            // 
            // lblDescriptionRU
            // 
            resources.ApplyResources(this.lblDescriptionRU, "lblDescriptionRU");
            this.lblDescriptionRU.Name = "lblDescriptionRU";
            // 
            // tbRussian
            // 
            this.tbRussian.Controls.Add(this.txtVacInformationRU);
            this.tbRussian.Controls.Add(this.lblInformationRU);
            this.tbRussian.Controls.Add(this.txtVacRequirementsRU);
            this.tbRussian.Controls.Add(this.lblRequirementsRU);
            this.tbRussian.Controls.Add(this.txtVacSpecializationRU);
            this.tbRussian.Controls.Add(this.lblSpecializationRU);
            this.tbRussian.Controls.Add(this.txtVacDepartmentRU);
            this.tbRussian.Controls.Add(this.lblDepartmentRU);
            resources.ApplyResources(this.tbRussian, "tbRussian");
            this.tbRussian.Name = "tbRussian";
            this.tbRussian.UseVisualStyleBackColor = true;
            // 
            // txtVacInformationRU
            // 
            resources.ApplyResources(this.txtVacInformationRU, "txtVacInformationRU");
            this.txtVacInformationRU.Name = "txtVacInformationRU";
            // 
            // lblInformationRU
            // 
            resources.ApplyResources(this.lblInformationRU, "lblInformationRU");
            this.lblInformationRU.Name = "lblInformationRU";
            // 
            // txtVacRequirementsRU
            // 
            resources.ApplyResources(this.txtVacRequirementsRU, "txtVacRequirementsRU");
            this.txtVacRequirementsRU.Name = "txtVacRequirementsRU";
            // 
            // lblRequirementsRU
            // 
            resources.ApplyResources(this.lblRequirementsRU, "lblRequirementsRU");
            this.lblRequirementsRU.Name = "lblRequirementsRU";
            // 
            // txtVacSpecializationRU
            // 
            resources.ApplyResources(this.txtVacSpecializationRU, "txtVacSpecializationRU");
            this.txtVacSpecializationRU.Name = "txtVacSpecializationRU";
            // 
            // lblSpecializationRU
            // 
            resources.ApplyResources(this.lblSpecializationRU, "lblSpecializationRU");
            this.lblSpecializationRU.Name = "lblSpecializationRU";
            // 
            // txtVacDepartmentRU
            // 
            resources.ApplyResources(this.txtVacDepartmentRU, "txtVacDepartmentRU");
            this.txtVacDepartmentRU.Name = "txtVacDepartmentRU";
            // 
            // lblDepartmentRU
            // 
            resources.ApplyResources(this.lblDepartmentRU, "lblDepartmentRU");
            this.lblDepartmentRU.Name = "lblDepartmentRU";
            // 
            // tbUzbek
            // 
            this.tbUzbek.Controls.Add(this.txtVacInformationUZ);
            this.tbUzbek.Controls.Add(this.lblInformationUZ);
            this.tbUzbek.Controls.Add(this.txtVacRequirementsUZ);
            this.tbUzbek.Controls.Add(this.lblRequirementsUZ);
            this.tbUzbek.Controls.Add(this.txtVacSpecializationUZ);
            this.tbUzbek.Controls.Add(this.lblSpecializationUZ);
            this.tbUzbek.Controls.Add(this.txtVacDepartmentUZ);
            this.tbUzbek.Controls.Add(this.lblDepartmentUZ);
            resources.ApplyResources(this.tbUzbek, "tbUzbek");
            this.tbUzbek.Name = "tbUzbek";
            this.tbUzbek.UseVisualStyleBackColor = true;
            // 
            // txtVacInformationUZ
            // 
            resources.ApplyResources(this.txtVacInformationUZ, "txtVacInformationUZ");
            this.txtVacInformationUZ.Name = "txtVacInformationUZ";
            // 
            // lblInformationUZ
            // 
            resources.ApplyResources(this.lblInformationUZ, "lblInformationUZ");
            this.lblInformationUZ.Name = "lblInformationUZ";
            // 
            // txtVacRequirementsUZ
            // 
            resources.ApplyResources(this.txtVacRequirementsUZ, "txtVacRequirementsUZ");
            this.txtVacRequirementsUZ.Name = "txtVacRequirementsUZ";
            // 
            // lblRequirementsUZ
            // 
            resources.ApplyResources(this.lblRequirementsUZ, "lblRequirementsUZ");
            this.lblRequirementsUZ.Name = "lblRequirementsUZ";
            // 
            // txtVacSpecializationUZ
            // 
            resources.ApplyResources(this.txtVacSpecializationUZ, "txtVacSpecializationUZ");
            this.txtVacSpecializationUZ.Name = "txtVacSpecializationUZ";
            // 
            // lblSpecializationUZ
            // 
            resources.ApplyResources(this.lblSpecializationUZ, "lblSpecializationUZ");
            this.lblSpecializationUZ.Name = "lblSpecializationUZ";
            // 
            // txtVacDepartmentUZ
            // 
            resources.ApplyResources(this.txtVacDepartmentUZ, "txtVacDepartmentUZ");
            this.txtVacDepartmentUZ.Name = "txtVacDepartmentUZ";
            // 
            // lblDepartmentUZ
            // 
            resources.ApplyResources(this.lblDepartmentUZ, "lblDepartmentUZ");
            this.lblDepartmentUZ.Name = "lblDepartmentUZ";
            // 
            // frmAddPortalVacancy
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddMore);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tabAddVacancy);
            this.Name = "AddPortalVacancyWindow";
            this.tabAddVacancy.ResumeLayout(false);
            this.tbGeneral.ResumeLayout(false);
            this.tbGeneral.PerformLayout();
            this.tbRussian.ResumeLayout(false);
            this.tbRussian.PerformLayout();
            this.tbUzbek.ResumeLayout(false);
            this.tbUzbek.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddMore;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TabControl tabAddVacancy;
        private System.Windows.Forms.TabPage tbGeneral;
        private System.Windows.Forms.DateTimePicker dateVacExpire;
        private System.Windows.Forms.Label lblExpireDate;
        private System.Windows.Forms.ComboBox cmbVacEducation;
        private System.Windows.Forms.Label lblEducation;
        private System.Windows.Forms.ComboBox cmbVacExperience;
        private System.Windows.Forms.Label lblExperience;
        private System.Windows.Forms.ComboBox cmbVacGender;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cmbVacEmployment;
        private System.Windows.Forms.Label lblEmployment;
        private System.Windows.Forms.TextBox txtVacSalary;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.ComboBox cmbVacCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtVacDescUZ;
        private System.Windows.Forms.Label lblDescriptionUZ;
        private System.Windows.Forms.TextBox txtVacDescRU;
        private System.Windows.Forms.Label lblDescriptionRU;
        private System.Windows.Forms.TabPage tbRussian;
        private System.Windows.Forms.TextBox txtVacInformationRU;
        private System.Windows.Forms.Label lblInformationRU;
        private System.Windows.Forms.TextBox txtVacRequirementsRU;
        private System.Windows.Forms.Label lblRequirementsRU;
        private System.Windows.Forms.TextBox txtVacSpecializationRU;
        private System.Windows.Forms.Label lblSpecializationRU;
        private System.Windows.Forms.TextBox txtVacDepartmentRU;
        private System.Windows.Forms.Label lblDepartmentRU;
        private System.Windows.Forms.TabPage tbUzbek;
        private System.Windows.Forms.TextBox txtVacInformationUZ;
        private System.Windows.Forms.Label lblInformationUZ;
        private System.Windows.Forms.TextBox txtVacRequirementsUZ;
        private System.Windows.Forms.Label lblRequirementsUZ;
        private System.Windows.Forms.TextBox txtVacSpecializationUZ;
        private System.Windows.Forms.Label lblSpecializationUZ;
        private System.Windows.Forms.TextBox txtVacDepartmentUZ;
        private System.Windows.Forms.Label lblDepartmentUZ;
    }
}