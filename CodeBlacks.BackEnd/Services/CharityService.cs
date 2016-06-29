using CodeBlacks.Services;
using Microsoft.ServiceFabric.Services.Runtime;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Fabric;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;

namespace CodeBlacks.BackEnd.Services
{
    public sealed class CharityService : StatelessService, ICharityService
    {
        private readonly ICharityService service;

        public CharityService(StatelessServiceContext serviceContext) : base(serviceContext)
        {
            service = new CharityServiceImplementation();
        }

        public Task<List<Charity>> GetCharities(string country)
        {
            return service.GetCharities(country);
        }

        public Task<List<DonationImpact>> GetDonationImpact(string country, string charity, decimal amount)
        {
            return service.GetDonationImpact(country, charity, amount);
        }

        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new[] { new ServiceInstanceListener(context => this.CreateServiceRemotingListener(context)) };
        }
    }
}
