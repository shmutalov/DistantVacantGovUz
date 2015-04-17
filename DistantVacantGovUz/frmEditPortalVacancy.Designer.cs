namespace DistantVacantGovUz
{
    partial class frmEditPortalVacancy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditPortalVacancy));
            this.btnSave = new System.Windows.Forms.Button();
            this.tabAddVacancy = new System.Windows.Forms.TabControl();
            this.tbGeneral = new System.Windows.Forms.TabPage();
            this.cmbVacStatus = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dateVacExpire = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbVacEducation = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbVacExperience = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbVacGender = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbVacEmployment = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVacSalary = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbVacCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVacDescUZ = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVacDescRU = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRussian = new System.Windows.Forms.TabPage();
            this.txtVacInformationRU = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtVacRequirementsRU = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtVacSpecializationRU = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtVacDepartmentRU = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbUzbek = new System.Windows.Forms.TabPage();
            this.txtVacInformationUZ = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtVacRequirementsUZ = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtVacSpecializationUZ = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtVacDepartmentUZ = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tabAddVacancy.SuspendLayout();
            this.tbGeneral.SuspendLayout();
            this.tbRussian.SuspendLayout();
            this.tbUzbek.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.tbGeneral.Controls.Add(this.cmbVacStatus);
            this.tbGeneral.Controls.Add(this.label10);
            this.tbGeneral.Controls.Add(this.dateVacExpire);
            this.tbGeneral.Controls.Add(this.label9);
            this.tbGeneral.Controls.Add(this.cmbVacEducation);
            this.tbGeneral.Controls.Add(this.label8);
            this.tbGeneral.Controls.Add(this.cmbVacExperience);
            this.tbGeneral.Controls.Add(this.label7);
            this.tbGeneral.Controls.Add(this.cmbVacGender);
            this.tbGeneral.Controls.Add(this.label6);
            this.tbGeneral.Controls.Add(this.cmbVacEmployment);
            this.tbGeneral.Controls.Add(this.label5);
            this.tbGeneral.Controls.Add(this.txtVacSalary);
            this.tbGeneral.Controls.Add(this.label4);
            this.tbGeneral.Controls.Add(this.cmbVacCategory);
            this.tbGeneral.Controls.Add(this.label3);
            this.tbGeneral.Controls.Add(this.txtVacDescUZ);
            this.tbGeneral.Controls.Add(this.label2);
            this.tbGeneral.Controls.Add(this.txtVacDescRU);
            this.tbGeneral.Controls.Add(this.label1);
            resources.ApplyResources(this.tbGeneral, "tbGeneral");
            this.tbGeneral.Name = "tbGeneral";
            this.tbGeneral.UseVisualStyleBackColor = true;
            // 
            // cmbVacStatus
            // 
            resources.ApplyResources(this.cmbVacStatus, "cmbVacStatus");
            this.cmbVacStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVacStatus.FormattingEnabled = true;
            this.cmbVacStatus.Items.AddRange(new object[] {
            resources.GetString("cmbVacStatus.Items"),
            resources.GetString("cmbVacStatus.Items1")});
            this.cmbVacStatus.Name = "cmbVacStatus";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // dateVacExpire
            // 
            resources.ApplyResources(this.dateVacExpire, "dateVacExpire");
            this.dateVacExpire.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateVacExpire.Name = "dateVacExpire";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
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
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
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
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
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
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
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
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtVacSalary
            // 
            resources.ApplyResources(this.txtVacSalary, "txtVacSalary");
            this.txtVacSalary.Name = "txtVacSalary";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
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
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtVacDescUZ
            // 
            resources.ApplyResources(this.txtVacDescUZ, "txtVacDescUZ");
            this.txtVacDescUZ.Name = "txtVacDescUZ";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtVacDescRU
            // 
            resources.ApplyResources(this.txtVacDescRU, "txtVacDescRU");
            this.txtVacDescRU.Name = "txtVacDescRU";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tbRussian
            // 
            this.tbRussian.Controls.Add(this.txtVacInformationRU);
            this.tbRussian.Controls.Add(this.label14);
            this.tbRussian.Controls.Add(this.txtVacRequirementsRU);
            this.tbRussian.Controls.Add(this.label13);
            this.tbRussian.Controls.Add(this.txtVacSpecializationRU);
            this.tbRussian.Controls.Add(this.label12);
            this.tbRussian.Controls.Add(this.txtVacDepartmentRU);
            this.tbRussian.Controls.Add(this.label11);
            resources.ApplyResources(this.tbRussian, "tbRussian");
            this.tbRussian.Name = "tbRussian";
            this.tbRussian.UseVisualStyleBackColor = true;
            // 
            // txtVacInformationRU
            // 
            resources.ApplyResources(this.txtVacInformationRU, "txtVacInformationRU");
            this.txtVacInformationRU.Name = "txtVacInformationRU";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // txtVacRequirementsRU
            // 
            resources.ApplyResources(this.txtVacRequirementsRU, "txtVacRequirementsRU");
            this.txtVacRequirementsRU.Name = "txtVacRequirementsRU";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // txtVacSpecializationRU
            // 
            resources.ApplyResources(this.txtVacSpecializationRU, "txtVacSpecializationRU");
            this.txtVacSpecializationRU.Name = "txtVacSpecializationRU";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // txtVacDepartmentRU
            // 
            resources.ApplyResources(this.txtVacDepartmentRU, "txtVacDepartmentRU");
            this.txtVacDepartmentRU.Name = "txtVacDepartmentRU";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // tbUzbek
            // 
            this.tbUzbek.Controls.Add(this.txtVacInformationUZ);
            this.tbUzbek.Controls.Add(this.label18);
            this.tbUzbek.Controls.Add(this.txtVacRequirementsUZ);
            this.tbUzbek.Controls.Add(this.label17);
            this.tbUzbek.Controls.Add(this.txtVacSpecializationUZ);
            this.tbUzbek.Controls.Add(this.label16);
            this.tbUzbek.Controls.Add(this.txtVacDepartmentUZ);
            this.tbUzbek.Controls.Add(this.label15);
            resources.ApplyResources(this.tbUzbek, "tbUzbek");
            this.tbUzbek.Name = "tbUzbek";
            this.tbUzbek.UseVisualStyleBackColor = true;
            // 
            // txtVacInformationUZ
            // 
            resources.ApplyResources(this.txtVacInformationUZ, "txtVacInformationUZ");
            this.txtVacInformationUZ.Name = "txtVacInformationUZ";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // txtVacRequirementsUZ
            // 
            resources.ApplyResources(this.txtVacRequirementsUZ, "txtVacRequirementsUZ");
            this.txtVacRequirementsUZ.Name = "txtVacRequirementsUZ";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // txtVacSpecializationUZ
            // 
            resources.ApplyResources(this.txtVacSpecializationUZ, "txtVacSpecializationUZ");
            this.txtVacSpecializationUZ.Name = "txtVacSpecializationUZ";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // txtVacDepartmentUZ
            // 
            resources.ApplyResources(this.txtVacDepartmentUZ, "txtVacDepartmentUZ");
            this.txtVacDepartmentUZ.Name = "txtVacDepartmentUZ";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // frmEditPortalVacancy
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabAddVacancy);
            this.Name = "frmEditPortalVacancy";
            this.Load += new System.EventHandler(this.frmEditPortalVacancy_Load);
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

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabAddVacancy;
        private System.Windows.Forms.TabPage tbGeneral;
        private System.Windows.Forms.ComboBox cmbVacStatus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateVacExpire;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbVacEducation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbVacExperience;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbVacGender;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbVacEmployment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtVacSalary;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbVacCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVacDescUZ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVacDescRU;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tbRussian;
        private System.Windows.Forms.TextBox txtVacInformationRU;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtVacRequirementsRU;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtVacSpecializationRU;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtVacDepartmentRU;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tbUzbek;
        private System.Windows.Forms.TextBox txtVacInformationUZ;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtVacRequirementsUZ;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtVacSpecializationUZ;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtVacDepartmentUZ;
        private System.Windows.Forms.Label label15;
    }
}