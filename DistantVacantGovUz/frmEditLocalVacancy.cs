using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DistantVacantGovUz
{
    public partial class frmEditLocalVacancy : Form
    {
        public CVacancyItem vac;

        public frmEditLocalVacancy()
        {
            InitializeComponent();
        }

        private void frmEditLocalVacancy_Load(object sender, EventArgs e)
        {
            if (vac == null)
                this.Close();

            txtVacDescRU.Text = vac.description_ru;
            txtVacDescUZ.Text = vac.description_uz;

            cmbVacCategory.SelectedIndex = vac.i_category_id - 1;

            txtVacSalary.Text = vac.salary;

            cmbVacEmployment.SelectedIndex = vac.i_employment_id;

            cmbVacGender.SelectedIndex = vac.i_gender_id;
            cmbVacExperience.SelectedIndex = vac.i_experience_id;
            cmbVacEducation.SelectedIndex = vac.i_education_id;

            if (vac.expire_date == "" || vac.expire_date == "0000-00-00")
            {
                dateVacExpire.Value = DateTime.Now.AddMonths(1);
            }
            else
            {
                dateVacExpire.Value = DateTime.ParseExact(vac.expire_date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
            }

            txtVacDepartmentRU.Text = vac.department_ru;
            txtVacSpecializationRU.Text = vac.specialization_ru;
            txtVacRequirementsRU.Text = vac.requirements_ru;
            txtVacInformationRU.Text = vac.information_ru;

            txtVacDepartmentUZ.Text = vac.department_uz;
            txtVacSpecializationUZ.Text = vac.specialization_uz;
            txtVacRequirementsUZ.Text = vac.requirements_uz;
            txtVacInformationUZ.Text = vac.information_uz;

            this.Text = language.strings.frmEditLocalVacancyCaption + vac.seqNum;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CVacancyItem v = new CVacancyItem(
                        vac.seqNum
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
                        , vac.portal_vacancy_id
                    );

            bool validated = v.IsValid();

            if (!validated)
            {
                if (MessageBox.Show("Не все поля заполнены." + "\n" + "Продолжить сохранение изменений?"
                    , "Редактирование вакансии"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    return;
            }

            vac = CVacancyItem.Copy(v, vac);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
