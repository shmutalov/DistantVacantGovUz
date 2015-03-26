using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DistantVacantGovUz
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (chkUseProxy.Checked)
            {
                Program.strProxyHost = txtProxyHost.Text;
                Program.strProxyPort = txtProxyPort.Text;
                Program.strProxyUser = txtProxyUser.Text;
                Program.strProxyPassword = txtProxyPassword.Text;

                Program.EnableProxy();
            }
            else
            {
                Program.DisableProxy();
            }

            Program.SaveSettings();

            this.Close();
        }

        private void chkUseProxy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseProxy.Checked)
            {
                txtProxyHost.Enabled = true;
                txtProxyPort.Enabled = true;
                txtProxyUser.Enabled = true;
                txtProxyPassword.Enabled = true;
            }
            else
            {
                txtProxyHost.Enabled = false;
                txtProxyPort.Enabled = false;
                txtProxyUser.Enabled = false;
                txtProxyPassword.Enabled = false;
            }
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            chkUseProxy.Checked = Program.vac.UseHttpProxy;

            txtProxyHost.Text = Program.strProxyHost;
            txtProxyPort.Text = Program.strProxyPort;
            txtProxyUser.Text = Program.strProxyUser;
            txtProxyPassword.Text = Program.strProxyPassword;
        }
    }
}
