using System;
using System.Windows.Forms;

namespace DistantVacantGovUz.Windows
{
    public partial class ReportPrintVersionAddVisaWindow : Form
    {
        public string JobTitle { get; private set; }
        public string Subject { get; private set; }

        public ReportPrintVersionAddVisaWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            JobTitle = txtJobTitle.Text;
            Subject = txtSubject.Text;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
