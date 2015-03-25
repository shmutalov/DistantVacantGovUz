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
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(359, 57);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(82, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Продолжить";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtCaptchaText
            // 
            this.txtCaptchaText.Location = new System.Drawing.Point(138, 59);
            this.txtCaptchaText.Name = "txtCaptchaText";
            this.txtCaptchaText.Size = new System.Drawing.Size(215, 20);
            this.txtCaptchaText.TabIndex = 9;
            this.txtCaptchaText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCaptchaText_KeyUp);
            // 
            // lnkRefreshCaptcha
            // 
            this.lnkRefreshCaptcha.AutoSize = true;
            this.lnkRefreshCaptcha.Location = new System.Drawing.Point(9, 29);
            this.lnkRefreshCaptcha.Name = "lnkRefreshCaptcha";
            this.lnkRefreshCaptcha.Size = new System.Drawing.Size(127, 13);
            this.lnkRefreshCaptcha.TabIndex = 8;
            this.lnkRefreshCaptcha.TabStop = true;
            this.lnkRefreshCaptcha.Text = "Обновить изображение";
            this.lnkRefreshCaptcha.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRefreshCaptcha_LinkClicked);
            // 
            // lblCaptchaInfo
            // 
            this.lblCaptchaInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCaptchaInfo.ForeColor = System.Drawing.Color.Red;
            this.lblCaptchaInfo.Location = new System.Drawing.Point(12, 9);
            this.lblCaptchaInfo.Name = "lblCaptchaInfo";
            this.lblCaptchaInfo.Size = new System.Drawing.Size(429, 20);
            this.lblCaptchaInfo.TabIndex = 7;
            this.lblCaptchaInfo.Text = "Для продолжения введите текст, указанный на картинке снизу:";
            // 
            // imgCaptcha
            // 
            this.imgCaptcha.Location = new System.Drawing.Point(12, 45);
            this.imgCaptcha.Name = "imgCaptcha";
            this.imgCaptcha.Size = new System.Drawing.Size(120, 50);
            this.imgCaptcha.TabIndex = 6;
            this.imgCaptcha.TabStop = false;
            // 
            // frmCaptcha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 108);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtCaptchaText);
            this.Controls.Add(this.lnkRefreshCaptcha);
            this.Controls.Add(this.lblCaptchaInfo);
            this.Controls.Add(this.imgCaptcha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCaptcha";
            this.Text = "Checking...";
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