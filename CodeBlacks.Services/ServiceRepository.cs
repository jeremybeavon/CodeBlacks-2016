using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlacks.Services
{
    public static class ServiceRepository
    {
        public static Func<ICharityService> CharityServiceFactory { get; set; }
    }
}
