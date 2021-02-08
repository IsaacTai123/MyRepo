using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    class PersonDemo : IInterface1
    {
        public int firstNumber { get; set; }

        public string aString { get; set; }

        public string firstName { get; }
        public void firstMethod(string s)
        {
            Console.WriteLine($"this is person class {s}");
        }
    }
}
