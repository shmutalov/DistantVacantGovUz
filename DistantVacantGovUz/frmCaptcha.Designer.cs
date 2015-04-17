namespace DistantVacantGovUz
{
    partial class frmCaptcha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaptcha));
            this.btnOk = new System.Windows.Forms.Button();
            this.txtCaptchaText = new System.Windows.Forms.TextBox();
            this.lnkRefreshCaptcha = new System.Windows.Forms.LinkLabel();
            this.lblCaptchaInfo = new System.Windows.Forms.Label();
            this.imgCaptcha = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgCaptcha)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtCaptchaText
            // 
            resources.ApplyResources(this.txtCaptchaText, "txtCaptchaText");
            this.txtCaptchaText.Name = "txtCaptchaText";
            this.txtCaptchaText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCaptchaText_KeyUp);
            // 
            // lnkRefreshCaptcha
            // 
            resources.ApplyResources(this.lnkRefreshCaptcha, "lnkRefreshCaptcha");
            this.lnkRefreshCaptcha.Name = "lnkRefreshCaptcha";
            this.lnkRefreshCaptcha.TabStop = true;
            this.lnkRefreshCaptcha.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRefreshCaptcha_LinkClicked);
            // 
            // lblCaptchaInfo
            // 
            resources.ApplyResources(this.lblCaptchaInfo, "lblCaptchaInfo");
            this.lblCaptchaInfo.ForeColor = System.Drawing.Color.Red;
            this.lblCaptchaInfo.Name = "lblCaptchaInfo";
            // 
            // imgCaptcha
            // 
            resources.ApplyResources(this.imgCaptcha, "imgCaptcha");
            this.imgCaptcha.Name = "imgCaptcha";
            this.imgCaptcha.TabStop = false;
            // 
            // frmCaptcha
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtCaptchaText);
            this.Controls.Add(this.lnkRefreshCaptcha);
            this.Controls.Add(this.lblCaptchaInfo);
            this.Controls.Add(this.imgCaptcha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCaptcha";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmCaptcha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgCaptcha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtCaptchaText;
        private System.Windows.Forms.LinkLabel lnkRefreshCaptcha;
        private System.Windows.Forms.Label lblCaptchaInfo;
        private System.Windows.Forms.PictureBox imgCaptcha;
    }
}