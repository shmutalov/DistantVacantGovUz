﻿namespace DistantVacantGovUz
{
    partial class frmLoading
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
            this.imgLoading = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // imgLoading
            // 
            this.imgLoading.Image = global::DistantVacantGovUz.Properties.Resources.loading;
            this.imgLoading.Location = new System.Drawing.Point(185, 12);
            this.imgLoading.Name = "imgLoading";
            this.imgLoading.Size = new System.Drawing.Size(120, 128);
            this.imgLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgLoading.TabIndex = 0;
            this.imgLoading.TabStop = false;
            // 
            // frmLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(494, 153);
            this.ControlBox = false;
            this.Controls.Add(this.imgLoading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoading";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading...";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.imgLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgLoading;
    }
}