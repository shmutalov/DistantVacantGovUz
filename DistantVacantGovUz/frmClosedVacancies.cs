using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DistantVacantGovUz
{
    public partial class frmClosedVacancies : Form
    {
        public frmClosedVacancies()
        {
            InitializeComponent();
        }

        private void RefreshVacancyList()
        {
            lstVacancies.Items.Clear();

            frmLoading fLoading = new frmLoading();

            CVacancyPortalPreloader preloader = new CVacancyPortalPreloader(fLoading, VACANCY_STATUS.CLOSED);
            workerRefreshVacancyList.RunWorkerAsync(preloader);

            fLoading.SetOperationName(this.Text);
            fLoading.ShowDialog();

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
            this.Show();
            RefreshVacancyList();
        }

        private void toolBtnCheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstVacancies.Items.Count; i++)
            {
                lstVacancies.Items[i].Checked = true;
            }
        }

        private void toolBtnUncheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstVacancies.Items.Count; i++)
            {
                lstVacancies.Items[i].Checked = false;
            }
        }

        private void workerRefreshVacancyList_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker wrkr = (BackgroundWorker)sender;
            CVacancyPortalPreloader preldr = (CVacancyPortalPreloader)e.Argument;

            preldr.DoWork(wrkr, e);
        }

        private void workerRefreshVacancyList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CVacancyPortalPreloader preldr = (CVacancyPortalPreloader)e.Result;
            List<CVacancyListElement> vacs = preldr.GetVacancyList();

            if (vacs != null)
            {
                int i = 1;

                foreach (CVacancyListElement v in vacs)
                {
                    ListViewItem li = lstVacancies.Items.Add("");
                    li.SubItems.Add(i.ToString());
                    li.SubItems.Add(v.iID.ToString());
                    li.SubItems.Add(v.strDescription);

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
                int statusChanged = 0;

                foreach (ListViewItem li in lstVacancies.CheckedItems)
                {
                    try
                    {
                        int portalVacancyId = int.Parse(li.SubItems[2].Text);

                        using (frmCaptcha fCaptcha = new frmCaptcha())
                        {
                            if (fCaptcha.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                Program.vac.SetCaptchaText(fCaptcha.captchaText);

                                if (Program.vac.SetVacancyStatus(portalVacancyId, VACANCY_STATUS.OPEN))
                                    statusChanged++;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }

                MessageBox.Show
                (
                    String.Format
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
                int portalVacancyId = int.Parse(lstVacancies.SelectedItems[0].SubItems[2].Text);

                frmEditPortalVacancy fEdit = new frmEditPortalVacancy(portalVacancyId);

                if (fEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    RefreshVacancyList();
                }
            }
        }

        private void toolBtnExportVacancies_Click(object sender, EventArgs e)
        {
            if (lstVacancies.Items.Count == 0)
                return;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = language.strings.portalVacExportSaveFilter;

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                frmLoading fLoading = new frmLoading();

                CVacancyPortalExporter exporter = new CVacancyPortalExporter(sfd.FileName, fLoading, VACANCY_STATUS.CLOSED);
                workerExportVacancies.RunWorkerAsync(exporter);

                fLoading.SetOperationName(language.strings.portalVacExporting + this.Text);
                fLoading.ShowDialog();
            }
        }

        private void workerExportVacancies_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CVacancyPortalExporter exprtr = (CVacancyPortalExporter)e.Result;
            List<CVacancy> vacs = exprtr.GetVacancyList();
            List<CVacancyItem> vacancyItems = new List<CVacancyItem>();
            string fileName = exprtr.GetFileName();

            if (vacs != null)
            {
                for (int i = 0; i < vacs.Count; i++)
                {
                    CVacancyItem vItem = new CVacancyItem();
                    vItem.InitFromCVacancy(vacs[i]);
                    vItem.seqNum = (i + 1).ToString();
                    vacancyItems.Add(vItem);
                }
            }

            exprtr.GetLoadingForm().Close();

            if (CVacancyFileType.SaveFile(fileName, vacancyItems))
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
            BackgroundWorker wrkr = (BackgroundWorker)sender;
            CVacancyPortalExporter exprtr = (CVacancyPortalExporter)e.Argument;

            exprtr.DoWork(wrkr, e);
        }

        private void workerExportVacancies_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            CVacancyPortalExporter exprtr = (CVacancyPortalExporter)e.UserState;
            frmLoading fLoading = (frmLoading)exprtr.GetLoadingForm();

            fLoading.SetStatus(String.Format(language.strings.exportStatus
                , exprtr.GetExportedVacanciesCount()
                , exprtr.GetTotalVacanciesCount()
                , e.ProgressPercentage));
        }

        private void lstVacancies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVacancies.SelectedIndices.Count == 1)
                toolBtnEditVacancy.Enabled = true;
            else
                toolBtnEditVacancy.Enabled = false;
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
