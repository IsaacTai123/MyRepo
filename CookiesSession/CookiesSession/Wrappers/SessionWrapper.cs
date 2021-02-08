using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookiesSession.Extensions;
using Microsoft.AspNetCore.Http;

//由於 Cookies 及 Session 預設都是使用字串的方式存取資料，弱型別無法在開發階段判斷有沒有打錯字，還是建議包裝成強強型比較好。
//而且直接存取 Cookies/Session 的話邏輯相依性太強，對單元測試很不友善，所以還是建議包裝一下。

namespace CookiesSession.Wrappers
{
    public class SessionWrapper : ISessionWrapper
    {
        private static readonly string _uerKey = "session.user";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionWrapper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ISession Session
        {
            get
            {
                return _httpContextAccessor.HttpContext.Session;
            }
        }

        public UserModel User
        {
            get
            {
                return Session.GetObject<UserModel>(_uerKey);
                //return _httpContextAccessor.HttpContext.Session.GetObject<UserModel>(_uerKey);
            }
            set
            {
                Session.SetObject(_uerKey, value);
            }
        }
    }
}
