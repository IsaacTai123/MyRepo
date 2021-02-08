using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellingSystem.Models.Services
{
    public static class Extension
    {
        // After RC2 and 1.0 you no longer need to inject an IHttpContextAccessor to you extension class. 
        //It is immediately available in the IUrlHelper through the urlhelper.ActionContext.HttpContext.Request. 
        //You would then create an extension class following the same idea, but simpler since there will be no injection involved.
        public static string AbsoluteAction(
            this IUrlHelper url,
            string actionName,
            string controllerName,
            object routeValues = null)
        {
            string scheme = url.ActionContext.HttpContext.Request.Scheme;
            return url.Action(actionName, controllerName, routeValues, scheme);
        }

        // --------------------------------------------------------------------------------------------------------------------------------------------------

        // build the injection of accessor in case they are useful to someone..... 
        private static IHttpContextAccessor HttpContextAccessor;
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public static string AbsoluteAction2(
        this IUrlHelper url,
        string actionName,
        string controllerName,
        object routeValues = null)
        {
            string scheme = HttpContextAccessor.HttpContext.Request.Scheme;
            return url.Action(actionName, controllerName, routeValues, scheme);
        }
    }
}
