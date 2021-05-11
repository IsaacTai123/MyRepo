using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        // The standard way of capturing the category
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }


        //private readonly ILogger _logger;

        //// custom category name by doing this
        //public IndexModel(ILoggerFactory factory)
        //{
        //    _logger = factory.CreateLogger("CustomTheCategoryName");
        //}

        public void OnGet()
        {
            //The Logging Levels
            _logger.LogTrace("This is a trace log"); // a log that will have a really detailed view in what's going on.
            _logger.LogDebug("This is a debug log"); // next level up from trace but it's still pritty heavy debugging information
            _logger.LogInformation(LoggingId.DemoCode, "This is our first logged meddage"); // this is more flow of how your applications are being used, from this step to this step to this step .....
            _logger.LogWarning("This is a warning log");
            _logger.LogError("This is an error log");
            _logger.LogCritical("This is a critical log");


            // Advanced logging message
            //_logger.LogError("The server went down temporarily at {Time}", DateTime.UtcNow); // you can actually filter based upon the tim when the log was entered because you have this time as a seperate variable

            //try
            //{
            //    throw new Exception("you forgot to pick me up");
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogCritical(ex, "There was a bad exception at {time}", DateTime.UtcNow);
            //}
        }
    }

    // create a log ID on top
    public class LoggingId
    {
        public const int DemoCode = 1001;
    }
}
