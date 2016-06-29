using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlacks.Services
{
    public interface ICharityService : IService
    {
        Task<List<Charity>> GetCharities(string country);

        Task<List<DonationImpact>> GetDonationImpact(string country, string charity, decimal amount);
    }
}
