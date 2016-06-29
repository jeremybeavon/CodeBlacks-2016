using CodeBlacks.BackEnd.Services;
using CodeBlacks.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace CodeBlacks.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ServiceRepository.CharityServiceFactory = () => new CharityServiceImplementation();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
