using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationWithoutHttps.Controllers
{
    public class SampleController : Controller
    {
        private readonly SampleClient _sampleclient;

        public SampleController(SampleClient sampleclient)
        {
            _sampleclient = sampleclient;
        }

        [HttpGet]
        public async Task<ActionResult> GetResponse()
        {
            var result = await _sampleclient.client.GetStringAsync("https://www.itread01.com/content/1564990083.html");
            return Ok(result);
        }
    }
}
