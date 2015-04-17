using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DistantVacantGovUz
{
    public partial class frmPortalLogin : Form
    {
        public frmPortalLogin()
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

            if (Program.vac.Login(txtUserName.Text, txtPassword.Text))
            {
                Program.strUserName = txtUserName.Text;
                Program.strPassword = txtPassword.Text;

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                lblStatus.Text = language.strings.loginFailed;
                lblStatus.Text += Program.vac.GetLastErrorMessage();
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
