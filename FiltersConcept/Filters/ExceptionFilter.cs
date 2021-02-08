using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters
{
    //public class ExceptionFilter : Attribute, IExceptionFilter
    //{
    //    public void OnException(ExceptionContext context)
    //    {
    //        context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");
    //    }
    //}

    //public class ExceptionFilter : Attribute, IExceptionFilter
    //{
    //    public void OnException(ExceptionContext context)
    //    {
    //        context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");
    //    }
    //}

    //Asynchronous
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");
            return Task.CompletedTask;
        }
    }
}
