using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Threading;
using System.Globalization;
using System.Reflection;

namespace DistantVacantGovUz
{
    public partial class frmAddPortalVacancy : Form
    {
        ResourceManager resources;
        CultureInfo currentCultureInfo;

        public frmAddPortalVacancy()
        {
            InitializeComponent();

            resources = new ResourceManager("DistantVacantGovUz.frmAddPortalVacancy", Assembly.GetExecutingAssembly());
            currentCultureInfo = Thread.CurrentThread.CurrentUICulture;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
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
                    , VACANCY_STATUS.OPEN
                    , txtVacDepartmentRU.Text
                    , txtVacDepartmentUZ.Text
                    , txtVacSpecializationRU.Text
                    , txtVacSpecializationUZ.Text
                    , txtVacRequirementsRU.Text
                    , txtVacRequirementsUZ.Text
                    , txtVacInformationRU.Text
                    , txtVacInformationUZ.Text
                );

            if (Program.vac.AddVacancy(v))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
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
                    , VACANCY_STATUS.OPEN
                    , txtVacDepartmentRU.Text
                    , txtVacDepartmentUZ.Text
                    , txtVacSpecializationRU.Text
                    , txtVacSpecializationUZ.Text
                    , txtVacRequirementsRU.Text
                    , txtVacRequirementsUZ.Text
                    , txtVacInformationRU.Text
                    , txtVacInformationUZ.Text
                );

            if (Program.vac.AddVacancy(v))
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
    }
}
