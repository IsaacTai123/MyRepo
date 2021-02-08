using CookiesSession.Extensions;
using CookiesSession.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookiesSession.Controllers
{
    public class RedisSessionController : Controller
    {
        private readonly ISessionWrapper _sessionWrapper;
        public RedisSessionController(ISessionWrapper sessionWrapper)
        {
            _sessionWrapper = sessionWrapper;
        }
        
        public ActionResult SetSessionToRedis()
        {
            UserModel userone = new UserModel();
            _sessionWrapper.Session.SetObject("userData", userone);
            return Ok(userone);
        }

        public string GetSessionFromRedis()
        {
            UserModel model = _sessionWrapper.Session.GetObject<UserModel>("userData");
            return $"{model.name}, {model.Age}";
        }
    }
}
