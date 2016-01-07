using System.ServiceModel;
using DistantVacantGovUz.Windows;

namespace DistantVacantGovUz.Services
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class VacancyApplicationService : IVacancyApplicationService
    {
        private MainWindow _mainWindow;

        public void SetMainWindow(MainWindow window)
        {
            _mainWindow = window;
        }

        void IVacancyApplicationService.CheckService()
        {
        }

        void IVacancyApplicationService.OpenDocument(string fileName)
        {
            if (_mainWindow != null)
            {
                _mainWindow.Invoke(_mainWindow.OpenDocDelegate, fileName);
            }
        }
    }
}
