using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Middleware.Controllers
{
    [Route("[controller]/[action]")]
    public class MainController : Controller
    {
        [Route("~/")]
        [Route("~")]
        public async Task Test()
        {
           await Response.WriteAsync("Action in \r\n");
           //return "action in";
        }
    }
}
