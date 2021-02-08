using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellingSystem.Models.Services
{
    public class ActionFilter : IAsyncActionFilter 
    {
        private readonly IMemberServicers _memberServicers;

        public ActionFilter(IMemberServicers memberServicers)
        {
            _memberServicers = memberServicers;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string queryString = context.HttpContext.Request.QueryString.Value;  // Get method to get the value from http context
            //throw new NotImplementedException();

            // seperate the value of context
            string rvFirstCharacter = queryString.Remove(0, 1);
            char[] separator = { '?', '&' };
            string[] array = rvFirstCharacter.Split(separator);
            string[] actualData = new string[array.Length];

            // loop through array remove anything but the data
            for (int i = 0; i < array.Length; i++)
            {
                int charPos = array[i].IndexOf("=");
                string value = array[i].Substring(charPos + 1);
                actualData[i] = value;
            }

            // check if the user is a member
            string username = actualData[0];
            int pwd = Convert.ToInt32(actualData[1]);
            if (_memberServicers.CheckTheMember(username, pwd) == true)
            {
                await next(); 
            }
            else
            {
                Console.WriteLine("<p>Please register first!!</p>"); // this will only show on the console black screen
            }
        }
    }
}
