using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellingSystem.Controllers
{
    public class httpGetControllers : Controller
    {
        // 如果不用route[] 那麼這一個controller裡面就只能有一個method, 如果你把logcontroller or memberController 裡面的route拿掉 那就會無法build
        [HttpGet("{name}/{number}/{date}")]
        public string onlyOneMethodInThisController(string name, int number, string date)
        {
            return $"my name is {name}, {number} years old, born in {date}";
        }
    }
}
