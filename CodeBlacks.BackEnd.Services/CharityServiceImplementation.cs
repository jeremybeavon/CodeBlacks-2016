using CodeBlacks.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeBlacks.BackEnd.Services
{
    public sealed class CharityServiceImplementation : ICharityService
    {
        public Task<List<Charity>> GetCharities(string country)
        {
            return Task.FromResult(Impact.GetCharitiesInCountry(country));
        }

        public Task<List<DonationImpact>> GetDonationImpact(string country, string charity, decimal amount)
        {
            return Task.FromResult(Impact.GetDonationImpact(country, charity, (double)amount));
        }
    }
}
