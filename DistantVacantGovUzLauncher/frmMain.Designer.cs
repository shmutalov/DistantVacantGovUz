namespace DistantVacantGovUzLauncher
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
            resources.ApplyResources(this.lblStatus, "lblStatus");
            this.lblStatus.Name = "lblStatus";
            // 
            // pbar
            // 
            resources.ApplyResources(this.pbar, "pbar");
            this.pbar.Name = "pbar";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
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
            resources.ApplyResources(this.lstStatus, "lstStatus");
            this.lstStatus.BackColor = System.Drawing.Color.Black;
            this.lstStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnStatusLine});
            this.lstStatus.ForeColor = System.Drawing.Color.White;
            this.lstStatus.FullRowSelect = true;
            this.lstStatus.Name = "lstStatus";
            this.lstStatus.UseCompatibleStateImageBehavior = false;
            this.lstStatus.View = System.Windows.Forms.View.Details;
            // 
            // clmnStatusLine
            // 
            resources.ApplyResources(this.clmnStatusLine, "clmnStatusLine");
            // 
            // btnForceLaunch
            // 
            resources.ApplyResources(this.btnForceLaunch, "btnForceLaunch");
            this.btnForceLaunch.Name = "btnForceLaunch";
            this.btnForceLaunch.UseVisualStyleBackColor = true;
            this.btnForceLaunch.Click += new System.EventHandler(this.btnForceLaunch_Click);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnForceLaunch);
            this.Controls.Add(this.lstStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pbar);
            this.Controls.Add(this.lblStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
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

