using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace logger.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public string Index()
        {
            _logger.LogTrace("This trace log from Home.Index()");
            _logger.LogDebug("This debug log from Home.Index()");
            _logger.LogInformation("This information log from Home.Index()");
            _logger.LogWarning("This warning log from Home.Index()");
            _logger.LogError("This error log from Home.Index()");
            _logger.LogCritical("This critical log from Home.Index()");
            return "Home.Index()";
        }
    }
}
