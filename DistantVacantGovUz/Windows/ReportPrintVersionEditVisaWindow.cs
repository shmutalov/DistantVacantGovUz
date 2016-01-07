using System;
using System.Windows.Forms;

namespace DistantVacantGovUz.Windows
{
    public partial class ReportPrintVersionEditVisaWindow : Form
    {
        private string _jobTitle;
        private string _subject;

        public string JobTitle
        {
            get { return _jobTitle; }
            set
            {
                _jobTitle = value;
                txtJobTitle.Text = _jobTitle;
            }
        }

        public string Subject
        {
            get { return _subject; }
            set
            {
                _subject = value;
                txtSubject.Text = _subject;
            }
        }

        public ReportPrintVersionEditVisaWindow()
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
