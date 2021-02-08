using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var result = await Client.GetStringAsync("search?sxsrf=ALeKk00qvn_YGgfUzD_cm4Nj1I4YK59JQw%3A1610351956348&source=hp&ei=VAX8X7rzEqySr7wP4ounuAc&q=api&oq=api&gs_lcp=CgZwc3ktYWIQAzIHCCMQyQMQJzIECCMQJzIECCMQJzIECC4QQzIFCAAQkQIyAggAMgcIABAUEIcCMgIILjICCAAyAggAOggILhDHARCjAjoKCC4QxwEQowIQQzoECAAQQ1CsClilDGDHD2gAcAB4AIABzgGIAdUCkgEFMi4wLjGYAQCgAQGqAQdnd3Mtd2l6&sclient=psy-ab&ved=0ahUKEwi67cbCtJPuAhUsyYsBHeLFCXcQ4dUDCAY&uact=5");

            return null;
        }
    }
}
