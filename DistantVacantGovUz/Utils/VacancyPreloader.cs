using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DistantVacantGovUz.Enums;
using DistantVacantGovUz.Models;

namespace DistantVacantGovUz.Utils
{
    public class VacancyPreloader
    {
        private List<VacancyListItem> _vacancyList;
        private readonly Form _loadingForm;
        private readonly VacancyStatus _vacStatus;

        public VacancyPreloader(Form loadingForm, VacancyStatus vacStatus)
        {
            _loadingForm = loadingForm;
            _vacStatus = vacStatus;
        }

        public List<VacancyListItem> GetVacancyList()
        {
            return _vacancyList;
        }

        public Form GetLoadingForm()
        {
            return _loadingForm;
        }

        public void DoWork(BackgroundWorker worker, DoWorkEventArgs e)
        {
            switch (_vacStatus)
            {
                case VacancyStatus.Open:
                    _vacancyList = Program.VacancyApi.GetActualVacancies();
                    break;
                case VacancyStatus.Closed:
                    _vacancyList = Program.VacancyApi.GetClosedVacancies();
                    break;
                default:
                    _vacancyList = null;
                    break;
            }
            
            e.Result = this;
        }
    }
}
