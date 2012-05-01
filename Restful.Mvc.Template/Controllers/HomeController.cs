using System.Web.Mvc;
using Restful.Service.Client;

namespace Restful.Mvc.Template.Controllers
{
    public class HomeController : Controller
    {
        readonly ISessionProvider _provider;

        public HomeController(ISessionProvider provider)
        {
            _provider = provider;
        }

        public ActionResult Welcome()
        {
            return View("Welcome", (object)_provider.GetLoggedInUsername());
        }

        public ActionResult Index()
        {
            if (_provider.IsLoggedIn())
                return RedirectToAction("Welcome");
            return View();
        }
    }
}