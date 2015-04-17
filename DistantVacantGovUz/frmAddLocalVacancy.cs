using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DistantVacantGovUz
{
    public partial class frmAddLocalVacancy : Form
    {
        public frmAddLocalVacancy()
        {
            InitializeComponent();
        }

        public List<CVacancyItem> vacs;

        private void btnAddClose_Click(object sender, EventArgs e)
        {
            if (AddVacancy())
                this.Close();
        }

        private void btnAddMore_Click(object sender, EventArgs e)
        {
            if (AddVacancy())
            {
                txtVacDescRU.Text = "";
                txtVacDescUZ.Text = "";
                txtVacSalary.Text = "";

                txtVacDepartmentRU.Text = "";
                txtVacSpecializationRU.Text = "";
                txtVacRequirementsRU.Text = "";
                txtVacInformationRU.Text = "";

                txtVacDepartmentUZ.Text = "";
                txtVacSpecializationUZ.Text = "";
                txtVacRequirementsUZ.Text = "";
                txtVacInformationUZ.Text = "";

                cmbVacCategory.SelectedIndex = -1;
                cmbVacEmployment.SelectedIndex = 1;
                cmbVacGender.SelectedIndex = 0;
                cmbVacExperience.SelectedIndex = 0;
                cmbVacEducation.SelectedIndex = 0;
                dateVacExpire.Value = DateTime.Now.AddMonths(1);
                //chkWithoutExpireDate.Checked = true;

                tabAddVacancy.SelectedIndex = 0;

                txtVacDescRU.Focus();
            }
        }

        private bool AddVacancy()
        {
            int iVacNum;

            if (vacs != null)
            {
                if (vacs.Count == 0)
                    iVacNum = 1;
                else
                    iVacNum = vacs.Count + 1;

                CVacancyItem v = new CVacancyItem(
                        iVacNum.ToString()
                        , txtVacDescRU.Text
                        , txtVacDescUZ.Text
                        , CVacancy.CategoryFromIdRu((VACANCY_CATEGORY)(cmbVacCategory.SelectedIndex + 1))
                        , txtVacSalary.Text
                        , CVacancy.EmploymentFromIdRu((VACANCY_EMPLOYMENT)(cmbVacEmployment.SelectedIndex))
                        , CVacancy.GenderFromIdRu((VACANCY_GENDER)(cmbVacGender.SelectedIndex))
                        , CVacancy.ExperienceFromIdRu((VACANCY_EXPERIENCE)(cmbVacExperience.SelectedIndex))
                        , CVacancy.EducationFromIdRu((VACANCY_EDUCATION_LEVEL)(cmbVacEducation.SelectedIndex))
                        , dateVacExpire.Value.ToString("yyyy-MM-dd")
                        , txtVacDepartmentRU.Text
                        , txtVacSpecializationRU.Text
                        , txtVacRequirementsRU.Text
                        , txtVacInformationRU.Text
                        , txtVacDepartmentUZ.Text
                        , txtVacSpecializationUZ.Text
                        , txtVacRequirementsUZ.Text
                        , txtVacInformationUZ.Text
                        , (cmbVacCategory.SelectedIndex + 1).ToString()
                        , (cmbVacEmployment.SelectedIndex).ToString()
                        , (cmbVacGender.SelectedIndex).ToString()
                        , (cmbVacExperience.SelectedIndex).ToString()
                        , (cmbVacEducation.SelectedIndex).ToString()
                        , "0"
                    );

                bool validated = v.IsValid();

                if (!validated)
                {
                    if (MessageBox.Show(language.strings.MsgNotAllFieldsFilled
                            , language.strings.MsgCaptionAddVacancy
                            , MessageBoxButtons.YesNo
                            , MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                        return false;
                }
                
                vacs.Add(v);

                return true;
            }
            else
                return false;

        }

        private void frmAddLocalVacancy_Load(object sender, EventArgs e)
        {
            cmbVacEmployment.SelectedIndex = 1;
            cmbVacGender.SelectedIndex = 0;
            cmbVacExperience.SelectedIndex = 0;
            cmbVacEducation.SelectedIndex = 0;
            dateVacExpire.Value = DateTime.Now.AddMonths(1);
        }
    }
}
