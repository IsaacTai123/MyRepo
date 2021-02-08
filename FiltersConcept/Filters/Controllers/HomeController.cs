using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Controllers
{
    [AuthorizationFilter]
    public class HomeController : Controller
    {
        [ActionFilter]
        public void Index()
        {
            Response.WriteAsync("Hello world! \r\n");
        }  

        [ActionFilter]
        public void Error()
        {
            throw new Exception("Error");
        }
    }
}
