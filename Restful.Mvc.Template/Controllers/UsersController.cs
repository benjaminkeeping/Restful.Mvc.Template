using System.Web.Mvc;
using Example.Service.Client.Mvc;
using Mvc.Extensions;
using Mvc.Routing;

namespace Restful.Mvc.Template.Controllers
{
    public class UsersController : ErrorController
    {
        readonly IUserClient _userClient;

        public UsersController(IUserClient userClient)
        {
            _userClient = userClient;
        }

        public ActionResult Menu()
        {
            return _userClient.GetUserMenu(menu => PartialView(menu).WithNoCache(), HandleError);
        }

        [Get("users/{id}")]
        public ActionResult Index(long id)
        {
            return _userClient.GetUserById(id, View, HandleError);
        }
    }
}