using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Calculator
    {
        public static int Add(int x, int y)
        {
            int Num1 = x;
            int Num2 = y;
            int Answer = Num1 + Num2;
            return Answer;
        }
        public static int Sub(int x, int y)
        {
            int Num1 = x;
            int Num2 = y;
            int Answer = Num1 - Num2;
            return Answer;
        }
    }
}
