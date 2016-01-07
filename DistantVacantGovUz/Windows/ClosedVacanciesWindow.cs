using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DistantVacantGovUz.Enums;
using DistantVacantGovUz.Models;
using DistantVacantGovUz.Utils;

namespace DistantVacantGovUz.Windows
{
    public partial class ClosedVacanciesWindow : Form
    {
        public ClosedVacanciesWindow()
        {
            InitializeComponent();
        }

        private void RefreshVacancyList()
        {
            lstVacancies.Items.Clear();

            var loading = new LoadingWindow();

            var preloader = new VacancyPreloader(loading, VacancyStatus.Closed);
            workerRefreshVacancyList.RunWorkerAsync(preloader);

            loading.SetOperationName(Text);
            loading.ShowDialog();

        }

        private void toolBtnRefreshVacancies_Click(object sender, EventArgs e)
        {
            RefreshVacancyList();
        }

        private void toolbar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmClosedVacancies_Load(object sender, EventArgs e)
        {
            Show();
            RefreshVacancyList();
        }

        private void toolBtnCheckAll_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < lstVacancies.Items.Count; i++)
            {
                lstVacancies.Items[i].Checked = true;
            }
        }

        private void toolBtnUncheckAll_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < lstVacancies.Items.Count; i++)
            {
                lstVacancies.Items[i].Checked = false;
            }
        }

        private void workerRefreshVacancyList_DoWork(object sender, DoWorkEventArgs e)
        {
            var wrkr = (BackgroundWorker)sender;
            var preldr = (VacancyPreloader)e.Argument;

            preldr.DoWork(wrkr, e);
        }

        private void workerRefreshVacancyList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var preldr = (VacancyPreloader)e.Result;
            var vacs = preldr.GetVacancyList();

            if (vacs != null)
            {
                var i = 1;

                foreach (var v in vacs)
                {
                    var li = lstVacancies.Items.Add("");
                    li.SubItems.Add(i.ToString());
                    li.SubItems.Add(v.Id.ToString());
                    li.SubItems.Add(v.Description);

                    i++;
                }

                if (vacs.Count > 0)
                {
                    toolBtnCheckAll.Enabled = true;
                    toolBtnExportVacancies.Enabled = true;
                }
                else
                {
                    toolBtnCheckAll.Enabled = false;
                    toolBtnExportVacancies.Enabled = false;
                }

                toolBtnEditVacancy.Enabled = false;
                toolBtnChangeStatus.Enabled = false;
                toolBtnUncheckAll.Enabled = false;
            }

            preldr.GetLoadingForm().Close();
        }

        private void toolBtnChangeStatus_Click(object sender, EventArgs e)
        {
            if (lstVacancies.CheckedItems.Count > 0)
            {
                var statusChanged = 0;

                foreach (ListViewItem li in lstVacancies.CheckedItems)
                {
                    try
                    {
                        var portalVacancyId = int.Parse(li.SubItems[2].Text);

                        using (var captcha = new CaptchaWindow())
                        {
                            if (captcha.ShowDialog() != DialogResult.OK)
                                continue;

                            Program.VacancyApi.SetCaptchaText(captcha.CaptchaText);

                            if (Program.VacancyApi.SetVacancyStatus(portalVacancyId, VacancyStatus.Open))
                                statusChanged++;
                        }
                    }
                    catch (Exception)
                    {
                        // ignore
                    }
                }

                MessageBox.Show
                (
                    string.Format
                    (
                        language.strings.MsgPortalVacStatusChanged
                        , statusChanged
                        , lstVacancies.CheckedItems.Count
                    )
                    , language.strings.MsgPortalVacStatusChangeCaption
                    , MessageBoxButtons.OK, MessageBoxIcon.Information
                );

                RefreshVacancyList();
            }
        }

        private void toolBtnEditVacancy_Click(object sender, EventArgs e)
        {
            if (lstVacancies.SelectedIndices.Count == 1)
            {
                var portalVacancyId = int.Parse(lstVacancies.SelectedItems[0].SubItems[2].Text);

                var fEdit = new EditPortalVacancyWindow(portalVacancyId);

                if (fEdit.ShowDialog() == DialogResult.OK)
                {
                    RefreshVacancyList();
                }
            }
        }

        private void toolBtnExportVacancies_Click(object sender, EventArgs e)
        {
            if (lstVacancies.Items.Count == 0)
                return;

            var sfd = new SaveFileDialog
            {
                Filter = language.strings.portalVacExportSaveFilter
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var fLoading = new LoadingWindow();

            var exporter = new VacancyExporter(sfd.FileName, fLoading, VacancyStatus.Closed);
            workerExportVacancies.RunWorkerAsync(exporter);

            fLoading.SetOperationName(language.strings.portalVacExporting + Text);
            fLoading.ShowDialog();
        }

        private void workerExportVacancies_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var exprtr = (VacancyExporter)e.Result;
            var vacs = exprtr.GetVacancyList();
            var vacancyItems = new List<VacancyItem>();
            var fileName = exprtr.GetFileName();

            if (vacs != null)
            {
                for (var i = 0; i < vacs.Count; i++)
                {
                    var vItem = new VacancyItem();
                    vItem.InitFromCVacancy(vacs[i]);
                    vItem.SequenceNumber = (i + 1).ToString();
                    vacancyItems.Add(vItem);
                }
            }

            exprtr.GetLoadingForm().Close();

            if (VacancyFileUtil.SaveFile(fileName, vacancyItems))
            {
                MessageBox.Show(language.strings.MsgPortalVacExportSuccess
                    , language.strings.MsgPortalVacExportCaption
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(language.strings.MsgPortalVacExportSaveError
                    , language.strings.MsgPortalVacExportCaption
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void workerExportVacancies_DoWork(object sender, DoWorkEventArgs e)
        {
            var wrkr = (BackgroundWorker)sender;
            var exprtr = (VacancyExporter)e.Argument;

            exprtr.DoWork(wrkr, e);
        }

        private void workerExportVacancies_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var exprtr = (VacancyExporter)e.UserState;
            var fLoading = (LoadingWindow)exprtr.GetLoadingForm();

            fLoading.SetStatus(string.Format(language.strings.exportStatus
                , exprtr.GetExportedVacanciesCount()
                , exprtr.GetTotalVacanciesCount()
                , e.ProgressPercentage));
        }

        private void lstVacancies_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolBtnEditVacancy.Enabled = lstVacancies.SelectedIndices.Count == 1;
        }

        private void lstVacancies_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (lstVacancies.CheckedItems.Count > 0)
            {
                toolBtnChangeStatus.Enabled = true;

                if (lstVacancies.CheckedItems.Count == lstVacancies.Items.Count)
                {
                    toolBtnUncheckAll.Enabled = true;
                    toolBtnCheckAll.Enabled = false;
                }
                else
                    toolBtnCheckAll.Enabled = true;
            }
            else
            {
                toolBtnChangeStatus.Enabled = false;
                toolBtnCheckAll.Enabled = true;
                toolBtnUncheckAll.Enabled = false;
            }
        }
    }
}
