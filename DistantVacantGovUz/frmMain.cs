using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DistantVacantGovUz
{
    public partial class frmMain : Form
    {
        public class CVacancyLoaderArgument
        {
            public List<CVacancyItem> vacancyList;
            public string fileName;

            public CVacancyLoaderArgument(List<CVacancyItem> vacancyList, string fileName)
            {
                this.vacancyList = vacancyList;
                this.fileName = fileName;
            }
        }

        public frmMain()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void mnuAboutProgram_Click(object sender, EventArgs e)
        {
            frmAbout fAbout = new frmAbout();
            
            fAbout.ShowDialog();
        }

        private void mnuPortalVacancies_Click(object sender, EventArgs e)
        {
            frmPortalVacancies fPortal = new frmPortalVacancies();

            fPortal.Show();
        }

        private void mnuFileSettings_Click(object sender, EventArgs e)
        {
            frmSettings f = new frmSettings();

            f.ShowDialog();
        }

        private void mnuFileCreateNew_Click(object sender, EventArgs e)
        {
            frmLocalDocument f = new frmLocalDocument();
            f.MdiParent = this;

            f.Show();
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.CheckFileExists = true;
            ofd.Filter = "Файл Вакансий (*.vac, *.vacx)|*.vac;*.vacx";
            ofd.Title = "Выберите файл вакансий";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                frmLoading fLoading = new frmLoading();

                CVacancyDocumentPreloader preloader = new CVacancyDocumentPreloader(ofd.FileName, fLoading);
                worker.RunWorkerAsync(preloader);

                fLoading.SetOperationName(ofd.FileName);
                fLoading.ShowDialog();

                /*if (vacancyList != null)
                {
                    frmLocalDocument f = new frmLocalDocument();
                    f.MdiParent = this;
                    f.SetDocument(ofd.FileName, vacancyList);

                    f.Show();
                }*/
            }
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

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {

            BackgroundWorker wrkr = (BackgroundWorker)sender;
            CVacancyDocumentPreloader preldr = (CVacancyDocumentPreloader)e.Argument;

            preldr.DoWork(wrkr, e);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CVacancyDocumentPreloader preldr = (CVacancyDocumentPreloader)e.Result;

            if (preldr.GetVacancyList() != null)
            {
                frmLocalDocument f = new frmLocalDocument();
                f.MdiParent = this;
                f.SetDocument(preldr.GetFileName(), preldr.GetVacancyList());

                f.Show();
            }

            preldr.GetLoadingForm().Close();
        }
    }
}
