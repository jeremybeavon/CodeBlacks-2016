using System;
using System.Diagnostics;
using System.Fabric;
using System.Threading;
using System.Threading.Tasks;
using CodeBlacks.Services;
using Microsoft.ServiceFabric.Services.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Client;

namespace CodeBlacks.FrontEnd
{
    internal static class Program
    {
        private static Lazy<Uri> backendUrl;

        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        private static void Main()
        {
            backendUrl = new Lazy<Uri>(() => new Uri(FabricRuntime.GetActivationContext().ApplicationName + "/CharityService"));
            ServiceRepository.CharityServiceFactory = () => ServiceProxy.Create<ICharityService>(backendUrl.Value);

            try
            {
                // The ServiceManifest.XML file defines one or more service type names.
                // Registering a service maps a service type name to a .NET type.
                // When Service Fabric creates an instance of this service type,
                // an instance of the class is created in this host process.

                ServiceRuntime.RegisterServiceAsync("FrontEndType",
                    context => new FrontEnd(context)).GetAwaiter().GetResult();

                ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(FrontEnd).Name);

                // Prevents this host process from terminating so services keeps running. 
                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception e)
            {
                ServiceEventSource.Current.ServiceHostInitializationFailed(e.ToString());
                throw;
            }
        }
    }
}
