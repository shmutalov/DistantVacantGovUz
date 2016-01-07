using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DistantVacantGovUz.Utils;

namespace DistantVacantGovUz.Windows
{
    public partial class MainWindow : Form
    {
        public delegate void OpenDocumentDelegate(string fileName);
        public OpenDocumentDelegate OpenDocDelegate;

        private void ShowMainWindowAndOpenDocument(string fileName)
        {
            Show();
            OpenDocument(fileName);
        }

        public MainWindow()
        {
            InitializeComponent();
            IsMdiContainer = true;
        }

        public MainWindow(string fileName)
        {
            InitializeComponent();
            IsMdiContainer = true;

            OpenDocument(fileName);
        }

        private void mnuAboutProgram_Click(object sender, EventArgs e)
        {
            var fAbout = new AboutWindow();
            
            fAbout.ShowDialog();
        }

        private void mnuPortalVacancies_Click(object sender, EventArgs e)
        {
            var fPortal = new PortalVacanciesWindow();

            fPortal.Show();
        }

        private void mnuFileSettings_Click(object sender, EventArgs e)
        {
            var f = new SettingsWindow();

            f.ShowDialog();
        }

        private void mnuFileCreateNew_Click(object sender, EventArgs e)
        {
            var documentWindow = new LocalDocumentWindow {MdiParent = this};
            documentWindow.SetDocument(language.strings.frmMainNewDocumentTitle + (MdiChildren.Length));

            documentWindow.Show();
        }

        private void OpenDocument(string fileName)
        {
            var fLoading = new LoadingWindow();

            // Check, is document already opened in editor
            foreach (var doc in MdiChildren.Cast<LocalDocumentWindow>()
                .Where(doc => doc.GetDocumentFileName().Equals(fileName)))
            {
                MessageBox.Show(language.strings.MsgOpenVacancyDocumentAlreadyOpened
                    , language.strings.MsgOpenVacancyDocumentCaption
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);

                doc.Focus();

                return;
            }

            var preloader = new VacancyDocumentPreloader(fileName, fLoading);
            worker.RunWorkerAsync(preloader);

            fLoading.SetOperationName(fileName);
            fLoading.ShowDialog();
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = language.strings.openVacancyDocumentFilter,
                Title = language.strings.openVacancyDocumentTitle
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                OpenDocument(ofd.FileName);
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

        private void frmMain_Load(object sender, EventArgs e)
        {
            OpenDocDelegate += ShowMainWindowAndOpenDocument;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {

            var wrkr = (BackgroundWorker)sender;
            var preldr = (VacancyDocumentPreloader)e.Argument;

            preldr.DoWork(wrkr, e);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var preldr = (VacancyDocumentPreloader)e.Result;

            if (preldr.GetVacancyList() != null)
            {
                var documentWindow = new LocalDocumentWindow {MdiParent = this};
                documentWindow.SetDocument(preldr.GetFileName(), preldr.GetVacancyList());

                documentWindow.Show();
            }
            else
            {
                MessageBox.Show(language.strings.MsgOpenVacancyDocumentError + VacancyFileUtil.GetLastError()
                    , language.strings.MsgOpenVacancyDocumentCaption
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            preldr.GetLoadingForm().Close();
        }
    }
}
