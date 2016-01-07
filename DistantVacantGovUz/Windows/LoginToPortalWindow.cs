using System;
using System.Windows.Forms;

namespace DistantVacantGovUz.Windows
{
    public partial class LoginToPortalWindow : Form
    {
        public LoginToPortalWindow()
        {
            InitializeComponent();
        }

        private void Login()
        {
            if ((txtUserName.Text == "") || (txtPassword.Text == ""))
            {
                lblStatus.Text = language.strings.loginFillAllFields;
                return;
            }

            if (Program.VacancyApi.Login(txtUserName.Text, txtPassword.Text))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                lblStatus.Text = language.strings.loginFailed;
                lblStatus.Text += Program.VacancyApi.GetLastErrorMessage();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void txtUserName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                txtPassword.Select();
            }
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Login();
            }
        }

        private void frmPortalLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
