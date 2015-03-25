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
            Program.vac.GetClosedVacancies();
        }

        private void toolBtnRefreshVacancies_Click(object sender, EventArgs e)
        {
            RefreshVacancyList();
        }
    }
}
