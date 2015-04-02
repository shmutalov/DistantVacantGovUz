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
        public class Language
        {
            public String Name { get; set; }
            public String Value { get; set; }

            public Language(string name, string value)
            {
                this.Name = name;
                this.Value = value;
            }

            public override string ToString()
            {
                return this.Name;
            }   
        }

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

            if (chkEnableUpdates.Checked)
            {
                Program.bCheckForUpdates = true;
            }
            else
            {
                Program.bCheckForUpdates = false;
            }

            Program.strUpdateServer = txtUpdateServer.Text;

            Language selectedLanguage = (Language)(cmbLanguage.SelectedItem);
            Program.strLanguage = selectedLanguage.Value;
            

            Program.SaveSettings();
            Program.LoadSettings();

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
            // Init language list
            cmbLanguage.Items.Clear();
            cmbLanguage.Items.Add(new Language("Русский", "ru"));
            cmbLanguage.Items.Add(new Language("O'zbekcha", "uz"));
            cmbLanguage.Items.Add(new Language("English", "en"));

            cmbLanguage.SelectedIndex = 0;

            for (int i = 0; i < cmbLanguage.Items.Count; i++)
            {
                Language l = (Language)cmbLanguage.Items[i];

                if (l.Value == Program.strLanguage)
                    cmbLanguage.SelectedIndex = i;
            }

            chkUseProxy.Checked = Program.vac.UseHttpProxy;

            txtProxyHost.Text = Program.strProxyHost;
            txtProxyPort.Text = Program.strProxyPort;
            txtProxyUser.Text = Program.strProxyUser;
            txtProxyPassword.Text = Program.strProxyPassword;

            chkEnableUpdates.Checked = Program.bCheckForUpdates;
            txtUpdateServer.Text = Program.strUpdateServer;
        }

        private void chkEnableUpdates_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableUpdates.Checked)
            {
                txtUpdateServer.Enabled = true;
            }
            else
            {
                txtUpdateServer.Enabled = false;
            }
        }
    }
}
