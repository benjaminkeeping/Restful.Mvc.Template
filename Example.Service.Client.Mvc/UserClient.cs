using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Example.Service.Wiretypes;
using Restful.Service.Client;
using Restful.Service.Client.Mvc;
using Restful.Web.Client.Errors;
using Restful.Wiretypes;

namespace Example.Service.Client.Mvc
{
    public class UserClient : BaseClient, IUserClient
    {
        public UserClient(ISessionProvider sessionProvider) : base(sessionProvider)
        {
        }

        public IEnumerable<GroupOf<Link>> GetUserMenu()
        {
            return new List<GroupOf<Link>> {new GroupOf<Link> { GroupName = "Example Group 1", Items = new List<Link> {Link.From("Link 1", "")}}};
        }

        public ActionResult SignIn(CreateSessionDetails details, Func<SessionDetails, ActionResult> onSuccess, Func<IEnumerable<Error>, ActionResult> onError)
        {
            return Try(() =>
            {
                var errors = new List<Error>();
                if (string.IsNullOrWhiteSpace(details.Email))
                {
                    errors.Add(new Error { Key = "Email", Value = "The 'Email' field is required" });
                }
                if (string.IsNullOrWhiteSpace(details.Password))
                {
                    errors.Add(new Error { Key = "Password", Value = "The 'Password' field is required" });
                }

                if (errors.Count > 0)
                {
                    throw new Http400(errors);
                }

                return onSuccess.Invoke(new SessionDetails
                {
                    UserId = DateTime.Now.Ticks.ToString(),
                    SessionKey = new Guid().ToString(),
                    UserName = "Dave Coaches " +DateTime.Now.Ticks,
                });

            }, onError);
        }
    }
}