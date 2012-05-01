using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Example.Service.Wiretypes;
using Restful.Service.Client;

namespace Restful.Mvc.Template
{
    public static class MvcExtensions
    {
        public static ActionResult WithSessionInitialised(this ActionResult result, ISessionProvider sessionProvider,
                                                          SessionDetails session)
        {
            sessionProvider.InitialiseSessionWith(session);
            return result;
        }
    }

}