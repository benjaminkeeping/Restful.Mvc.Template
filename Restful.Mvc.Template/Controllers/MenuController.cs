using System.Web.Mvc;
using Example.Service.Client.Mvc;
using Mvc.Extensions;
using Restful.Service.Client;

namespace Restful.Mvc.Template.Controllers
{
    public class MenuController : ErrorController
    {
        readonly IUserClient _client;

        public MenuController(IUserClient client)
        {
            _client = client;
        }

        public ActionResult Index()
        {
            return PartialView(_client.GetUserMenu()).WithNoCache();
        }
    }
}