using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configuration.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        //不用強行別來獲取settings.json的資料
        //private readonly IConfiguration _config;

        //public HomeController(IConfiguration config)
        //{
        //    _config = config;
        //}

        //public string Index()
        //{
        //    var defaultCulture = _config["SupportedCultures:1"];
        //    var subProperty1 = _config["CustomObject:Property:SubProperty1"];
        //    var subProperty2 = _config["CustomObject:Property:SubProperty2"];
        //    var subProperty3 = _config["CustomObject:Property:SubProperty3"];

        //    return $"defaultCulture({defaultCulture.GetType()}): {defaultCulture}\r\n"
        //        + $"subProperty1({subProperty1.GetType()}): {subProperty1}\r\n"
        //        + $"subProperty2({subProperty2.GetType()}): {subProperty2}\r\n"
        //        + $"subProperty3({subProperty3.GetType()}): {subProperty3}\r\n";
        //}



        ////設定成強型別後 使用的 DI 型別改成 改用IOptions<T>
        private readonly Setting _settings;

        public HomeController(IOptions<Setting> settings)
        {
            _settings = settings.Value;
        }

        public string Index()
        {
            var defaultCulture = _settings.SupportedCultures[1];
            var subProperty1 = _settings.CustomObject.Property.SubProperty1;
            var subProperty2 = _settings.CustomObject.Property.SubProperty2;
            var subProperty3 = _settings.CustomObject.Property.SubProperty3;

            return $"defaultCulture({defaultCulture.GetType()}): {defaultCulture}\r\n"
                + $"subProperty1({subProperty1.GetType()}): {subProperty1}\r\n"
                + $"subProperty2({subProperty2.GetType()}): {subProperty2}\r\n"
                + $"subProperty3({subProperty3.GetType()}): {subProperty3}\r\n";
        }
    }


    //改用強型別及型態
    public class Setting
    {
        public string[] SupportedCultures { get; set; }
        public CustomObject CustomObject { get; set; }
    }

    public class CustomObject
    {
        public Property1 Property { get; set; }
    }

    public class Property1
    {
        public string SubProperty1 { get; set; }
        public string SubProperty2 { get; set; }
        public string SubProperty3 { get; set; }
    }
}
