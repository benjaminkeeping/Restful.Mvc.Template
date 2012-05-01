using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Example.Service.Wiretypes;
using Restful.Service.Client.Mvc;
using Restful.Wiretypes;

namespace Example.Service.Client.Mvc
{
    public interface IUserClient : IClient
    {
        IEnumerable<GroupOf<Link>> GetUserMenu();
        ActionResult SignIn(CreateSessionDetails details, Func<SessionDetails, ActionResult> onSuccess, Func<IEnumerable<Error>, ActionResult> onError);
    }
}
