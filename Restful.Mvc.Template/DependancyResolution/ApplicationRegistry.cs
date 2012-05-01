using System.Configuration;
using Example.Service.Client;
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
            // Use a session provider based on cookies
            For<ISessionProvider>().Use<CookieBasedSessionProvider>();
            
            // Use a web client that knows how to pull out the session cookie and send it to all wire requests to the service
            // (not that this example uses a service over the wire)
            For<IWebClient>().Use(
                new JsonWebClient(ConfigurationManager.AppSettings["Example.Service.BaseUrl"], 
                    new SessionKeyHeaderAppender(new CookieBasedSessionProvider())));

            // register all our MVC clients
            Restful.Service.Client.Mvc.Bootstrap.RegisterClients(new[] { typeof(IUserClient).Assembly }, AddType);

            // register all our service clients
            Restful.Service.Client.Bootstrap.RegisterClients(new[] { typeof(IUserServiceClient).Assembly }, AddType);
        }
    }
}