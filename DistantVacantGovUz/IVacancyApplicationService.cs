using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace DistantVacantGovUz
{
    [ServiceContract]
    public interface IVacancyApplicationService
    {
        [OperationContract]
        void OpenDocument(String fileName);

        [OperationContract]
        void CheckService();
    }
}
