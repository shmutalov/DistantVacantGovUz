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
    public partial class EditPortalVacancyWindow : Form
    {
        private readonly int _vacancyId;
        private Vacancy _vacancy;

        readonly ResourceManager _resources;
        readonly CultureInfo _currentCultureInfo;

        public EditPortalVacancyWindow(int portalVacancyId)
        {
            InitializeComponent();

            _resources = new ResourceManager("DistantVacantGovUz.frmEditPortalVacancy", Assembly.GetExecutingAssembly());
            _currentCultureInfo = Thread.CurrentThread.CurrentUICulture;

            _vacancyId = portalVacancyId;

            if (_vacancyId == 0)
                Close();

            Text = language.strings.frmEditPortalVacancyCaption + portalVacancyId;
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
                //MessageBox.Show("Поле \"" + @"Русское наименование" + "\" не может быть пустым");

                errorMessage += string.Format(language.strings.editPortalVacCheckVacField
                    , _resources.GetString("lblDescriptionRU.Text", _currentCultureInfo));
                
                txtVacDescRU.Focus();
                ret = false;
            }

            if (txtVacDescUZ.Text.Trim() == "")
            {
                //MessageBox.Show("Поле \"" + @"Узбекское наименование (латиницой)" + "\" не может быть пустым");

                errorMessage += string.Format(language.strings.editPortalVacCheckVacField
                    , _resources.GetString("lblDescriptionUZ.Text", _currentCultureInfo));

                txtVacDescUZ.Focus();
                ret = false;
            }

            if (cmbVacCategory.SelectedIndex == -1)
            {
                //MessageBox.Show("Выберите категорию");

                errorMessage += string.Format(language.strings.editPortalVacCheckVacField
                    , _resources.GetString("lblCategory.Text", _currentCultureInfo));

                cmbVacCategory.Focus();
                ret = false;
            }

            if (txtVacSalary.Text.Trim() == "")
            {
                //MessageBox.Show("Поле \"" + @"Заработная плата" + "\" не может быть пустым");
                
                errorMessage += string.Format(language.strings.editPortalVacCheckVacField
                    , _resources.GetString("lblSalary.Text", _currentCultureInfo));

                txtVacSalary.Focus();
                ret = false;
            }

            if (cmbVacStatus.SelectedIndex == -1)
            {
                //MessageBox.Show("Укажите статус");
                
                errorMessage += string.Format(language.strings.editPortalVacCheckVacField
                    , _resources.GetString("lblStatus.Text", _currentCultureInfo));

                cmbVacStatus.Focus();
                ret = false;
            }

            tabAddVacancy.SelectedIndex = 1;

            if (txtVacDepartmentRU.Text.Trim() == "")
            {
                //MessageBox.Show("Поле \"" + @"Отдел / Подразделение (РУ)" + "\" не может быть пустым");
                
                errorMessage += string.Format(language.strings.editPortalVacCheckVacField
                    , _resources.GetString("lblDepartmentRU.Text", _currentCultureInfo));

                txtVacDepartmentRU.Focus();
                ret = false;
            }

            if (txtVacSpecializationRU.Text.Trim() == "")
            {
                //MessageBox.Show("Поле \"" + @"Функциональность (РУ)" + "\" не может быть пустым");
                
                errorMessage += string.Format(language.strings.editPortalVacCheckVacField
                    , _resources.GetString("lblSpecializationRU.Text", _currentCultureInfo));

                txtVacSpecializationRU.Focus();
                ret = false;
            }

            if (txtVacRequirementsRU.Text.Trim() == "")
            {
                //MessageBox.Show("Поле \"" + @"Функциональность (РУ)" + "\" не может быть пустым");

                errorMessage += string.Format(language.strings.editPortalVacCheckVacField
                    , _resources.GetString("lblRequirementsRU.Text", _currentCultureInfo));

                txtVacRequirementsRU.Focus();
                ret = false;
            }

            tabAddVacancy.SelectedIndex = 2;

            if (txtVacDepartmentUZ.Text.Trim() == "")
            {
                //MessageBox.Show("Поле \"" + @"Отдел / Подразделение (УЗ)" + "\" не может быть пустым");

                errorMessage += string.Format(language.strings.editPortalVacCheckVacField
                    , _resources.GetString("lblDepartmentUZ.Text", _currentCultureInfo));

                txtVacDepartmentUZ.Focus();
                ret = false;
            }

            if (txtVacSpecializationUZ.Text.Trim() == "")
            {
                //MessageBox.Show("Поле \"" + @"Функциональность (УЗ)" + "\" не может быть пустым");
                
                errorMessage += string.Format(language.strings.editPortalVacCheckVacField
                    , _resources.GetString("lblSpecializationUZ.Text", _currentCultureInfo));

                txtVacSpecializationUZ.Focus();
                ret = false;
            }

            if (txtVacRequirementsUZ.Text.Trim() == "")
            {
                //MessageBox.Show("Поле \"" + @"Функциональность (РУ)" + "\" не может быть пустым");

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

        private void LoadVacancy()
        {
            _vacancy = Program.VacancyApi.GetVacancy(_vacancyId);

            if (_vacancy != null)
            {
                txtVacDescRU.Text = _vacancy.DescriptionRu;
                txtVacDescUZ.Text = _vacancy.DescriptionUz;

                cmbVacCategory.SelectedIndex = (int)_vacancy.Category - 1;
                cmbVacEmployment.SelectedIndex = (int)_vacancy.Employment;

                txtVacSalary.Text = _vacancy.StrSalary;

                cmbVacGender.SelectedIndex = (int)_vacancy.Gender;
                cmbVacExperience.SelectedIndex = (int)_vacancy.Experience;
                cmbVacEducation.SelectedIndex = (int)_vacancy.EducatonLevel;

                if (_vacancy.ExpireDate == "" || _vacancy.ExpireDate == "0000-00-00")
                {
                    //dateVacExpire.Value = DateTime.Now.AddYears(1);
                    dateVacExpire.Value = DateTime.Now.AddMonths(1);
                    //dateVacExpire.Enabled = false;
                    //chkWithoutExpireDate.Checked = true;
                }
                else
                {
                    dateVacExpire.Value = DateTime.ParseExact(_vacancy.ExpireDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None);
                }

                cmbVacStatus.SelectedIndex = (int)_vacancy.Status;

                txtVacDepartmentRU.Text = _vacancy.DepartmentRu;
                txtVacSpecializationRU.Text = _vacancy.SpecializationRu;
                txtVacRequirementsRU.Text = _vacancy.RequirementsRu;
                txtVacInformationRU.Text = _vacancy.InformationRu;

                txtVacDepartmentUZ.Text = _vacancy.DepartmentUz;
                txtVacSpecializationUZ.Text = _vacancy.SpecializationUz;
                txtVacRequirementsUZ.Text = _vacancy.RequirementsUz;
                txtVacInformationUZ.Text = _vacancy.InformationUz;
            }
            else
                Close();
        }

        private void frmEditPortalVacancy_Load(object sender, EventArgs e)
        {
            try
            {
                LoadVacancy();
            }
            catch (Exception)
            {
                MessageBox.Show(language.strings.MsgEditPortalVacOpenError
                    , language.strings.MsgEditPortalVacOpenCaption
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //return;

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
                //, (!chkWithoutExpireDate.Checked) ? dateVacExpire.Value.ToString("yyyy-MM-dd") : ""
                    , dateVacExpire.Value.ToString("yyyy-MM-dd")
                    , (VacancyStatus)cmbVacStatus.SelectedIndex
                    , txtVacDepartmentRU.Text
                    , txtVacDepartmentUZ.Text
                    , txtVacSpecializationRU.Text
                    , txtVacSpecializationUZ.Text
                    , txtVacRequirementsRU.Text
                    , txtVacRequirementsUZ.Text
                    , txtVacInformationRU.Text
                    , txtVacInformationUZ.Text
                );

            if (Program.VacancyApi.EditVacancy(_vacancyId, v))
            {
                Close();
            }
            else
            {
                MessageBox.Show(language.strings.MsgEditPortalVacSaveError
                    , language.strings.MsgEditPortalVacSaveCaption
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
