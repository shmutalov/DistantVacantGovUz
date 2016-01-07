using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DistantVacantGovUz.Windows
{
    public partial class CaptchaWindow : Form
    {
        public string CaptchaText { get; private set; }

        public CaptchaWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Получить обновленную капчу
        /// </summary>
        private void RefreshCaptcha()
        {
            // Получим данные изображения капчи
            var captchaBytes = Program.VacancyApi.GetCapcha();

            if (captchaBytes != null)
            {
                Image img = null;

                try
                {
                    // создадим из данных изображение
                    img = Image.FromStream(new MemoryStream(captchaBytes));
                }
                catch (Exception)
                {
                    // не удалось создать изображение из данных.
                }

                imgCaptcha.Image = img;
                imgCaptcha.Refresh();
            }

            txtCaptchaText.Select();
        }

        private void frmCaptcha_Load(object sender, EventArgs e)
        {
            RefreshCaptcha();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            CaptchaText = txtCaptchaText.Text;
            Close();
        }

        private void lnkRefreshCaptcha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefreshCaptcha();
        }

        private void txtCaptchaText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                CaptchaText = txtCaptchaText.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
