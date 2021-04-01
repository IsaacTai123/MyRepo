using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationWithoutHttps.Controllers
{
    public class redirectController : Controller
    {
        public IActionResult Index()
        {
            // **** Redirect() method ****
            //return Redirect("~/http/Index");


            // **** RedirectPermanent() method *****
            //return RedirectPermanent("~/http/Index");

            // ***** RedirectPreserveMethod() method *****
            return RedirectPreserveMethod("~/redirect/Privacy");

            //Response.Redirect("http://www.google.com");
            
        }

        public IActionResult Privacy()
        {
            return View("~/Views/redirect/Index.cshtml");
            //return View();
        }

    }
}
