using System;
using System.ServiceModel;
using DistantVacantGovUz.Windows;

namespace DistantVacantGovUz.Services
{
    public static class VacancySingleApplicationService
    {
        private static ServiceHost _host;

        public static void StartService(IVacancyApplicationService instance, string channelUri, MainWindow mainWindow)
        {
            _host = new ServiceHost(instance, new Uri(channelUri));

            try
            {
                _host.AddServiceEndpoint(typeof(IVacancyApplicationService), new NetNamedPipeBinding(), new Uri(channelUri));
                _host.Open();

                (instance as VacancyApplicationService)?.SetMainWindow(mainWindow);
            }
            catch (CommunicationException)
            {
                _host.Abort();
            }
        }

        public static bool IsServiceAlreadyStarted(string channelUri)
        {
            var factory =
                new ChannelFactory<IVacancyApplicationService>
                (new NetNamedPipeBinding(), new EndpointAddress(channelUri));

            var proxy = factory.CreateChannel();

            try
            {
                if (_host != null && _host.State == CommunicationState.Opened)
                {
                    var contextChannel = factory as IContextChannel;

                    if (contextChannel != null)
                        contextChannel.OperationTimeout = new TimeSpan(1000);
                }

                proxy.CheckService();
                return true;
            }
            catch (EndpointNotFoundException)
            {
                return false;
            }
        }

        public static bool IsServiceAlreadyStartedOpenDocument(string channelUri, string fileName)
        {
            var factory =
                new ChannelFactory<IVacancyApplicationService>
                (new NetNamedPipeBinding(), new EndpointAddress(channelUri));

            var proxy = factory.CreateChannel();

            try
            {
                if (_host != null && _host.State == CommunicationState.Opened)
                {
                    var contextChannel = factory as IContextChannel;

                    if (contextChannel != null)
                        contextChannel.OperationTimeout = new TimeSpan(1000);
                }

                proxy.OpenDocument(fileName);
                return true;
            }
            catch (EndpointNotFoundException)
            {
                return false;
            }
        }
    }
}
