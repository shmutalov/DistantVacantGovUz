using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DistantVacantGovUz
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void mnuAboutProgram_Click(object sender, EventArgs e)
        {
            frmAbout fAbout = new frmAbout();
            
            fAbout.ShowDialog();
        }

        private void mnuPortalVacancies_Click(object sender, EventArgs e)
        {
            frmPortalVacancies fPortal = new frmPortalVacancies();

            fPortal.Show();
        }

        private void mnuFileSettings_Click(object sender, EventArgs e)
        {
            frmSettings f = new frmSettings();

            f.ShowDialog();
        }

        private void mnuFileCreateNew_Click(object sender, EventArgs e)
        {
            frmLocalDocument f = new frmLocalDocument();
            f.MdiParent = this;

            f.Show();
        }
    }
}
