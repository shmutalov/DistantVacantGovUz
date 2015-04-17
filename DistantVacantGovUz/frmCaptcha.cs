using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DistantVacantGovUz
{
    public partial class frmCaptcha : Form
    {
        public string captchaText { get; set; }

        public frmCaptcha()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Получить обновленную капчу
        /// </summary>
        private void RefreshCaptcha()
        {
            // Получим данные изображения капчи
            byte[] captcha_bytes = Program.vac.GetCapcha();

            if (captcha_bytes != null)
            {
                Image img = null;

                try
                {
                    // создадим из данных изображение
                    img = Image.FromStream(new MemoryStream(captcha_bytes));
                }
                catch (Exception ex)
                {
                    // не удалось создать изображение из данных.
                }

                imgCaptcha.Image = img;
                imgCaptcha.Refresh();
            }
        }

        private void frmCaptcha_Load(object sender, EventArgs e)
        {
            RefreshCaptcha();
            
            txtCaptchaText.Select();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            captchaText = txtCaptchaText.Text;
            this.Close();
        }

        private void lnkRefreshCaptcha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefreshCaptcha();
        }

        private void txtCaptchaText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                captchaText = txtCaptchaText.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}
