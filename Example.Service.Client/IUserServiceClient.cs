using System.Collections.Generic;
using Example.Service.Wiretypes;
using Restful.Service.Client;
using Restful.Wiretypes;

namespace Example.Service.Client
{
    public interface IUserServiceClient : IServiceClient
    {
        IEnumerable<GroupOf<Link>> GetUserMenu();
        SessionDetails SignIn(CreateSessionDetails details);
        UserDetails GetUserById(long id);
    }
}