using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DistantVacantGovUz
{
    public partial class frmImportPortalVacancies : Form
    {
        List<CVacancyItem> workingVacancyList;
        bool canImport = false;

        public frmImportPortalVacancies()
        {
            InitializeComponent();
        }

        private void UpdateVacancyList()
        {
            lstVacancies.Items.Clear();

            bool c = true;

            if (workingVacancyList == null)
                return;

            canImport = true;

            for (int i = 0; i < workingVacancyList.Count; i++)
            {
                workingVacancyList[i].seqNum = (i + 1).ToString();

                ListViewItem li = lstVacancies.Items.Add(workingVacancyList[i].seqNum);
                li.SubItems.Add(workingVacancyList[i].description_ru);

                if (workingVacancyList[i].IsValid())
                {
                    li.BackColor = (c) ? Color.White : Color.AliceBlue;
                    li.SubItems.Add("Not imported");
                }
                else
                {
                    canImport = false;

                    li.BackColor = Color.LightCoral;
                    li.SubItems.Add("Vacancy have uncompleted fields");
                }
            }

            foreach (ColumnHeader clmn in lstVacancies.Columns)
            {
                clmn.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        private void toolBtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.CheckFileExists = true;
            ofd.Filter = "Файл Вакансий (*.vac, *.vacx)|*.vac;*.vacx";
            ofd.Title = "Выберите файл вакансий";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                frmLoading fLoading = new frmLoading();

                CVacancyDocumentPreloader preloader = new CVacancyDocumentPreloader(ofd.FileName, fLoading);
                workerDocumentPreloader.RunWorkerAsync(preloader);

                fLoading.SetOperationName(ofd.FileName);
                fLoading.ShowDialog();
            }
        }

        private void workerDocumentPreloader_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker wrkr = (BackgroundWorker)sender;
            CVacancyDocumentPreloader preldr = (CVacancyDocumentPreloader)e.Argument;

            preldr.DoWork(wrkr, e);
        }

        private void workerDocumentPreloader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CVacancyDocumentPreloader preldr = (CVacancyDocumentPreloader)e.Result;

            if (preldr.GetVacancyList() != null)
            {
                this.Text = "Import Vacancies" + " - " + preldr.GetFileName();
                toolTxtImportFileName.Text = preldr.GetFileName();
                
                workingVacancyList = preldr.GetVacancyList();

                UpdateVacancyList();
                toolBtnImport.Enabled = canImport;
            }
            else
            {
                toolBtnImport.Enabled = false;
                MessageBox.Show("Error occured while loading document" + "\n" + "Reason: " + CVacancyFileType.GetLastError(), "Open document", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            preldr.GetLoadingForm().Close();
        }

        private void toolBtnImport_Click(object sender, EventArgs e)
        {
            if (workingVacancyList == null || !canImport)
            {
                toolBtnImport.Enabled = false;
                return;
            }

            int imported = 0;

            // begin import vacancies step by step
            for (int i = 0; i < workingVacancyList.Count; i++)
            {
                frmCaptcha fCaptcha;

                CVacancy v = new CVacancy(
                    workingVacancyList[i].department_ru
                    , workingVacancyList[i].description_uz
                    , workingVacancyList[i].e_category_id
                    , workingVacancyList[i].salary
                    , workingVacancyList[i].e_employment_id
                    , workingVacancyList[i].e_gender_id
                    , workingVacancyList[i].e_experience_id
                    , workingVacancyList[i].e_education_id
                    , workingVacancyList[i].expire_date
                    , VACANCY_STATUS.OPEN
                    , workingVacancyList[i].department_ru
                    , workingVacancyList[i].department_uz
                    , workingVacancyList[i].specialization_ru
                    , workingVacancyList[i].specialization_uz
                    , workingVacancyList[i].requirements_ru
                    , workingVacancyList[i].requirements_uz
                    , workingVacancyList[i].information_ru
                    , workingVacancyList[i].information_uz
                );

                using (fCaptcha = new frmCaptcha())
                {
                    if (fCaptcha.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Program.vac.SetCaptchaText(fCaptcha.captchaText);

                        if (Program.vac.AddVacancy(v))
                        {
                            imported++;

                            ListViewItem li = lstVacancies.Items[i];
                            li.SubItems[2].Text = "Imported";

                            li.BackColor = Color.Green;
                        }
                        else
                        {
                            ListViewItem li = lstVacancies.Items[i];
                            li.SubItems[2].Text = "Import error";

                            li.BackColor = Color.Red;
                        }
                    }
                    else
                    {
                        ListViewItem li = lstVacancies.Items[i];
                        li.SubItems[2].Text = "Skipped";

                        li.BackColor = Color.Red;

                        continue;
                    }
                }
            }

            MessageBox.Show("Import finished. Imported " + imported + " from " + workingVacancyList.Count, "Import vacancies", MessageBoxButtons.OK, MessageBoxIcon.Information);
            toolBtnImport.Enabled = false;
        }
    }
}
