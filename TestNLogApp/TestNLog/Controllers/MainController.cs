using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestNLog.Controllers
{
    public class MainController : Controller
    {
        // Nlog
        //private static Logger logger = LogManager.GetLogger("ruleOne");

        private readonly ILogger<MainController> _logger;

        public MainController(ILogger<MainController> logger)
        {
            _logger = logger;
        }

        public void Index()
        {
            _logger.LogInformation("this is information frfom maincontroller");
            //logger.Info("This is Nlog info");
        }
    }
}
