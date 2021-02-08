using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Math
{
    class Calc
    {

        private int Calculate(string a, string x, string y)
        {
            int answer;
            int num1 = Int32.Parse(x);
            int num2 = Int32.Parse(y);

            switch (a)
            {
                case "+":
                    answer = num1 + num2;
                    break;
                case "-":
                    answer = num1 - num2;
                    break;
                case "*":
                    answer = num1 * num2;
                    break;
                case "/":
                    answer = num1 / num2;
                    break;
                default:
                    answer = 0;
                    break;
            }

            return answer;
        }

        public void RunThisCalc()
        {
            Console.WriteLine("what do you want to user +, -, *, /");
            String method = Console.ReadLine();
            Console.WriteLine("Please enter the first number you want");
            String firstNumber = Console.ReadLine();
            Console.WriteLine("Please enter the second number you want");
            String secondNumber = Console.ReadLine();
            int answer = Calculate(method, firstNumber, secondNumber);
            Console.WriteLine(answer);
            Console.WriteLine("Do you want to play it again ? Y/N");
            string respond = Console.ReadLine();
            if (respond == "y" || respond == "Y") { RunThisCalc(); }
        }
    }
}
