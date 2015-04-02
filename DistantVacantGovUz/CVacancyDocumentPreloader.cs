using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace DistantVacantGovUz
{
    public class CVacancyDocumentPreloader
    {
        private List<CVacancyItem> vacancyList;
        private string fileName;
        private Form loadingForm;

        public CVacancyDocumentPreloader(string fileName, Form loadingForm)
        {
            this.fileName = fileName;
            this.loadingForm = loadingForm;
        }

        public List<CVacancyItem> GetVacancyList()
        {
            return vacancyList;
        }

        public Form GetLoadingForm()
        {
            return loadingForm;
        }

        public string GetFileName()
        {
            return fileName;
        }

        public void DoWork(BackgroundWorker worker, DoWorkEventArgs e)
        {
            vacancyList = CVacancyFileType.OpenFile(fileName);
            e.Result = this;

            //worker.ReportProgress(100);
        }
    }
}
