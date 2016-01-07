using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DistantVacantGovUz.Enums;
using DistantVacantGovUz.Models;

namespace DistantVacantGovUz.Utils
{
    public class VacancyExporter
    {
        private List<Vacancy> _vacancyList;
        private readonly Form _loadingForm;
        private readonly VacancyStatus _vacStatus;
        private readonly string _fileName;

        private int _totalVacanciesCount;
        private int _exportedVacanciesCount;

        public VacancyExporter(string fileName, Form loadingForm, VacancyStatus vacStatus)
        {
            _fileName = fileName;
            _loadingForm = loadingForm;
            _vacStatus = vacStatus;

            _totalVacanciesCount = 0;
            _exportedVacanciesCount = 0;
        }

        public List<Vacancy> GetVacancyList()
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

        public int GetTotalVacanciesCount()
        {
            return _totalVacanciesCount;
        }

        public int GetExportedVacanciesCount()
        {
            return _exportedVacanciesCount;
        }

        public void DoWork(BackgroundWorker worker, DoWorkEventArgs e)
        {
            List<VacancyListItem> vacList;

            switch (_vacStatus)
            {
                case VacancyStatus.Open:
                    vacList = Program.VacancyApi.GetActualVacancies();
                    break;
                case VacancyStatus.Closed:
                    vacList = Program.VacancyApi.GetClosedVacancies();
                    break;
                default:
                    vacList = null;
                    break;
            }

            if (vacList != null && vacList.Count > 0)
            {
                _totalVacanciesCount = vacList.Count;

                _vacancyList = new List<Vacancy>();

                for (var i = 0; i < vacList.Count; i++)
                {
                    _vacancyList.Add(Program.VacancyApi.GetVacancy(vacList[i].Id));
                    _exportedVacanciesCount++;

                    if (i%2 == 0)
                        worker.ReportProgress((_exportedVacanciesCount * 100 ) / _totalVacanciesCount, this);
                }
            }

            e.Result = this;
        }
    }
}
