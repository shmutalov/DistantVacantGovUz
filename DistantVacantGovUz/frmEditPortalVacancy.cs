using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;

namespace DistantVacantGovUz
{
    public partial class frmEditPortalVacancy : Form
    {
        private int vacancyId = 0;
        private CVacancy vacancy = null;

        /*public frmEditPortalVacancy()
        {
            InitializeComponent();
        }*/

        ResourceManager resources;
        CultureInfo currentCultureInfo;

        public frmEditPortalVacancy(int portalVacancyId)
        {
            InitializeComponent();

            resources = new ResourceManager("DistantVacantGovUz.frmEditPortalVacancy", Assembly.GetExecutingAssembly());
            currentCultureInfo = Thread.CurrentThread.CurrentUICulture;

            this.vacancyId = portalVacancyId;

            if (vacancyId == 0)
                this.Close();

            this.Text = language.strings.frmEditPortalVacancyCaption + portalVacancyId.ToString();
        }

        /// <summary>
        /// Проверка на правильность заполнения полей вакансии.
        /// При обнаружении не правильного заполненого поля выдасть сообщение об ошибке.
        /// </summary>
        /// <returns>Возвратит <value>true</value> если проверка прошла успешно. В другом случае возвратит <value>false</value></returns>
        private bool ValidateVacancy()
        {
            bool ret = true;
            string errorMessage = "";

            tabAddVacancy.SelectedIndex = 0;

            if (txtVacDescRU.Text.Trim() == "")
            {
                //MessageBox.Show("Поле \"" + @"Русское наименование" + "\" не может быть пустым");

                errorMessage += String.Format(language.strings.editPortalVacCheckVacField
                    , resources.GetString("lblDescriptionRU.Text", currentCultureInfo));
                
                txtVacDescRU.Focus();
                ret = false;
            }

            if (txtVacDescUZ.Text.Trim() == "")
            {
                //MessageBox.Show("Поле \"" + @"Узбекское наименование (латиницой)" + "\" не может быть пустым");

                errorMessage += String.Format(language.strings.editPortalVacCheckVacField
                    , resources.GetString("lblDescriptionUZ.Text", currentCultureInfo));

                txtVacDescUZ.Focus();
                ret = false;
            }

            if (cmbVacCategory.SelectedIndex == -1)
            {
                //MessageBox.Show("Выберите категорию");

                errorMessage += String.Format(language.strings.editPortalVacCheckVacField
                    , resources.GetString("lblCategory.Text", currentCultureInfo));

                cmbVacCategory.Focus();
                ret = false;
            }

            if (txtVacSalary.Text.Trim() == "")
            {
                //MessageBox.Show("Поле \"" + @"Заработная плата" + "\" не может быть пустым");
                
                errorMessage += String.Format(language.strings.editPortalVacCheckVacField
                    , resources.GetString("lblSalary.Text", currentCultureInfo));

                txtVacSalary.Focus();
                ret = false;
            }

            if (cmbVacStatus.SelectedIndex == -1)
            {
                //MessageBox.Show("Укажите статус");
                
                errorMessage += String.Format(language.strings.editPortalVacCheckVacField
                    , resources.GetString("lblStatus.Text", currentCultureInfo));

                cmbVacStatus.Focus();
                ret = false;
            }

            tabAddVacancy.SelectedIndex = 1;

            if (txtVacDepartmentRU.Text.Trim() == "")
            {
                //MessageBox.Show("Поле \"" + @"Отдел / Подразделение (РУ)" + "\" не может быть пустым");
                
                errorMessage += String.Format(language.strings.editPortalVacCheckVacField
                    , resources.GetString("lblDepartmentRU.Text", currentCultureInfo));

                txtVacDepartmentRU.Focus();
                ret = false;
            }

            if (txtVacSpecializationRU.Text.Trim() == "")
            {
                //MessageBox.Show("Поле \"" + @"Функциональность (РУ)" + "\" не может быть пустым");
                
                errorMessage += String.Format(language.strings.editPortalVacCheckVacField
                    , resources.GetString("lblSpecializationRU.Text", currentCultureInfo));

                txtVacSpecializationRU.Focus();
                ret = false;
            }

            if (txtVacRequirementsRU.Text.Trim() == "")
            {
                //MessageBox.Show("Поле \"" + @"Функциональность (РУ)" + "\" не может быть пустым");

                errorMessage += String.Format(language.strings.editPortalVacCheckVacField
                    , resources.GetString("lblRequirementsRU.Text", currentCultureInfo));

                txtVacRequirementsRU.Focus();
                ret = false;
            }

            tabAddVacancy.SelectedIndex = 2;

            if (txtVacDepartmentUZ.Text.Trim() == "")
            {
                //MessageBox.Show("Поле \"" + @"Отдел / Подразделение (УЗ)" + "\" не может быть пустым");

                errorMessage += String.Format(language.strings.editPortalVacCheckVacField
                    , resources.GetString("lblDepartmentUZ.Text", currentCultureInfo));

                txtVacDepartmentUZ.Focus();
                ret = false;
            }

            if (txtVacSpecializationUZ.Text.Trim() == "")
            {
                //MessageBox.Show("Поле \"" + @"Функциональность (УЗ)" + "\" не может быть пустым");

                errorMessage += String.Format(language.strings.editPortalVacCheckVacField
                    , resources.GetString("lblSpecializationUZ.Text", currentCultureInfo));

                txtVacSpecializationUZ.Focus();
                ret = false;
            }

            if (txtVacRequirementsUZ.Text.Trim() == "")
            {
                //MessageBox.Show("Поле \"" + @"Функциональность (РУ)" + "\" не может быть пустым");

                errorMessage += String.Format(language.strings.editPortalVacCheckVacField
                    , resources.GetString("lblRequirementsUZ.Text", currentCultureInfo));

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

            frmCaptcha fCaptcha;

            using (fCaptcha = new frmCaptcha())
            {
                if (fCaptcha.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Program.vac.SetCaptchaText(fCaptcha.captchaText);

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void LoadVacancy()
        {
            vacancy = Program.vac.GetVacancy(this.vacancyId);

            if (vacancy != null)
            {
                txtVacDescRU.Text = vacancy.strDescriptionRU;
                txtVacDescUZ.Text = vacancy.strDescriptionUZ;

                cmbVacCategory.SelectedIndex = (int)vacancy.vacCategory - 1;
                cmbVacEmployment.SelectedIndex = (int)vacancy.vacEmployment;

                txtVacSalary.Text = vacancy.strSalary;

                cmbVacGender.SelectedIndex = (int)vacancy.vacGender;
                cmbVacExperience.SelectedIndex = (int)vacancy.vacExperience;
                cmbVacEducation.SelectedIndex = (int)vacancy.vacEducaton;

                if (vacancy.strExpireDate == "" || vacancy.strExpireDate == "0000-00-00")
                {
                    //dateVacExpire.Value = DateTime.Now.AddYears(1);
                    dateVacExpire.Value = DateTime.Now.AddMonths(1);
                    //dateVacExpire.Enabled = false;
                    //chkWithoutExpireDate.Checked = true;
                }
                else
                {
                    dateVacExpire.Value = DateTime.ParseExact(vacancy.strExpireDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
                }

                cmbVacStatus.SelectedIndex = (int)vacancy.vacStatus;

                txtVacDepartmentRU.Text = vacancy.strDepartmentRU;
                txtVacSpecializationRU.Text = vacancy.strSpecializationRU;
                txtVacRequirementsRU.Text = vacancy.strRequirementsRU;
                txtVacInformationRU.Text = vacancy.strInformationRU;

                txtVacDepartmentUZ.Text = vacancy.strDepartmentUZ;
                txtVacSpecializationUZ.Text = vacancy.strSpecializationUZ;
                txtVacRequirementsUZ.Text = vacancy.strRequirementsUZ;
                txtVacInformationUZ.Text = vacancy.strInformationUZ;
            }
            else
                this.Close();
        }

        private void frmEditPortalVacancy_Load(object sender, EventArgs e)
        {
            try
            {
                LoadVacancy();
            }
            catch (Exception ex)
            {
                MessageBox.Show(language.strings.MsgEditPortalVacOpenError
                    , language.strings.MsgEditPortalVacOpenCaption
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //return;

            if (!ValidateVacancy())
                return;

            CVacancy v = new CVacancy(
                    txtVacDescRU.Text
                    , txtVacDescUZ.Text
                    , (VACANCY_CATEGORY)(cmbVacCategory.SelectedIndex + 1)
                    , txtVacSalary.Text
                    , (VACANCY_EMPLOYMENT)cmbVacEmployment.SelectedIndex
                    , (VACANCY_GENDER)cmbVacGender.SelectedIndex
                    , (VACANCY_EXPERIENCE)cmbVacExperience.SelectedIndex
                    , (VACANCY_EDUCATION_LEVEL)cmbVacEducation.SelectedIndex
                //, (!chkWithoutExpireDate.Checked) ? dateVacExpire.Value.ToString("yyyy-MM-dd") : ""
                    , dateVacExpire.Value.ToString("yyyy-MM-dd")
                    , (VACANCY_STATUS)cmbVacStatus.SelectedIndex
                    , txtVacDepartmentRU.Text
                    , txtVacDepartmentUZ.Text
                    , txtVacSpecializationRU.Text
                    , txtVacSpecializationUZ.Text
                    , txtVacRequirementsRU.Text
                    , txtVacRequirementsUZ.Text
                    , txtVacInformationRU.Text
                    , txtVacInformationUZ.Text
                );

            if (Program.vac.EditVacancy(this.vacancyId, v))
            {
                this.Close();
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
