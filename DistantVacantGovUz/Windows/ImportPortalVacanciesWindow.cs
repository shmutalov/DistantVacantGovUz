using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DistantVacantGovUz.Enums;
using DistantVacantGovUz.Models;
using DistantVacantGovUz.Utils;

namespace DistantVacantGovUz.Windows
{
    public partial class ImportPortalVacanciesWindow : Form
    {
        List<VacancyItem> _workingVacancyList;
        bool _canImport;

        public ImportPortalVacanciesWindow()
        {
            InitializeComponent();
        }

        private void UpdateVacancyList()
        {
            lstVacancies.Items.Clear();

            var c = true;

            if (_workingVacancyList == null)
                return;

            _canImport = true;

            for (var i = 0; i < _workingVacancyList.Count; i++)
            {
                _workingVacancyList[i].SequenceNumber = (i + 1).ToString();

                var li = lstVacancies.Items.Add(_workingVacancyList[i].SequenceNumber);
                li.SubItems.Add(_workingVacancyList[i].DescriptionRu);

                if (_workingVacancyList[i].IsValid())
                {
                    li.BackColor = (c) ? Color.White : Color.AliceBlue;
                    li.SubItems.Add(language.strings.portalImportVacStatusNotImported);

                    c = !c;
                }
                else
                {
                    _canImport = false;

                    li.BackColor = Color.LightCoral;
                    li.SubItems.Add(language.strings.portalImportVacStatusUncompleted);
                }
            }

            foreach (ColumnHeader clmn in lstVacancies.Columns)
            {
                clmn.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        private void toolBtnBrowse_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = language.strings.openVacancyDocumentFilter,
                Title = language.strings.openVacancyDocumentTitle
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            var fLoading = new LoadingWindow();

            var preloader = new VacancyDocumentPreloader(ofd.FileName, fLoading);
            workerDocumentPreloader.RunWorkerAsync(preloader);

            fLoading.SetOperationName(ofd.FileName);
            fLoading.ShowDialog();
        }

        private void workerDocumentPreloader_DoWork(object sender, DoWorkEventArgs e)
        {
            var wrkr = (BackgroundWorker)sender;
            var preloader = (VacancyDocumentPreloader)e.Argument;

            preloader.DoWork(wrkr, e);
        }

        private void workerDocumentPreloader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var preloader = (VacancyDocumentPreloader)e.Result;

            if (preloader.GetVacancyList() != null)
            {
                Text = string.Format("{0} - {1}", language.strings.frmImportPortalVacsCaption, preloader.GetFileName());
                toolTxtImportFileName.Text = preloader.GetFileName();
                
                _workingVacancyList = preloader.GetVacancyList();

                UpdateVacancyList();
                toolBtnImport.Enabled = _canImport;
            }
            else
            {
                toolBtnImport.Enabled = false;
                MessageBox.Show(language.strings.MsgOpenVacancyDocumentError + VacancyFileUtil.GetLastError()
                    , language.strings.MsgOpenVacancyDocumentCaption
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            preloader.GetLoadingForm().Close();
        }

        private void toolBtnImport_Click(object sender, EventArgs e)
        {
            if (_workingVacancyList == null || !_canImport)
            {
                toolBtnImport.Enabled = false;
                return;
            }

            var imported = 0;

            // begin import vacancies step by step
            for (var i = 0; i < _workingVacancyList.Count; i++)
            {
                CaptchaWindow captcha;

                var v = new Vacancy(
                    _workingVacancyList[i].DepartmentRu
                    , _workingVacancyList[i].DescriptionUz
                    , _workingVacancyList[i].Category
                    , _workingVacancyList[i].Salary
                    , _workingVacancyList[i].Employment
                    , _workingVacancyList[i].Gender
                    , _workingVacancyList[i].Experience
                    , _workingVacancyList[i].Education
                    , _workingVacancyList[i].ExpireDate
                    , VacancyStatus.Open
                    , _workingVacancyList[i].DepartmentRu
                    , _workingVacancyList[i].DepartmentUz
                    , _workingVacancyList[i].SpecializationRu
                    , _workingVacancyList[i].SpecializationUz
                    , _workingVacancyList[i].RequirementsRu
                    , _workingVacancyList[i].RequirementsUz
                    , _workingVacancyList[i].InformationRu
                    , _workingVacancyList[i].InformationUz
                );

                using (captcha = new CaptchaWindow())
                {
                    if (captcha.ShowDialog() == DialogResult.OK)
                    {
                        Program.VacancyApi.SetCaptchaText(captcha.CaptchaText);

                        if (Program.VacancyApi.AddVacancy(v))
                        {
                            imported++;

                            var li = lstVacancies.Items[i];
                            li.SubItems[2].Text = language.strings.portalImportVacStatusImported;

                            li.BackColor = Color.Green;
                        }
                        else
                        {
                            var li = lstVacancies.Items[i];
                            li.SubItems[2].Text = language.strings.portalImportVacStatusImportError;

                            li.BackColor = Color.Red;
                        }
                    }
                    else
                    {
                        var li = lstVacancies.Items[i];
                        li.SubItems[2].Text = language.strings.portalImportVacStatusSkipped;

                        li.BackColor = Color.Red;
                    }
                }
            }

            MessageBox.Show(string.Format(language.strings.MsgImportPortalVacsFinished, imported, _workingVacancyList.Count)
                , language.strings.MsgImportVacsCaption
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
            toolBtnImport.Enabled = false;
        }
    }
}
