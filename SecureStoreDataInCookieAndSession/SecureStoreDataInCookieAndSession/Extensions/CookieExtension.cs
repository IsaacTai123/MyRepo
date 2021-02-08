using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureStoreDataInCookieAndSession.Extensions
{
    public static class CookieExtension
    {
        public static T GetObject<T>(this HttpContext Cookies, string key)
        {
            string value;
            Cookies.Request.Cookies.TryGetValue(key, out value);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public static void SetObject<T>(this HttpContext Cookies, string key, T value)
        {
            Cookies.Response.Cookies.Append(key, JsonConvert.SerializeObject(value));
        }
    }
}
