using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Globalization;
using System.Threading;
using System.Reflection;

namespace DistantVacantGovUz
{
    public partial class frmLoading : Form
    {

        public frmLoading()
        {
            InitializeComponent();
        }

        public void SetOperationName(string name)
        {
            if (name != "")
                this.Text = language.strings.frmLoadingCaption + " [" + name + "] ...";
        }

        public void SetStatus(string statusMessage)
        {
            lblStatus.Text = statusMessage;
        }
    }
}
