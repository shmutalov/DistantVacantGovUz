using System.ServiceModel;

namespace DistantVacantGovUz.Services
{
    [ServiceContract]
    public interface IVacancyApplicationService
    {
        [OperationContract]
        void OpenDocument(string fileName);

        [OperationContract]
        void CheckService();
    }
}
