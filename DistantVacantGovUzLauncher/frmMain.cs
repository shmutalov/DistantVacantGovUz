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

namespace VacancyImporterLauncher
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
            /*lstStatus.Items.Add("Проверка ассоциации файлов...").ForeColor = Color.White;

            // Проверим ассоциации файлов
            if (!FileAssociation.IsAssociated(".vac"))
            {
                lstStatus.Items.Add("Ассоциации не найдены, применяем...").ForeColor = Color.White;

                if (FileAssociation.Associate(".vac", "VACANCY.AGMK", "AGMK Vacancies document", null, Assembly.GetExecutingAssembly().Location))
                {
                    lstStatus.Items.Add("Ассоциации применены.").ForeColor = Color.Green;
                }
                else
                {
                    lstStatus.Items.Add("Не удалось применить ассоциации.").ForeColor = Color.Red;
                }
            }

            lstStatus.Items.Add("Завершено.").ForeColor = Color.LightBlue;*/

            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + "Vacant_AGMK.exe";

            foreach (String arg in Program.argv)
                processInfo.Arguments += "\"" + arg + "\" ";

            try
            {
                Process.Start(processInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при попытке запустить программу\n\n" + processInfo.FileName + "\n\n" + ex.Message, "Ошибка запуска", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                btnCancel.Text = "Закрыть";
                btnForceLaunch.Enabled = true;
                return;
            }

            if (updateCancelled)
            {
                btnCancel.Text = "Продолжить";
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

            String filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + "Vacant_AGMK.exe";
            FileVersionInfo fvi = null;

            try
            {
                fvi = FileVersionInfo.GetVersionInfo(filePath);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Не удалось получить текущую версию программы.";
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
                lblStatus.Text = "Произошла ошибка.";
            else if (updateCancelled)
                lblStatus.Text = "Операция отменена.";
            else
                lblStatus.Text = "Завершено.";

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
