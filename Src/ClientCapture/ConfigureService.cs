using ClientCapture.Business;
using Topshelf;

namespace ClientCapture
{
    public class ConfigureService
    {
        internal static void Configure()
        {
            HostFactory.Run(configure =>
            {
                configure.Service<ClientService>(service =>
                {
                    service.ConstructUsing(s => new ClientService());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });

                configure.RunAsLocalSystem();
                configure.SetServiceName("ClientCapture");
                configure.SetDisplayName("ClientCapture");
                configure.SetDescription("Client Capture Service");
            });
        }
    }
}
