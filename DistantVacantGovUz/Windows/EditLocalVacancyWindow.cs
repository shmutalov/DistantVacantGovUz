using System;
using System.Windows.Forms;
using DistantVacantGovUz.Enums;
using DistantVacantGovUz.Models;

namespace DistantVacantGovUz.Windows
{
    public partial class EditLocalVacancyWindow : Form
    {
        public VacancyItem Vac;

        public EditLocalVacancyWindow()
        {
            InitializeComponent();
        }

        private void frmEditLocalVacancy_Load(object sender, EventArgs e)
        {
            if (Vac == null)
            {
                Close();
                return;
            }

            txtVacDescRU.Text = Vac.DescriptionRu;
            txtVacDescUZ.Text = Vac.DescriptionUz;

            cmbVacCategory.SelectedIndex = Vac.CategoryId - 1;

            txtVacSalary.Text = Vac.Salary;

            cmbVacEmployment.SelectedIndex = Vac.EmploymentId;

            cmbVacGender.SelectedIndex = Vac.GenderId;
            cmbVacExperience.SelectedIndex = Vac.ExperienceId;
            cmbVacEducation.SelectedIndex = Vac.EducationId;

            if (Vac.ExpireDate == "" || Vac.ExpireDate == "0000-00-00")
            {
                dateVacExpire.Value = DateTime.Now.AddMonths(1);
            }
            else
            {
                dateVacExpire.Value = DateTime.ParseExact(Vac.ExpireDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
            }

            txtVacDepartmentRU.Text = Vac.DepartmentRu;
            txtVacSpecializationRU.Text = Vac.SpecializationRu;
            txtVacRequirementsRU.Text = Vac.RequirementsRu;
            txtVacInformationRU.Text = Vac.InformationRu;

            txtVacDepartmentUZ.Text = Vac.DepartmentUz;
            txtVacSpecializationUZ.Text = Vac.SpecializationUz;
            txtVacRequirementsUZ.Text = Vac.RequirementsUz;
            txtVacInformationUZ.Text = Vac.InformationUz;

            Text = language.strings.frmEditLocalVacancyCaption + Vac.SequenceNumber;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var v = new VacancyItem(
                        Vac.SequenceNumber
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
                        , Vac.PortalVacancyIdString
                    );

            var validated = v.IsValid();

            if (!validated)
            {
                if (MessageBox.Show(language.strings.MsgNotAllFieldsFilled
                    , language.strings.MsgEditSavingLocalVacancyCaption
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            Vac = VacancyItem.Copy(v, Vac);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
