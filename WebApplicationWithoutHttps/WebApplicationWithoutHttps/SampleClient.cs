using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplicationWithoutHttps
{
    public class SampleClient
    {
        public HttpClient client { get; private set; }
        public SampleClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://api.SampleClient.com/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");

            client = httpClient;
        }
    }
}
