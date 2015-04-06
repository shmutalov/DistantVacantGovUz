using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DistantVacantGovUz
{
    public partial class frmRptPrintVersionSettings : Form
    {
        public frmRptPrintVersionSettings()
        {
            InitializeComponent();
        }

        public string whomText { get; set; }

        private string headerTextVal;
        public string headerText
        {
            get
            {
                return headerTextVal;
            }
            set
            {
                headerTextVal = value;
                txtReportHeader.Text = headerTextVal;
            }
        }

        public string footerText { get; set; }

        public List<CReportVisaItem> visas { get; set; }

        private void btnOk_Click(object sender, EventArgs e)
        {
            whomText = txtWhom.Text;
            headerText = txtReportHeader.Text;
            footerText = txtFooter.Text;

            visas = new List<CReportVisaItem>();

            foreach (ListViewItem li in lstVisas.Items)
            {
                visas.Add(new CReportVisaItem(li.Text, li.SubItems[1].Text));
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void frmRptPrintVersionSettings_Load(object sender, EventArgs e)
        {
            /*defaultHeaderText = "ВАКАНТНЫЕ" + "\n"
                    + "должности инженерно-технических работников и рабочих по АО \"Алмалыкский ГМК\" для размещения в Едином портале интерактивных государственных услуг на " + DateTime.Now.ToString("dd.MM.yyyy") + " г." + "\n";
            */

            txtReportHeader.Text = headerText;
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
            using (frmRptPrintVersionAddVisa f = new frmRptPrintVersionAddVisa())
            {
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ListViewItem li = lstVisas.Items.Add(f.strJobTitle);
                    li.SubItems.Add(f.strSubject);
                }
            }
        }

        private void btnEditJobTitle_Click(object sender, EventArgs e)
        {
            if (lstVisas.SelectedItems.Count == 1)
            {
                using (frmRptPrintVersionEditVisa f = new frmRptPrintVersionEditVisa())
                {
                    f.strJobTitle = lstVisas.SelectedItems[0].Text;
                    f.strSubject = lstVisas.SelectedItems[0].SubItems[1].Text;

                    if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        lstVisas.SelectedItems[0].Text = f.strJobTitle;
                        lstVisas.SelectedItems[0].SubItems[1].Text = f.strSubject;
                    }
                }
            }
        }
    }
}
