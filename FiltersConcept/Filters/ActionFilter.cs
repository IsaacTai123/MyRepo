using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters
{
    public class ActionFilter : Attribute, IActionFilter, IOrderedFilter
    {
        public string Name { get; set; }
        public int Order { get; set; }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.WriteAsync($"{GetType().Name}({Name}) in. \r\n");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.WriteAsync($"{GetType().Name}({Name}) out. \r\n");
            Console.WriteLine("Hi, you hit me once");
        }
    }

    //Asynchronous
    //public class ActionFilter : IAsyncActionFilter
    //{
    //    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    //    {
    //        await context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");

    //        await next();

    //        await context.HttpContext.Response.WriteAsync($"{GetType().Name} out. \r\n");
    //    }
    //}
}
