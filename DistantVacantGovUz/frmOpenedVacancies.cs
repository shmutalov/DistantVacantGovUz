using System;
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

            List<CVacancyListElement> vacs = Program.vac.GetActualVacancies();

            int i = 1;

            foreach (CVacancyListElement v in vacs)
            {
                ListViewItem li = lstVacancies.Items.Add("");
                li.SubItems.Add(i.ToString());
                li.SubItems.Add(v.iID.ToString());
                li.SubItems.Add(v.strDescription);

                i++;
            }
        }

        private void toolBtnRefreshVacancies_Click(object sender, EventArgs e)
        {
            RefreshVacancyList();
        }

        private void frmOpenedVacancies_Load(object sender, EventArgs e)
        {
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
    }
}
