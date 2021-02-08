using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware
{
    public class FirstMiddleware
    {
        private readonly RequestDelegate _next;

        public FirstMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("FirstMiddleware in \r\n");
            //if (!context.Response.HasStarted)
            //{
            //}
            Console.WriteLine("test");
            await _next(context);
            await context.Response.WriteAsync("FirstMiddleware out \r\n");
        }
    }
}
