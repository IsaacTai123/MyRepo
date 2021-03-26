using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplicationWithoutHttps.Controllers
{
    public class httpController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public httpController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ActionResult> Test()
        {
            var Client = _httpClient.CreateClient("client");

            var result = await Client.GetAsync("search?sxsrf=ALeKk00qvn_YGgfUzD_cm4Nj1I4YK59JQw%3A1610351956348&source=hp&ei=VAX8X7rzEqySr7wP4ounuAc&q=api&oq=api&gs_lcp=CgZwc3ktYWIQAzIHCCMQyQMQJzIECCMQJzIECCMQJzIECC4QQzIFCAAQkQIyAggAMgcIABAUEIcCMgIILjICCAAyAggAOggILhDHARCjAjoKCC4QxwEQowIQQzoECAAQQ1CsClilDGDHD2gAcAB4AIABzgGIAdUCkgEFMi4wLjGYAQCgAQGqAQdnd3Mtd2l6&sclient=psy-ab&ved=0ahUKEwi67cbCtJPuAhUsyYsBHeLFCXcQ4dUDCAY&uact=5");

            return Ok(result);
        }

        public async Task<IActionResult> Index()
        {
            var webclient = new WebClient();
            webclient.Headers.Add("user-agent", "pratice");

            var content = await webclient.DownloadStringTaskAsync("https://www.google.com/");


            // passing data from the controller to view -- https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-view?view=aspnetcore-5.0&tabs=visual-studio
            ViewData["content"] = content;
            return View();
        }

    }
}
