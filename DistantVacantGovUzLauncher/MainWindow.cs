using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace DistantVacantGovUzLauncher
{
    public partial class MainWindow : Form
    {
        private bool _updateError;
        private bool _updateCancelled;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartVacancies() {
            var processInfo = new ProcessStartInfo
            {
                FileName = Program.GetApplicationDirectory() + "\\" + "DistantVacantGovUz.exe"
            };

            foreach (var arg in Program.Argv)
                processInfo.Arguments += "\"" + arg + "\" ";

            try
            {
                Process.Start(processInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(language.strings.MsgLaunchAppError, processInfo.FileName, ex.Message)
                    , language.strings.MsgLaunchAppErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_updateError)
                Close();

            if (_updateCancelled)
            {
                StartVacancies();
            }

            worker.CancelAsync();
        }

        private void SetLauncherState()
        {
            if (_updateError)
            {
                btnCancel.Text = language.strings.btnCancel_CloseText;
                btnForceLaunch.Enabled = true;
                return;
            }

            if (_updateCancelled)
            {
                btnCancel.Text = language.strings.btnCancel_ContinueText;
                return;
            }

            // autostart
            StartVacancies();
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var state = (UpdateState)e.UserState;
            lblStatus.Text = state.Info;

            var item = lstStatus.Items.Add(lblStatus.Text);
            
            if (state.Status == -1)
                item.ForeColor = Color.Red;

            if (state.Status == 1)
                item.ForeColor = Color.LightBlue;
            
            pbar.Value = e.ProgressPercentage;

            if (state.Status == -1)
                _updateError = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            /*if (Program.isAdmin)
                lstStatus.Items.Add("Запуск с правами администратора").ForeColor = Color.Green;
            else
                lstStatus.Items.Add("Запуск без прав администратора").ForeColor = Color.LightBlue;*/

            var filePath = Program.GetApplicationDirectory() + "\\" + "DistantVacantGovUz.exe";
            FileVersionInfo fvi;

            try
            {
                fvi = FileVersionInfo.GetVersionInfo(filePath);
            }
            catch (Exception)
            {
                lblStatus.Text = language.strings.statusCannotRetreiveApplicationCurrentVersion;
                lstStatus.Items.Add(lblStatus.Text).ForeColor = Color.Red;

                _updateError = true;
                SetLauncherState();
                return;
            }

            var updater = new VacancyBackgroundUpdater(fvi.ProductVersion);
            worker.RunWorkerAsync(updater);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!_updateError)
                _updateError = e.Error != null;

            _updateCancelled = e.Cancelled;

            if (_updateError)
                lblStatus.Text = language.strings.statusErrorOccured;
            else if (_updateCancelled)
                lblStatus.Text = language.strings.statusOperationCanceled;
            else
                lblStatus.Text = language.strings.statusFinished;

            lstStatus.Items.Add(lblStatus.Text);

            SetLauncherState();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var updtr = (VacancyBackgroundUpdater)e.Argument;

            updtr.DoWork(worker, e);
        }

        private void btnForceLaunch_Click(object sender, EventArgs e)
        {
            StartVacancies();
        }
    }
}
