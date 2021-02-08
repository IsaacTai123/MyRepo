using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;

namespace SellingSystem.Models.DB
{
    public class Helper
    {
        public static string CnnVal(string name)
        {
            var output = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            return output;
            //return ConfigurationManager.ConnectionStrings[name];
        }
    }
}
