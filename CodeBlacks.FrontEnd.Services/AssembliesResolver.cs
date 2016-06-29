using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dispatcher;

namespace CodeBlacks.FrontEnd.Services
{
    public sealed class AssembliesResolver : IAssembliesResolver
    {
        public ICollection<Assembly> GetAssemblies()
        {
            return new[] { Assembly.GetExecutingAssembly() };
        }
    }
}
