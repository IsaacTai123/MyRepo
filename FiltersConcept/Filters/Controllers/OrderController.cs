using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Controllers
{
    [ActionFilter (Name = "Controller", Order = 2)]
    public class OrderController : Controller
    {
        [ActionFilter (Name = "Action", Order = 1)]
        public void Index()
        {
            Response.WriteAsync("Hello World");
        }
    }
}
