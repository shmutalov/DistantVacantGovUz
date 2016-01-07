using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DistantVacantGovUz.Models;

namespace DistantVacantGovUz.Windows
{
    public partial class ReportPrintVersionSettingsWindow : Form
    {
        public ReportPrintVersionSettingsWindow()
        {
            InitializeComponent();
        }

        public string WhomText { get; private set; }

        private string _headerTextVal;
        public string HeaderText
        {
            get
            {
                return _headerTextVal;
            }
            set
            {
                _headerTextVal = value;
                txtReportHeader.Text = _headerTextVal;
            }
        }

        public string FooterText { get; private set; }

        public List<ReportVisaItem> Visas { get; private set; }

        private void btnOk_Click(object sender, EventArgs e)
        {
            WhomText = txtWhom.Text;
            HeaderText = txtReportHeader.Text;
            FooterText = txtFooter.Text;

            Visas = new List<ReportVisaItem>();

            foreach (ListViewItem li in lstVisas.Items)
            {
                Visas.Add(new ReportVisaItem(li.Text, li.SubItems[1].Text));
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void frmRptPrintVersionSettings_Load(object sender, EventArgs e)
        {
            /*defaultHeaderText = "ВАКАНТНЫЕ" + "\n"
                    + "должности инженерно-технических работников и рабочих по АО \"Алмалыкский ГМК\" для размещения в Едином портале интерактивных государственных услуг на " + DateTime.Now.ToString("dd.MM.yyyy") + " г." + "\n";
            */

            txtReportHeader.Text = HeaderText;
        }

        private void frmRptPrintVersionSettings_Shown(object sender, EventArgs e)
        {
            btnOk.Focus();
        }

        private void btnDeleteSelectedJobTitle_Click(object sender, EventArgs e)
        {
            if (lstVisas.SelectedItems.Count == 1)
            {
                lstVisas.Items.Remove(lstVisas.SelectedItems[0]);
            }
        }

        private void btnAddJobTitle_Click(object sender, EventArgs e)
        {
            using (var f = new ReportPrintVersionAddVisaWindow())
            {
                if (f.ShowDialog() != DialogResult.OK)
                    return;

                var li = lstVisas.Items.Add(f.JobTitle);
                li.SubItems.Add(f.Subject);
            }
        }

        private void btnEditJobTitle_Click(object sender, EventArgs e)
        {
            if (lstVisas.SelectedItems.Count == 1)
            {
                using (var editVisaWindow = new ReportPrintVersionEditVisaWindow())
                {
                    editVisaWindow.JobTitle = lstVisas.SelectedItems[0].Text;
                    editVisaWindow.Subject = lstVisas.SelectedItems[0].SubItems[1].Text;

                    if (editVisaWindow.ShowDialog() != DialogResult.OK)
                        return;

                    lstVisas.SelectedItems[0].Text = editVisaWindow.JobTitle;
                    lstVisas.SelectedItems[0].SubItems[1].Text = editVisaWindow.Subject;
                }
            }
        }
    }
}
