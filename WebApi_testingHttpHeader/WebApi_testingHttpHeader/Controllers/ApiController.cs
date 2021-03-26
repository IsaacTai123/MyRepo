using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_testingHttpHeader.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
       public string output()
       {
            string str = "";
            foreach (var item in HttpContext.Request.Headers)
            {
                str += $"{item.Key} => {item.Value} \r";
            }
            return str;
       }
    }
}
