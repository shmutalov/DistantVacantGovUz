using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DistantVacantGovUz.Enums;
using DistantVacantGovUz.Models;

namespace DistantVacantGovUz.Windows
{
    public partial class AddLocalVacancyWindow : Form
    {
        public AddLocalVacancyWindow()
        {
            InitializeComponent();
        }

        public List<VacancyItem> Vacs;

        private void btnAddClose_Click(object sender, EventArgs e)
        {
            if (AddVacancy())
                Close();
        }

        private void btnAddMore_Click(object sender, EventArgs e)
        {
            if (AddVacancy())
            {
                txtVacDescRU.Text = string.Empty;
                txtVacDescUZ.Text = string.Empty;
                txtVacSalary.Text = string.Empty;

                txtVacDepartmentRU.Text = string.Empty;
                txtVacSpecializationRU.Text = string.Empty;
                txtVacRequirementsRU.Text = string.Empty;
                txtVacInformationRU.Text = string.Empty;

                txtVacDepartmentUZ.Text = string.Empty;
                txtVacSpecializationUZ.Text = string.Empty;
                txtVacRequirementsUZ.Text = string.Empty;
                txtVacInformationUZ.Text = string.Empty;

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
            if (Vacs != null)
            {
                int iVacNum;

                if (Vacs.Count == 0)
                    iVacNum = 1;
                else
                    iVacNum = Vacs.Count + 1;

                var v = new VacancyItem(
                        iVacNum.ToString()
                        , txtVacDescRU.Text
                        , txtVacDescUZ.Text
                        , Vacancy.CategoryFromIdRu((VacancyCategory)(cmbVacCategory.SelectedIndex + 1))
                        , txtVacSalary.Text
                        , Vacancy.EmploymentFromIdRu((VacancyEmployment)(cmbVacEmployment.SelectedIndex))
                        , Vacancy.GenderFromIdRu((VacancyGender)(cmbVacGender.SelectedIndex))
                        , Vacancy.ExperienceFromIdRu((VacancyExperience)(cmbVacExperience.SelectedIndex))
                        , Vacancy.EducationFromIdRu((VacancyEducationLevel)(cmbVacEducation.SelectedIndex))
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

                var validated = v.IsValid();

                if (!validated)
                {
                    if (MessageBox.Show(language.strings.MsgNotAllFieldsFilled
                            , language.strings.MsgCaptionAddVacancy
                            , MessageBoxButtons.YesNo
                            , MessageBoxIcon.Question) == DialogResult.No)
                        return false;
                }
                
                Vacs.Add(v);

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
