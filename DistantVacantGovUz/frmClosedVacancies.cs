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

            int i = 1;

            foreach (CVacancyListElement v in vacs)
            {
                ListViewItem li = lstVacancies.Items.Add("");
                li.SubItems.Add(i.ToString());
                li.SubItems.Add(v.iID.ToString());
                li.SubItems.Add(v.strDescription);

                i++;
            }

            preldr.GetLoadingForm().Close();
        }

        private void toolBtnChangeStatus_Click(object sender, EventArgs e)
        {

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
            sfd.Filter = "Файл Вакансий (*.vacx)|*.vacx";

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                frmLoading fLoading = new frmLoading();

                CVacancyPortalExporter exporter = new CVacancyPortalExporter(sfd.FileName, fLoading, VACANCY_STATUS.CLOSED);
                workerExportVacancies.RunWorkerAsync(exporter);

                fLoading.SetOperationName("Exporting " + this.Text);
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

            if (CVacancyFileType.SaveFile(fileName, vacancyItems))
            {
                MessageBox.Show("Вакансии успешно экпортированы и сохранены", "Экпорт вакансий", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка сохранения экспортированных вакансий", "Экпорт вакансий", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            exprtr.GetLoadingForm().Close();
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

            fLoading.SetStatus("Exported " + exprtr.GetExportedVacanciesCount() + " from " + exprtr.GetTotalVacanciesCount() + "\n" + e.ProgressPercentage + "%");
        }
    }
}
