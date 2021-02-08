using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureStoreDataInCookieAndSession.Models.DataModels
{
    public class DataModel
    {
        public class DataIfYouHaveCertificate
        {
            public string Name { get; set; } = "Karro";
            public string Gender { get; set; } = "Girl";
        }

        public class Certificate
        {
            public string certificate { get; set; }
        }


    }
}
