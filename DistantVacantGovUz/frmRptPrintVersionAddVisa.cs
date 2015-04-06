using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DistantVacantGovUz
{
    public partial class frmRptPrintVersionAddVisa : Form
    {
        public string strJobTitle { get; set; }
        public string strSubject { get; set; }

        public frmRptPrintVersionAddVisa()
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
