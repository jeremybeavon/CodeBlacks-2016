using CodeBlacks.Services;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Threading.Tasks;
using System.Web.Http;

namespace CodeBlacks.FrontEnd
{
    [RoutePrefix("api")]
    public class CharitiesController : ApiController
    {
        [HttpGet]
        [Route("charity/{country}")]
        public Task<List<Charity>> Get(string country)
        {
            return ServiceRepository.CharityServiceFactory().GetCharities(country);
        }

        [HttpGet]
        [Route("charity/{country}")]
        public Task<List<DonationImpact>> Get(string country, string charity, decimal amount)
        {
            return ServiceRepository.CharityServiceFactory().GetDonationImpact(country, charity, amount);
        }
    }
}
