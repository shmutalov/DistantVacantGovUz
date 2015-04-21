using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.IO;

namespace DistantVacantGovUzLauncher
{
    public partial class frmMain : Form
    {
        private bool updateError = false;
        private bool updateCancelled = false;

        public frmMain()
        {
            InitializeComponent();
        }

        private void StartVacancies() {
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = Program.GetApplicationDirectory() + "\\" + "DistantVacantGovUz.exe";

            foreach (String arg in Program.argv)
                processInfo.Arguments += "\"" + arg + "\" ";

            try
            {
                Process.Start(processInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(language.strings.MsgLaunchAppError, processInfo.FileName, ex.Message)
                    , language.strings.MsgLaunchAppErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (updateError)
                this.Close();

            if (updateCancelled)
            {
                StartVacancies();
            }

            worker.CancelAsync();
        }

        private void SetLauncherState()
        {
            if (updateError)
            {
                btnCancel.Text = language.strings.btnCancel_CloseText;
                btnForceLaunch.Enabled = true;
                return;
            }

            if (updateCancelled)
            {
                btnCancel.Text = language.strings.btnCancel_ContinueText;
                return;
            }

            // autostart
            StartVacancies();
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateState state = (UpdateState)e.UserState;
            lblStatus.Text = state.info;

            ListViewItem item = lstStatus.Items.Add(lblStatus.Text);
            
            if (state.status == -1)
                item.ForeColor = Color.Red;

            if (state.status == 1)
                item.ForeColor = Color.LightBlue;
            
            pbar.Value = e.ProgressPercentage;

            if (state.status == -1)
                updateError = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            /*if (Program.isAdmin)
                lstStatus.Items.Add("Запуск с правами администратора").ForeColor = Color.Green;
            else
                lstStatus.Items.Add("Запуск без прав администратора").ForeColor = Color.LightBlue;*/

            String filePath = Program.GetApplicationDirectory() + "\\" + "DistantVacantGovUz.exe";
            FileVersionInfo fvi = null;

            try
            {
                fvi = FileVersionInfo.GetVersionInfo(filePath);
            }
            catch (Exception ex)
            {
                lblStatus.Text = language.strings.statusCannotRetreiveApplicationCurrentVersion;
                lstStatus.Items.Add(lblStatus.Text).ForeColor = Color.Red;

                updateError = true;
                SetLauncherState();
                return;
            }

            VacancyBackgroundUpdater updater = new VacancyBackgroundUpdater(fvi.ProductVersion);
            worker.RunWorkerAsync(updater);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!updateError)
                updateError = e.Error != null;

            updateCancelled = e.Cancelled;

            if (updateError)
                lblStatus.Text = language.strings.statusErrorOccured;
            else if (updateCancelled)
                lblStatus.Text = language.strings.statusOperationCanceled;
            else
                lblStatus.Text = language.strings.statusFinished;

            lstStatus.Items.Add(lblStatus.Text);

            SetLauncherState();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker wrkr = (BackgroundWorker)sender;
            VacancyBackgroundUpdater updtr = (VacancyBackgroundUpdater)e.Argument;

            updtr.DoWork(worker, e);
        }

        private void btnForceLaunch_Click(object sender, EventArgs e)
        {
            StartVacancies();
        }
    }
}
