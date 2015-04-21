using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace DistantVacantGovUz
{
    public static class VacancySingleApplicationService
    {
        private static ServiceHost host;

        public static void StartService(IVacancyApplicationService instance, string channelUri, frmMain mainWindow)
        {
            host = new ServiceHost(instance, new Uri(channelUri));

            try
            {
                host.AddServiceEndpoint(typeof(IVacancyApplicationService), new NetNamedPipeBinding(), new Uri(channelUri));
                host.Open();
                (instance as VacancyApplicationService).SetMainWindow(mainWindow);
            }
            catch (CommunicationException ex)
            {
                host.Abort();
            }
        }

        public static bool IsServiceAlreadyStarted(string channelUri)
        {
            ChannelFactory<IVacancyApplicationService> factory =
                new ChannelFactory<IVacancyApplicationService>
                (new NetNamedPipeBinding(), new EndpointAddress(channelUri));

            IVacancyApplicationService proxy = factory.CreateChannel();

            try
            {
                if (host != null && host.State == CommunicationState.Opened)
                {
                    (factory as IContextChannel).OperationTimeout = new TimeSpan(1000);
                }

                proxy.CheckService();
                return true;
            }
            catch (EndpointNotFoundException e)
            {
                return false;
            }
        }

        public static bool IsServiceAlreadyStartedOpenDocument(string channelUri, string fileName)
        {
            ChannelFactory<IVacancyApplicationService> factory =
                new ChannelFactory<IVacancyApplicationService>
                (new NetNamedPipeBinding(), new EndpointAddress(channelUri));

            IVacancyApplicationService proxy = factory.CreateChannel();

            try
            {
                if (host != null && host.State == CommunicationState.Opened)
                {
                    (factory as IContextChannel).OperationTimeout = new TimeSpan(1000);
                }

                proxy.OpenDocument(fileName);
                return true;
            }
            catch (EndpointNotFoundException e)
            {
                return false;
            }
        }
    }
}
