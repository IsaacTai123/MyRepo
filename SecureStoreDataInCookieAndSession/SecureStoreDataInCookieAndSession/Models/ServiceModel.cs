using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static SecureStoreDataInCookieAndSession.Models.DataModels.DataModel;

namespace SecureStoreDataInCookieAndSession.Models
{
    public class ServiceModel : IServiceModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private Dictionary<string, Certificate> IdentifyTokenList = new Dictionary<string, Certificate>();

        public ServiceModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ISession session
        {
            get
            {
                return _httpContextAccessor.HttpContext.Session;
            }
        }

        public HttpContext Cookies
        {
            get
            {
                return _httpContextAccessor.HttpContext;
            }
        }

        public Dictionary<string, Certificate> GetIdentifyTokenList
        {
            get
            {
                return IdentifyTokenList;
            }
        }

        public void AddCookiesToDic(string key, Certificate value)
        {
            IdentifyTokenList.Add(key, value);
        }
    }
}
