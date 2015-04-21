using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace DistantVacantGovUz
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class VacancyApplicationService : IVacancyApplicationService
    {
        private frmMain mainWindow;

        public void SetMainWindow(frmMain window)
        {
            this.mainWindow = window;
        }

        void IVacancyApplicationService.CheckService()
        {
        }

        void IVacancyApplicationService.OpenDocument(string fileName)
        {
            if (mainWindow != null)
            {
                mainWindow.Invoke(mainWindow.openDocDelegate, fileName);
            }
        }
    }
}
