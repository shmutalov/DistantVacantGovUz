using System;
using System.Windows.Forms;

namespace DistantVacantGovUz.Windows
{
    public partial class PortalVacanciesWindow : Form
    {
        private OpenVacanciesWindow _openVacancies;
        private ClosedVacanciesWindow _closedVacancies;

        public PortalVacanciesWindow()
        {
            InitializeComponent();
        }

        private void frmPortalVacancies_Load(object sender, EventArgs e)
        {
            Show();

            Cursor = Cursors.AppStarting;

            var fLogin = new LoginToPortalWindow();

            if (fLogin.ShowDialog() == DialogResult.OK)
            {
                _openVacancies = new OpenVacanciesWindow
                {
                    MdiParent = this
                };

                _openVacancies.Show();

                LayoutMdi(MdiLayout.TileVertical);

                Cursor = Cursors.Default;
            }
            else
            {
                Close();
            }
        }

        private void mnuWindowLayoutArrangeIcons_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void mnuWindowLayoutCascade_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuWindowLayoutTileH_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuWindowLayoutTileV_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuWindowShowAll_Click(object sender, EventArgs e)
        {
            foreach (var child in MdiChildren)
            {
                child.WindowState = FormWindowState.Normal;
            }
        }

        private void mnuWindowHideAll_Click(object sender, EventArgs e)
        {
            foreach (var child in MdiChildren)
            {
                child.WindowState = FormWindowState.Minimized;
            }
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var child in MdiChildren)
            {
                child.Close();
            }
        }

        private void mnuWindowOpenOpenedVacs_Click(object sender, EventArgs e)
        {
            if (_openVacancies != null && !_openVacancies.IsDisposed)
            {
                _openVacancies.WindowState = FormWindowState.Normal;
                return;
            }

            _openVacancies = new OpenVacanciesWindow
            {
                MdiParent = this
            };

            _openVacancies.Show();
        }

        private void mnuWindowOpenClosedVacs_Click(object sender, EventArgs e)
        {
            if (_closedVacancies != null && !_closedVacancies.IsDisposed)
            {
                _closedVacancies.WindowState = FormWindowState.Normal;
                return;
            }

            _closedVacancies = new ClosedVacanciesWindow
            {
                MdiParent = this
            };

            _closedVacancies.Show();
        }

        private void mnuImportToPortal_Click(object sender, EventArgs e)
        {
            new ImportPortalVacanciesWindow().ShowDialog();
        }

        private void frmPortalVacancies_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.VacancyApi.Logout();
        }
    }
}
