using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace DistantVacantGovUz.Windows
{
    public partial class AboutWindow : Form
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        private void linkProgramWebSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("https://github.com/shmutalov/DistantVacantGovUz");
            }
            catch (Exception)
            {
                // ignore
            }
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblProgramName.Text = language.strings.lblProgramName;
            lblAuthor.Text = language.strings.lblAuthor + language.strings.ProgramAuthor;
            lblAppVersion.Text = language.strings.lblAppVersion + Application.ProductVersion;
            lblLauncherVersion.Text = language.strings.lblAppLauncherVersion + Program.GetLauncherVersion();
        }
    }
}
