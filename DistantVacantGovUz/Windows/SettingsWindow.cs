using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace DistantVacantGovUz.Windows
{
    public partial class SettingsWindow : Form
    {
        private class Language
        {
            private string Name { get; }
            public string Value { get; }

            public Language(string name, string value)
            {
                Name = name;
                Value = value;
            }

            public override string ToString()
            {
                return Name;
            }   
        }

        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (chkUseProxy.Checked)
            {
                Program.ProxyHost = txtProxyHost.Text;
                Program.ProxyPort = txtProxyPort.Text;
                Program.ProxyUser = txtProxyUser.Text;
                Program.ProxyPassword = txtProxyPassword.Text;

                Program.EnableProxy();
            }
            else
            {
                Program.DisableProxy();
            }

            Program.CheckForUpdates = chkEnableUpdates.Checked;

            Program.UpdateServer = txtUpdateServer.Text;

            var selectedLanguage = (Language)(cmbLanguage.SelectedItem);
            Program.StrLanguage = selectedLanguage.Value;
            

            Program.SaveSettings();
            Program.LoadSettings();

            Close();
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

            for (var i = 0; i < cmbLanguage.Items.Count; i++)
            {
                var l = (Language)cmbLanguage.Items[i];

                if (l.Value == Program.StrLanguage)
                    cmbLanguage.SelectedIndex = i;
            }

            chkUseProxy.Checked = Program.VacancyApi.UseProxy;

            txtProxyHost.Text = Program.ProxyHost;
            txtProxyPort.Text = Program.ProxyPort;
            txtProxyUser.Text = Program.ProxyUser;
            txtProxyPassword.Text = Program.ProxyPassword;

            chkEnableUpdates.Checked = Program.CheckForUpdates;
            txtUpdateServer.Text = Program.UpdateServer;
        }

        private void chkEnableUpdates_CheckedChanged(object sender, EventArgs e)
        {
            txtUpdateServer.Enabled = chkEnableUpdates.Checked;
        }

        private void btnAssoc_Click(object sender, EventArgs e)
        {
            var fileName = Program.GetApplicationDirectory() + "\\DistantVacantGovUzDocAssociate.exe";
            var processInfo = new ProcessStartInfo
            {
                Verb = "runas",
                FileName = fileName
            };

            try
            {
                Process.Start(processInfo);
            }
            catch (Win32Exception)
            {
                // ignore
            }
        }
    }
}
