using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace DistantVacantGovUz
{
    public class CVacancyPortalExporter
    {
        private List<CVacancy> vacancyList = null;
        private Form loadingForm;
        private VACANCY_STATUS vacStatus;
        private string fileName;

        private int totalVacanciesCount;
        private int exportedVacanciesCount;

        public CVacancyPortalExporter(string fileName, Form loadingForm, VACANCY_STATUS vacStatus)
        {
            this.fileName = fileName;
            this.loadingForm = loadingForm;
            this.vacStatus = vacStatus;

            totalVacanciesCount = 0;
            exportedVacanciesCount = 0;
        }

        public List<CVacancy> GetVacancyList()
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

        public int GetTotalVacanciesCount()
        {
            return totalVacanciesCount;
        }

        public int GetExportedVacanciesCount()
        {
            return exportedVacanciesCount;
        }

        public void DoWork(BackgroundWorker worker, DoWorkEventArgs e)
        {
            List<CVacancyListElement> vacList = null;

            switch (vacStatus)
            {
                case VACANCY_STATUS.OPEN:
                    vacList = Program.vac.GetActualVacancies();
                    break;
                case VACANCY_STATUS.CLOSED:
                    vacList = Program.vac.GetClosedVacancies();
                    break;
                default:
                    vacList = null;
                    break;
            }

            if (vacList != null && vacList.Count > 0)
            {
                totalVacanciesCount = vacList.Count;

                vacancyList = new List<CVacancy>();

                for (int i = 0; i < vacList.Count; i++)
                {
                    vacancyList.Add(Program.vac.GetVacancy(vacList[i].iID));
                    exportedVacanciesCount++;

                    if (i%2 == 0)
                        worker.ReportProgress((exportedVacanciesCount * 100 ) / totalVacanciesCount, this);
                }
            }

            e.Result = this;
        }
    }
}
