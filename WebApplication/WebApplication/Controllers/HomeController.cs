﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISample _sample;

        public HomeController(ISample sample)
        {
            _sample = sample;
        }

        public string Index()
        {
            return $"[{nameof(ISample)}]\r\n"
                   + $"Id: {_sample.Id}\r\n"
                   + $"HashCode: {_sample.GetHashCode()}\r\n"
                   + $"Type: {_sample.GetType()}";
        }
    }
}
