using System;
using System.Collections.Generic;
using Example.Service.Wiretypes;
using Restful.Service.Client;
using Restful.Web.Client.Client;
using Restful.Web.Client.Errors;
using Restful.Wiretypes;

namespace Example.Service.Client
{
    public class UserServiceClient : IUserServiceClient
    {
        readonly ISessionProvider _sessionProvider;
        readonly IWebClient _webClient;

        public UserServiceClient(ISessionProvider sessionProvider, IWebClient webClient)
        {
            _sessionProvider = sessionProvider;
            _webClient = webClient;
        }


        public UserDetails GetUserById(long id)
        {
            // So normally, if you had a restful service listening, then you would do something like this :
            //return _webClient.Get<UserDetails>(string.Format("users/{0}", id));

            // But for this example, we'll fake some validation, and response
            return new UserDetails { UserId = id };
        }

        public IEnumerable<GroupOf<Link>> GetUserMenu()
        {
            // So normally, if you had a restful service listening, then you would do something like this :
            //return _webClient.Get<IEnumerable<GroupOf<Link>>>("menus");

            // But for this example, we'll fake some validation, and response
            return !_sessionProvider.IsLoggedIn() ? new List<GroupOf<Link>>() :

            new List<GroupOf<Link>>
            {
                new GroupOf<Link> { 
                    GroupName = string.Format("Menu 1 for {0}",_sessionProvider.GetLoggedInUsername()), 
                    Items = new List<Link>
                    {
                        Link.From("Link 1.1", ""),
                        Link.From("Link 1.2", ""),
                        Link.From("Link 1.3", "")
                    }},
                new GroupOf<Link> { 
                    GroupName = string.Format("Menu 2 for {0}",_sessionProvider.GetLoggedInUsername()), 
                    Items = new List<Link>
                    {
                        Link.From("Link 2.1", ""),
                        Link.From("Link 2.2", ""),
                        Link.From("Link 2.3", "")
                    }
                }
            };
        }

        public SessionDetails SignIn(CreateSessionDetails details)
        {
            // So normally, if you had a restful service listening, then you would do something like this :
            //return _webClient.PostWithResponse<CreateSessionDetails, SessionDetails>("sessions", details);

            // But for this example, we'll fake some validation, and response
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

            return new SessionDetails
            {
                UserId = DateTime.Now.Ticks.ToString(),
                SessionKey = new Guid().ToString(),
                UserName = details.Email,
            };
        }

    }
}
