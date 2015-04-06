using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DistantVacantGovUz
{
    public partial class frmRptPrintVersionEditVisa : Form
    {
        private string jobTitle;
        private string subject;

        public string strJobTitle
        {
            get { return jobTitle; }
            set { jobTitle = value; txtJobTitle.Text = jobTitle; }
        }

        public string strSubject
        {
            get { return subject; }
            set { subject = value; txtSubject.Text = subject; }
        }

        public frmRptPrintVersionEditVisa()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            strJobTitle = txtJobTitle.Text;
            strSubject = txtSubject.Text;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
