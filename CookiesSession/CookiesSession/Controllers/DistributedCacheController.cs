using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;


namespace CookiesSession.Controllers
{
    public class DistributedCacheController : Controller
    {
        private static IDistributedCache _distributedCache;
        public DistributedCacheController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        //分散式快取 : https://blog.johnwu.cc/article/ironman-day20-asp-net-core-caching-redis-session.html
        //IDistributedCache 的 Get/Set 不像 IMemoryCache 可以存取任意型別，IDistributedCache 的 Get/Set 只能存取 byte[] 型別，
        //如果要將物件存入分散式快取，就必須將物件轉換成 byte[] 型別，或轉成字串型別用 GetString/SetString 存取於分散式快取。

        public IActionResult IndexAsync()
        {
            var cacheEntryOptions = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(60));

            _distributedCache.Set("DistributedCache", ObjectToByteArray(new UserModel()
            {
                name = "marko",
                Age = 30
            }), cacheEntryOptions);

            Thread.Sleep(TimeSpan.FromSeconds(70)); // 我讓她說 暫停70秒 因為上面我用cacheEntryOptions 給了這個資料保存時間設為60秒, 而在我讓系統暫停70 所以當我繼續跑下面得code時 資料已經因為時間到而被刪除了 所以會得到null
            var model = ByteArrayToObject<UserModel>(_distributedCache.Get("DistributedCache"));
            return Ok(model);
        }

        private byte[] ObjectToByteArray(object obj)
        {
            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, obj);
                return memoryStream.ToArray();
            }
        }

        private T ByteArrayToObject<T>(byte[] bytes)
        {
            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                memoryStream.Write(bytes, 0, bytes.Length);
                memoryStream.Seek(0, SeekOrigin.Begin);
                var obj = binaryFormatter.Deserialize(memoryStream);
                return (T)obj;
            }
        }
    }
}
