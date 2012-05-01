using System.Collections.Generic;
using System.Web.Mvc;
using Mvc.Extensions;
using Mvc.Routing;
using Restful.Wiretypes;

namespace Restful.Mvc.Template.Controllers
{
    public class ErrorController : Controller
    {
        [Get("sorry")]
        public ActionResult Sorry()
        {
            return View(TempData["Message"]);
        }

        protected ActionResult HandleError(string error)
        {
            TempData["Message"] = error;
            return RedirectToAction("Sorry", "Error");
        }

        protected ActionResult HandleError(IEnumerable<Error> errors)
        {
            ModelState.AddErrors(errors);

            foreach (var error in errors)
            {
                TempData["Message"] += error.Value + "<br/>";
            }
            return RedirectToAction("Sorry", "Error");
        }

        protected ActionResult RenderRawError(string error)
        {
            return Content(string.Format("<span class=\"label label-important\">Sorry!</span><span> {0}</span>", error));
        }
    }
}