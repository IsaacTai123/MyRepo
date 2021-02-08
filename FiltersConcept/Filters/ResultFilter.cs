using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters
{
    public class ResultFilter : Attribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            context.HttpContext.Response.WriteAsync($"{GetType().Name} out. \r\n");
        }
    }

    //Asynchronous
    //public class ResultFilter : IAsyncResultFilter
    //{
    //    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    //    {
    //        await context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");

    //        await next();

    //        await context.HttpContext.Response.WriteAsync($"{GetType().Name} out. \r\n");
    //    }
    //}
}
