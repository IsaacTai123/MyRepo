using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CookiesSession.Wrappers;
using CookiesSession.Extensions;
using Newtonsoft.Json;

namespace CookiesSession.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISessionWrapper _sessionWrapper;
        public HomeController(ISessionWrapper sessionWrapper)
        {
            _sessionWrapper = sessionWrapper;
        }

        public IActionResult Index()
        {
            //var user = _sessionWrapper.User;
            //_sessionWrapper.User = user;
            //return Ok(user); // 回傳 200 ok (意思是HTTP狀態程式碼)

            UserModel user = new UserModel();
            _sessionWrapper.Session.SetObject("two", user);
            return Ok(user);
        }
    }


    // https://blog.clifflu.net/2010/04/%E9%9A%A8%E7%AD%86%EF%BC%9A%E5%9C%A8-visual-studio-%E4%B8%AD%EF%BC%8C%E4%BD%BF%E7%94%A8-serializable-%E5%84%B2%E5%AD%98%E7%89%A9%E4%BB%B6/
    // 查看上面這個URL 來看為什麼要用 [Serializable]
    [Serializable]
    public class UserModel
    {
        public string name { get; set; } = "john";
        public int Age { get; set; } = 5;
    }
}
