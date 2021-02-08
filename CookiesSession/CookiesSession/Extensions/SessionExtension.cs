using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

// https://blog.johnwu.cc/article/ironman-day11-asp-net-core-cookies-session.html

namespace CookiesSession.Extensions
{
    public static class SessionExtension
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
         
        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key); // get the value of the key [ key, value ]
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value); // what the purpose of the " default " here
        }
    }
}
