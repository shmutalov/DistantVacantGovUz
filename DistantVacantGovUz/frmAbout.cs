using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace DistantVacantGovUz
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void linkProgramWebSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("http://www.distant.uz/vacantgovuz");
            }
            catch (Exception ex)
            {
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
