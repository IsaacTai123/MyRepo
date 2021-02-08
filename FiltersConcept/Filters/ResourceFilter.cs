using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters
{
    public class ResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            context.HttpContext.Response.WriteAsync($"{GetType().Name} out. \r\n");
        }
    }


    //Asynchronous
    //public class ResourceFilter : IAsyncResourceFilter
    //{
    //    public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
    //    {
    //        await context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");

    //        await next();

    //        await context.HttpContext.Response.WriteAsync($"{GetType().Name} out. \r\n");
    //    }
    //}
}
