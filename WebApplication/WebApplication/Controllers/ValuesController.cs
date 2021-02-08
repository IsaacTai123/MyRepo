using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class MemberConfig
    {
        public string Account { get; set; }
        public string Password { get; set; }
    }

    public class ConfigModel
    {
        public string url { get; set; }
        public List<Users> Users { get; set; }
    }

    public class Users
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }


   
    [Route("[controller]/[action]")]
    public class ValuesController : Controller
    {
        private IConfiguration _config;
        public ValuesController(IConfiguration config)
        {
            _config = config;
        }


        // Get the value from appsettings.json practice
        [HttpGet]
        public ActionResult<string> Get(){
            var MemberConfig = new MemberConfig();
            MemberConfig.Account = _config.GetValue<string>("Member:Account");
            MemberConfig.Password = _config.GetValue<string>("Member:Password");


            string url = _config["Custom:JiraConfig:Url"];
            string username = _config["Custom:JiraConfig:Users:1:UserName"];

            var appConfig = new ConfigModel();
            appConfig.url = _config.GetValue<string>("Custom:JiraConfig:Url");

            appConfig.Users = _config.GetSection("Custom:JiraConfig:Users").Get<List<Users>>();

            string str = "";
            foreach (var item in appConfig.Users)
            {
                str += $"{item.UserName} - {item.Password} \r\n";
            }


            return $"url -> {url} \r\n username -> {username} \r\n appConfig.url -> {appConfig.url} \r\n appConfig.Users \r\n -> {str}";
            //return $"Account is {MemberConfig.Account} Password is {MemberConfig.Password}";

            
        }
    }
}
