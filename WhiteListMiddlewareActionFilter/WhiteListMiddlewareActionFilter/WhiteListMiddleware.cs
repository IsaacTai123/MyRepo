using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WhiteListMiddlewareActionFilter
{
    public class WhiteListMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<WhiteListMiddleware> _logger;
        private readonly string _safeWhiteList;

        public WhiteListMiddleware(
            RequestDelegate next,
            ILogger<WhiteListMiddleware> logger,
            string safeWhiteList)
        {
            _next = next;
            _safeWhiteList = safeWhiteList;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method != "Get") //这里源代码中，只过滤了非GET请求，如果针对GET请求也需要启动IP白名单，可以去掉这个判断。
            {
                var remoteIp = context.Connection.RemoteIpAddress; //獲取客戶端的IP
                _logger.LogInformation($"Request from Remote IP address: { remoteIp }");

                Console.WriteLine(remoteIp);

                string[] ip = _safeWhiteList.Split(';'); //把在appsettings.json 的字串分成array

                var bytes = remoteIp.GetAddressBytes(); //把address 轉成 bytes[]
                var badIp = true;
                foreach (var address in ip)
                {
                    var testIp = IPAddress.Parse(address); //把字串的address 轉換成 真的IPAddress
                    Console.WriteLine(testIp);
                    if (testIp.GetAddressBytes().SequenceEqual(bytes)) //最後用SequenceEqual 比對每一個byte 是否一樣
                    {
                        badIp = false;
                        break;
                    }
                }

                if (badIp)
                {
                    _logger.LogInformation(
                    $"Forbidden Request from Remote IP address: {remoteIp}");
                    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    return;
                }
            }

            await _next.Invoke(context);
        }
    }
}
