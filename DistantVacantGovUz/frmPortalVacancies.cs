using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DistantVacantGovUz
{
    public partial class frmPortalVacancies : Form
    {
        private frmOpenedVacancies fOpened;
        private frmClosedVacancies fClosed;

        public frmPortalVacancies()
        {
            InitializeComponent();
        }

        private void frmPortalVacancies_Load(object sender, EventArgs e)
        {
            fOpened = new frmOpenedVacancies();
            fOpened.MdiParent = this;
            fOpened.Show();

            fClosed = new frmClosedVacancies();
            fClosed.MdiParent = this;
            fClosed.Show();

            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuWindowLayoutArrangeIcons_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void mnuWindowLayoutCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuWindowLayoutTileH_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuWindowLayoutTileV_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuWindowShowAll_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.WindowState = FormWindowState.Normal;
            }
        }

        private void mnuWindowHideAll_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.WindowState = FormWindowState.Minimized;
            }
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
        }

        private void mnuWindowOpenOpenedVacs_Click(object sender, EventArgs e)
        {
            if (fOpened != null && !fOpened.IsDisposed)
            {
                fOpened.WindowState = FormWindowState.Normal;
                return;
            }

            fOpened = new frmOpenedVacancies();
            fOpened.MdiParent = this;
            fOpened.Show();
        }

        private void mnuWindowOpenClosedVacs_Click(object sender, EventArgs e)
        {
            if (fClosed != null && !fClosed.IsDisposed)
            {
                fClosed.WindowState = FormWindowState.Normal;
                return;
            }

            fClosed = new frmClosedVacancies();
            fClosed.MdiParent = this;
            fClosed.Show();
        }

        private void mnuImportToPortal_Click(object sender, EventArgs e)
        {
            frmImportPortalVacancies fImport;

            fImport = new frmImportPortalVacancies();
            fImport.ShowDialog();
        }
    }
}
