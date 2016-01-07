using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DistantVacantGovUz.Models;

namespace DistantVacantGovUz.Utils
{
    public class VacancyDocumentPreloader
    {
        private List<VacancyItem> _vacancyList;
        private readonly string _fileName;
        private readonly Form _loadingForm;

        public VacancyDocumentPreloader(string fileName, Form loadingForm)
        {
            _fileName = fileName;
            _loadingForm = loadingForm;
        }

        public List<VacancyItem> GetVacancyList()
        {
            return _vacancyList;
        }

        public Form GetLoadingForm()
        {
            return _loadingForm;
        }

        public string GetFileName()
        {
            return _fileName;
        }

        public void DoWork(BackgroundWorker worker, DoWorkEventArgs e)
        {
            _vacancyList = VacancyFileUtil.OpenFile(_fileName);
            e.Result = this;
        }
    }
}
