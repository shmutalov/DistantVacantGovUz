using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace DistantVacantGovUz
{
    public class CVacancyPortalPreloader
    {
        private List<CVacancyListElement> vacancyList;
        private Form loadingForm;
        private VACANCY_STATUS vacStatus;

        public CVacancyPortalPreloader(Form loadingForm, VACANCY_STATUS vacStatus)
        {
            this.loadingForm = loadingForm;
            this.vacStatus = vacStatus;
        }

        public List<CVacancyListElement> GetVacancyList()
        {
            return vacancyList;
        }

        public Form GetLoadingForm()
        {
            return loadingForm;
        }

        public void DoWork(BackgroundWorker worker, DoWorkEventArgs e)
        {
            switch (vacStatus)
            {
                case VACANCY_STATUS.OPEN:
                    vacancyList = Program.vac.GetActualVacancies();
                    break;
                case VACANCY_STATUS.CLOSED:
                    vacancyList = Program.vac.GetClosedVacancies();
                    break;
                default:
                    vacancyList = null;
                    break;
            }
            
            e.Result = this;

            //worker.ReportProgress(100);
        }
    }
}
