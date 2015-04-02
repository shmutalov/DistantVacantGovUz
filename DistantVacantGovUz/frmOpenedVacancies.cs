﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DistantVacantGovUz
{
    public partial class frmOpenedVacancies : Form
    {
        public frmOpenedVacancies()
        {
            InitializeComponent();
        }

        private void RefreshVacancyList()
        {
            lstVacancies.Items.Clear();

            frmLoading fLoading = new frmLoading();

            CVacancyPortalPreloader preloader = new CVacancyPortalPreloader(fLoading, VACANCY_STATUS.OPEN);
            workerRefreshVacancyList.RunWorkerAsync(preloader);

            fLoading.SetOperationName(this.Text);
            fLoading.ShowDialog();

            /*List<CVacancyListElement> vacs = Program.vac.GetActualVacancies();

            int i = 1;

            foreach (CVacancyListElement v in vacs)
            {
                ListViewItem li = lstVacancies.Items.Add("");
                li.SubItems.Add(i.ToString());
                li.SubItems.Add(v.iID.ToString());
                li.SubItems.Add(v.strDescription);

                i++;
            }*/
        }

        private void toolBtnRefreshVacancies_Click(object sender, EventArgs e)
        {
            RefreshVacancyList();
        }

        private void frmOpenedVacancies_Load(object sender, EventArgs e)
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
    }
}
