using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using SellingSystem.Models.Services;
//using NLog;
using Microsoft.Extensions.Logging;
//using ILogger = Microsoft.Extensions.Logging.ILogger;



namespace SellingSystem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LogController : Controller
    {

        public static Dictionary<string, Object> fullHttpContext = new Dictionary<string, Object>();
        private readonly ILogger _logger;

        public LogController(ILoggerFactory factory)
        {
            _logger = factory.CreateLogger("BuildExceptionMessage");
        }
        
        [HttpGet]
        public string GetHttpContext()
        {
            //string sechema = Request.Scheme + "://" + Request.Path + Request.QueryString;
            //string url = 
            
            fullHttpContext.Add("Scheme", Request.Scheme);
            fullHttpContext.Add("Path", Request.Path);
            fullHttpContext.Add("Host", Request.Host);
            fullHttpContext.Add("HostValue", Request.Host.Value);
            fullHttpContext.Add("Headers", Request.Headers);
            fullHttpContext.Add("pathBase", Request.PathBase);
            fullHttpContext.Add("QueryString", Request.QueryString);
            fullHttpContext.Add("Query", Request.Query);
            fullHttpContext.Add("contentType", Request.ContentType);

            string items = "";
            foreach (var item in fullHttpContext)
            {
                items += $" {item.Key} -> {item.Value} \n";
            }

            Logging();

            return items;
        }
        private static IHttpContextAccessor HttpContextAccessor;
        public static void configure(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public string AbsoluteUri()
        {
            IUrlHelper template = null;
            template.AbsoluteAction("AbsoluteUri", "LogController");
            return template.ToString();
        }

        public void Logging()
        {
            try
            {
                int a = 6;
                int b = 0;
                int result = a / b;
            }
            catch (Exception x)
            {
                _logger.LogInformation(LogUtility.BuildExceptionMessage(x, fullHttpContext));
            }
            
        }

        
    }
}
