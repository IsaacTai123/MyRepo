using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookiesSession.Controllers
{
    public class MemoryCacheController : Controller
    {
        private static IMemoryCache _memoryCache;

        public MemoryCacheController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            _memoryCache.Set("MemoryCache", new UserModel()
            {
                name = "quantin",
                Age = 50
            });


            // 用 Get/Set 方法，就可以透過 Key 做為取值的識別，存放任何型別的資料。
            var model = _memoryCache.Get<UserModel>("MemoryCache");
            return View(model);
        }
    }
}
