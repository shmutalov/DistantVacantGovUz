namespace VacancyImporterLauncher
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblStatus = new System.Windows.Forms.Label();
            this.pbar = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.lstStatus = new System.Windows.Forms.ListView();
            this.clmnStatusLine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnForceLaunch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 30);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(129, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Проверка обновлений...";
            // 
            // pbar
            // 
            this.pbar.Location = new System.Drawing.Point(15, 46);
            this.pbar.Name = "pbar";
            this.pbar.Size = new System.Drawing.Size(532, 23);
            this.pbar.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(472, 75);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // worker
            // 
            this.worker.WorkerReportsProgress = true;
            this.worker.WorkerSupportsCancellation = true;
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.worker_ProgressChanged);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // lstStatus
            // 
            this.lstStatus.BackColor = System.Drawing.Color.Black;
            this.lstStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnStatusLine});
            this.lstStatus.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstStatus.ForeColor = System.Drawing.Color.White;
            this.lstStatus.FullRowSelect = true;
            this.lstStatus.Location = new System.Drawing.Point(15, 104);
            this.lstStatus.Name = "lstStatus";
            this.lstStatus.Size = new System.Drawing.Size(532, 166);
            this.lstStatus.TabIndex = 3;
            this.lstStatus.UseCompatibleStateImageBehavior = false;
            this.lstStatus.View = System.Windows.Forms.View.Details;
            // 
            // clmnStatusLine
            // 
            this.clmnStatusLine.Text = "Информация о состоянии:";
            this.clmnStatusLine.Width = 512;
            // 
            // btnForceLaunch
            // 
            this.btnForceLaunch.Enabled = false;
            this.btnForceLaunch.Location = new System.Drawing.Point(15, 75);
            this.btnForceLaunch.Name = "btnForceLaunch";
            this.btnForceLaunch.Size = new System.Drawing.Size(146, 23);
            this.btnForceLaunch.TabIndex = 5;
            this.btnForceLaunch.Text = "Запустить программу";
            this.btnForceLaunch.UseVisualStyleBackColor = true;
            this.btnForceLaunch.Click += new System.EventHandler(this.btnForceLaunch_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 282);
            this.Controls.Add(this.btnForceLaunch);
            this.Controls.Add(this.lstStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pbar);
            this.Controls.Add(this.lblStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вакансии АГМК (версия для начальника)";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar pbar;
        private System.Windows.Forms.Button btnCancel;
        private System.ComponentModel.BackgroundWorker worker;
        private System.Windows.Forms.ListView lstStatus;
        private System.Windows.Forms.ColumnHeader clmnStatusLine;
        private System.Windows.Forms.Button btnForceLaunch;

    }
}

