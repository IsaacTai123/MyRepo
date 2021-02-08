using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SellingSystem.Models.Services
{
    public class LogUtility
    {
        /// <summary>
        /// Builds the exception message.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        public static string BuildExceptionMessage(Exception x, Dictionary<string, Object> input)
        {
            Exception logException = x;
            if (x.InnerException != null)
            {
                logException = x.InnerException;
            }


            StringBuilder message = new StringBuilder();
            message.AppendLine();
            message.AppendLine("Error in Path : " + input["Path"]);
            // Get the QueryString along with the virtual path
            message.AppendLine("Raw Url : " + input["Headers"]);
            // Type of Exception
            message.AppendLine("Type of Exception : " + logException.GetType().Name);
            // Get the error message
            message.AppendLine("Message : " + logException.Message);
            // Source of the message
            message.AppendLine("Source : " + logException.Source);

            // Stack Trace of the error
            message.AppendLine("Stack Trace : " + logException.StackTrace);
            // Method where the eroor occurred
            message.AppendLine("TargetSite : " + logException.TargetSite);
            return message.ToString();
        }
    }
}
