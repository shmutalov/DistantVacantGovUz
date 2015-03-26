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

        private void btnOk_Click(object sender, EventArgs e)
        {
            if ((txtUserName.Text == "") || (txtPassword.Text == ""))
            {
                lblStatus.Text = "Please, fill all fields";
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
                lblStatus.Text = "Login failed!" + "\n";
                lblStatus.Text += Program.vac.GetLastErrorMessage();
            }
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
                if ((txtUserName.Text == "") || (txtPassword.Text == ""))
                {
                    lblStatus.Text = "Please, fill all fields";
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
                    lblStatus.Text = "Login failed!" + "\n";
                    lblStatus.Text += Program.vac.GetLastErrorMessage();
                }
            }
        }
    }
}
