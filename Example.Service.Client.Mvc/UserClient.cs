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
        readonly IUserServiceClient _userServiceClient;

        public UserClient(ISessionProvider sessionProvider, IUserServiceClient userServiceClient) : base(sessionProvider)
        {
            _userServiceClient = userServiceClient;
        }

        public ActionResult GetUserMenu(Func<IEnumerable<GroupOf<Link>>, ActionResult> onSuccess, Func<IEnumerable<Error>, ActionResult> onError)
        {
            return Try(() => onSuccess.Invoke(_userServiceClient.GetUserMenu()), onError);
        }

        public ActionResult SignIn(CreateSessionDetails details, Func<SessionDetails, ActionResult> onSuccess, Func<IEnumerable<Error>, ActionResult> onError)
        {
            return Try(() => onSuccess.Invoke(_userServiceClient.SignIn(details)), onError);
        }

        public ActionResult GetUserById(long id, Func<UserDetails, ActionResult> onSuccess, Func<IEnumerable<Error>, ActionResult> onError)
        {
            return Try(() => onSuccess.Invoke(_userServiceClient.GetUserById(id)), onError);
        }
    }
}