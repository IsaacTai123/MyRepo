using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SecureStoreDataInCookieAndSession.Models.DataModels.DataModel;
using SecureStoreDataInCookieAndSession.Models;
using SecureStoreDataInCookieAndSession.Extensions;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace SecureStoreDataInCookieAndSession.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IServiceModel _serviceModel;
       
        public HomeController(IServiceModel serviceModel)
        {
            _serviceModel = serviceModel;
        }

        [Route("")]
        [Route("~/Home")]
        public string FirstPage([FromQuery] string statement)
        {
            //create an token for certificate
            Certificate value = new Certificate { certificate = "abcdefghijklmnop" };


            //httpContext.Request.Cookies.
            _serviceModel.Cookies.SetObject("UserCertificate", value); //put the certificate to client cookie
            _serviceModel.AddCookiesToDic("UserCertificate_Dictionary", value); //stored the certificate to the system

            return statement;
        }

        
        
        public string SecondPage()
        {
            string cookieFromClient = _serviceModel.Cookies.GetObject<Certificate>("UserCertificate").certificate;

            Certificate value;
            _serviceModel.GetIdentifyTokenList.TryGetValue("UserCertificate_Dictionary", out value);
            string DictionaryCertificate = value.certificate;

            //check the cookie of the certificate if the same
            if (cookieFromClient == DictionaryCertificate)
            {
                DataIfYouHaveCertificate Data = new DataIfYouHaveCertificate();
                return $"{Data.Name} and {Data.Gender}";
            }

            return "false";
        }

        //get the response headers
        public void GetHttpHeader()
        {
            string url = "https://localhost:5001/Home/FirstPage?statement=thisisfirstpageaccess";
            // Creates an HttpWebRequest for the specified URL.
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            // Sends the HttpWebRequest and waits for response.
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

            Console.WriteLine("\r\nThe following headers were received in the request:");
            for (int i = 0; i < myHttpWebRequest.Headers.Count; ++i)
                Console.WriteLine("\nHeader Name:{0}, Value :{1}", myHttpWebRequest.Headers.Keys[i], myHttpWebRequest.Headers[i]);


            // Displays all the headers present in the response received from the URI.
            Console.WriteLine("\r\nThe following headers were received in the response:");
            // Displays each header and it's key associated with the response.
            for (int i = 0; i < myHttpWebResponse.Headers.Count; ++i)
                Console.WriteLine("\nHeader Name:{0}, Value :{1}", myHttpWebResponse.Headers.Keys[i], myHttpWebResponse.Headers[i]);
            // Releases the resources of the response.
            myHttpWebResponse.Close();
        }

        private void PrintHeader(IHeaderDictionary dict)
        {
            foreach (var keys in dict.Keys)
            {
                string str = "Key : " + keys + ":  Values : " + dict[keys];
                Console.WriteLine(str);
            }

        }

        [HttpGet("employee")]
        public string GetDetails()
        {
            PrintHeader(Request.Headers);
            return "Ok";

        }


    }

    public class EmployeeRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmployeeRepository(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void GetEmployeeByID(int employeeID)
        {
            string header =
           _httpContextAccessor.HttpContext.Request.Headers["X-Custom-Header"];
            //PerformBusinessLogic(header);
        } 
    }



}
