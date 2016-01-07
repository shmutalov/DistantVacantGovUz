using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using DistantVacantGovUz.Enums;
using DistantVacantGovUz.Models;

namespace DistantVacantGovUz.Windows
{
    public partial class AddPortalVacancyWindow : Form
    {
        readonly ResourceManager _resources;
        readonly CultureInfo _currentCultureInfo;

        public AddPortalVacancyWindow()
        {
            InitializeComponent();

            _resources = new ResourceManager("DistantVacantGovUz.frmAddPortalVacancy", Assembly.GetExecutingAssembly());
            _currentCultureInfo = Thread.CurrentThread.CurrentUICulture;
        }

        /// <summary>
        /// Проверка на правильность заполнения полей вакансии.
        /// При обнаружении не правильного заполненого поля выдасть сообщение об ошибке.
        /// </summary>
        /// <returns>Возвратит <value>true</value> если проверка прошла успешно. В другом случае возвратит <value>false</value></returns>
        private bool ValidateVacancy()
        {
            var ret = true;
            var errorMessage = string.Empty;

            tabAddVacancy.SelectedIndex = 0;

            if (txtVacDescRU.Text.Trim() == "")
            {
                errorMessage += string.Format(language.strings.editPortalVacCheckVacField
                    , _resources.GetString("lblDescriptionRU.Text", _currentCultureInfo));

                txtVacDescRU.Focus();
                ret = false;
            }

            if (txtVacDescUZ.Text.Trim() == "")
            {
                errorMessage += string.Format(language.strings.editPortalVacCheckVacField
                    , _resources.GetString("lblDescriptionUZ.Text", _currentCultureInfo));

                txtVacDescUZ.Focus();
                ret = false;
            }

            if (cmbVacCategory.SelectedIndex == -1)
            {
                errorMessage += string.Format(language.strings.editPortalVacCheckVacField
                    , _resources.GetString("lblCategory.Text", _currentCultureInfo));

                cmbVacCategory.Focus();
                ret = false;
            }

            if (txtVacSalary.Text.Trim() == "")
            {
                errorMessage += string.Format(language.strings.editPortalVacCheckVacField
                    , _resources.GetString("lblSalary.Text", _currentCultureInfo));

                txtVacSalary.Focus();
                ret = false;
            }

            tabAddVacancy.SelectedIndex = 1;

            if (txtVacDepartmentRU.Text.Trim() == "")
            {
                errorMessage += string.Format(language.strings.editPortalVacCheckVacField
                    , _resources.GetString("lblDepartmentRU.Text", _currentCultureInfo));

                txtVacDepartmentRU.Focus();
                ret = false;
            }

            if (txtVacSpecializationRU.Text.Trim() == "")
            {
                errorMessage += string.Format(language.strings.editPortalVacCheckVacField
                    , _resources.GetString("lblSpecializationRU.Text", _currentCultureInfo));

                txtVacSpecializationRU.Focus();
                ret = false;
            }

            if (txtVacRequirementsRU.Text.Trim() == "")
            {
                errorMessage += string.Format(language.strings.editPortalVacCheckVacField
                    , _resources.GetString("lblRequirementsRU.Text", _currentCultureInfo));

                txtVacRequirementsRU.Focus();
                ret = false;
            }

            tabAddVacancy.SelectedIndex = 2;

            if (txtVacDepartmentUZ.Text.Trim() == "")
            {
                errorMessage += string.Format(language.strings.editPortalVacCheckVacField
                    , _resources.GetString("lblDepartmentUZ.Text", _currentCultureInfo));

                txtVacDepartmentUZ.Focus();
                ret = false;
            }

            if (txtVacSpecializationUZ.Text.Trim() == "")
            {
                errorMessage += string.Format(language.strings.editPortalVacCheckVacField
                    , _resources.GetString("lblSpecializationUZ.Text", _currentCultureInfo));

                txtVacSpecializationUZ.Focus();
                ret = false;
            }

            if (txtVacRequirementsUZ.Text.Trim() == "")
            {
                errorMessage += string.Format(language.strings.editPortalVacCheckVacField
                    , _resources.GetString("lblRequirementsUZ.Text", _currentCultureInfo));

                txtVacRequirementsUZ.Focus();
                ret = false;
            }

            if (!ret)
            {
                MessageBox.Show(errorMessage
                        , language.strings.MsgEditPortalVacSaveCaption
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Error);

                return false;
            }

            using (var captcha = new CaptchaWindow())
            {
                if (captcha.ShowDialog() != DialogResult.OK)
                    return false;

                Program.VacancyApi.SetCaptchaText(captcha.CaptchaText);

                return true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateVacancy())
                return;

            var v = new Vacancy(
                    txtVacDescRU.Text
                    , txtVacDescUZ.Text
                    , (VacancyCategory)(cmbVacCategory.SelectedIndex + 1)
                    , txtVacSalary.Text
                    , (VacancyEmployment)cmbVacEmployment.SelectedIndex
                    , (VacancyGender)cmbVacGender.SelectedIndex
                    , (VacancyExperience)cmbVacExperience.SelectedIndex
                    , (VacancyEducationLevel)cmbVacEducation.SelectedIndex
                    , dateVacExpire.Value.ToString("yyyy-MM-dd")
                    , VacancyStatus.Open
                    , txtVacDepartmentRU.Text
                    , txtVacDepartmentUZ.Text
                    , txtVacSpecializationRU.Text
                    , txtVacSpecializationUZ.Text
                    , txtVacRequirementsRU.Text
                    , txtVacRequirementsUZ.Text
                    , txtVacInformationRU.Text
                    , txtVacInformationUZ.Text
                );

            if (Program.VacancyApi.AddVacancy(v))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(language.strings.MsgEditPortalVacSaveError
                    , language.strings.MsgEditPortalVacSaveCaption
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddMore_Click(object sender, EventArgs e)
        {
            if (!ValidateVacancy())
                return;

            var v = new Vacancy(
                    txtVacDescRU.Text
                    , txtVacDescUZ.Text
                    , (VacancyCategory)(cmbVacCategory.SelectedIndex + 1)
                    , txtVacSalary.Text
                    , (VacancyEmployment)cmbVacEmployment.SelectedIndex
                    , (VacancyGender)cmbVacGender.SelectedIndex
                    , (VacancyExperience)cmbVacExperience.SelectedIndex
                    , (VacancyEducationLevel)cmbVacEducation.SelectedIndex
                    , dateVacExpire.Value.ToString("yyyy-MM-dd")
                    , VacancyStatus.Open
                    , txtVacDepartmentRU.Text
                    , txtVacDepartmentUZ.Text
                    , txtVacSpecializationRU.Text
                    , txtVacSpecializationUZ.Text
                    , txtVacRequirementsRU.Text
                    , txtVacRequirementsUZ.Text
                    , txtVacInformationRU.Text
                    , txtVacInformationUZ.Text
                );

            if (Program.VacancyApi.AddVacancy(v))
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

                tabAddVacancy.SelectedIndex = 0;

                txtVacDescRU.Focus();
            }
        }
    }
}
