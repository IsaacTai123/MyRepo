using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionHandler.Controllers
{
    public class HomeController : Controller
    {
        public void Index()
        {
            throw new Exception("this is Exception sample from Index");
        }

        [Route("/api/test")]
        public string Test()
        {
            throw new Exception("This is exception sample from Test() ");
        }

        [Route("/error")]
        public IActionResult Error()
        {
            return View();
        }
    }
}
