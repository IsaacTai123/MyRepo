using Microsoft.AspNetCore.Http;

namespace CookiesSession.Wrappers
{
    public interface ISessionWrapper
    {
        ISession Session { get; }
        UserModel User { get; set; }
    }
}