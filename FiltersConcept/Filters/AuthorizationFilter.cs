using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");
        }
    }

    // Asynchronous
    //public class AuthorizationFilter : IAsyncAuthorizationFilter
    //{
    //    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    //    {
    //        await context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");
    //    }
    //}
}
