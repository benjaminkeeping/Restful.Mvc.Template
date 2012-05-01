using System.Web.Mvc;
using Example.Service.Client.Mvc;
using Example.Service.Wiretypes;
using Mvc.Extensions;
using Mvc.Routing;
using Restful.Service.Client;

namespace Restful.Mvc.Template.Controllers
{
    public class SessionsController : ErrorController
    {
        readonly IUserClient _client;
        readonly ISessionProvider _sessionProvider;

        public SessionsController(IUserClient client, ISessionProvider sessionProvider)
        {
            _client = client;
            _sessionProvider = sessionProvider;
        }

        [Get("sign-in")]
        public ActionResult SignIn()
        {
            if (_sessionProvider.IsLoggedIn())
                return RedirectToAction("Index", "Users", new { id = _sessionProvider.GetLoggedInUserId() });
 
            return View(new CreateSessionDetails());
        }

        [HttpPost]
        public ActionResult SignIn(CreateSessionDetails details)
        {
            return _client.SignIn(details,
                                  session =>
                                      Redirect("~")
                                      .WithSessionInitialised(_sessionProvider, session),
                                  errors =>
                                      View(details).WithModelErrors(ModelState, errors)
                );
        }

        [Get("sign-out")]
        public ActionResult Signout()
        {
            _sessionProvider.ClearSession();
            return Redirect("~");
        }

        public ActionResult Status()
        {
            if (_sessionProvider.IsLoggedIn())
            {
                return PartialView((object)_sessionProvider.GetLoggedInUsername());
            }
            return Content("");
        }
    }
}