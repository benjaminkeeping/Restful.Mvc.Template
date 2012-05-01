using System.Configuration;
using Example.Service.Client.Mvc;
using Restful.Service.Client;
using Restful.Web.Client.Client;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Restful.Mvc.Template.DependancyResolution
{
    public class ApplicationRegistry : Registry
    {
        public ApplicationRegistry()
        {
            For<ISessionProvider>().Use<CookieBasedSessionProvider>();
            For<IWebClient>().Use(new JsonWebClient(ConfigurationManager.AppSettings["Example.Service.BaseUrl"], new SessionKeyHeaderAppender(new CookieBasedSessionProvider())));
            Restful.Service.Client.Mvc.Bootstrap.RegisterClients(new[] { typeof(IUserClient).Assembly }, AddType);
//            Restful.Service.Client.Bootstrap.RegisterClients(new[] { typeof(IUserServiceClient).Assembly }, AddType);
        }
    }
}