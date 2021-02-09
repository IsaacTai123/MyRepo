using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhiteListMiddlewareActionFilter.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        //[TypeFilter(typeof(ClientIdCheckFilter))]
        [ServiceFilter(typeof(ClientIdCheckFilter))]
        //[ClientIdCheckFilter] //不能這樣做 因為在clientIdCheckFilter 的constructor裡面有放參數 
        public string Index()
        {
            return "You have done using ActionFilter!!";
        }
    }
}
