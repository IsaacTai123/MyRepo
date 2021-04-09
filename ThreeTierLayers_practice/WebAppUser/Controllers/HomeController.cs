using BusinessLogic;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppUser.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserBO userBO)
        {
            UserBL userBL = new UserBL();
            CustomBO custom = userBL.AddUser(userBO);


            return View();
        }
    }
}
