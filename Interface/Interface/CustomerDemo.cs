using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    public class CustomerDemo : IInterface1
    {
        public int firstNumber { get; set; }

        public string aString { get; set; }

        public void firstMethod(string s)
        {
            Console.WriteLine($"this is customer class {s}");
        }
    }
}
