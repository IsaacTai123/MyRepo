using Microsoft.AspNetCore.Http;
using SecureStoreDataInCookieAndSession.Models.DataModels;
using System.Collections.Generic;

namespace SecureStoreDataInCookieAndSession.Models
{
    public interface IServiceModel
    {
        HttpContext Cookies { get; }
        ISession session { get; }

        Dictionary<string, DataModel.Certificate> GetIdentifyTokenList { get; }

        void AddCookiesToDic(string key, DataModel.Certificate value);
    }
}