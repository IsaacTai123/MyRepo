using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptography
{
    class Person
    {
        public int memberId { get; set; }
        public int Type { get; set; }
        public string Amount { get; set; }

        public override string ToString()
        {
            return string.Format("Type is {0}, Amount is {1}", Type, Amount);
        }
    }
}
