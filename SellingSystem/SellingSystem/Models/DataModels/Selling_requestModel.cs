using System;
using System.Collections.Generic;
using System.Text;

namespace SellingSystem.Models.DataModels
{
    public class Selling_requestModel
    {
        public class Member // this is just a model, 只能用在暫存
        {
            public int id { get; set; }
            public string name { get; set; }
            public int password { get; set; }
            public string email { get; set; }
            public int wallet { get; set; }
            public string secretKey { get; set; }
            public string IV { get; set; }
        }

        public class MemberOnlineModel
        {
            public Member member { get; set; }
            public long timestamp { get; set; }
        }

        public class MoneyAction
        {
            public int moneySpend { get; set; }
            public int moneyEarn { get; set; }
        }

        public class TransactionData
        {
            public int type { get; set; } // 0 mean Deduction, 1 mean deposit
            public int amount { get; set; } // amount of money
            public int memberId { get; set; }
        }

        public class KeyIV
        {
            public string uniqueId { get; set; }
            public string SecretKey { get; set; }
            public string IV { get; set; }
        }
    }
}
