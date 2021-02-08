using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WhitelistAppMiddleware.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {


        //[TypeFilter(typeof(ClientIdCheckFilter))]
        //[ServiceFilter(typeof(ClientIdCheckFilter))]
        [ClientIdCheckFilter]
        public string Index()
        {
            return "You have done using ActionFilter!!";
        }
    }
}
