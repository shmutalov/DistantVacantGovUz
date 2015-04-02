using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DistantVacantGovUz
{
    public partial class frmLoading : Form
    {
        public void SetOperationName(string name)
        {
            if (name != "")
                this.Text = "Loading [" + name + "] ...";
        }

        public frmLoading()
        {
            InitializeComponent();
        }
    }
}
