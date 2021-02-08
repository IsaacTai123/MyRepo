using System;
using System.Collections.Generic;

namespace list_tutorial
{
    class Program
    {
        static void WorkingWithStrings()
        {
            var names = new List<string> { "<name>", "Ana", "Felipe" };
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}");
            }

            // Modify list contents
            Console.WriteLine();
            names.Add("isaac");
            names.Add("Bill");
            names.Remove("Ana");

            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}");
            }

            Console.WriteLine($"My name is {names[0]}");
            Console.WriteLine($"I've added {names[2]} and {names[3]} to the list");


            // Search and sort lists
            var index = names.IndexOf("Felipe");
            if (index == -1)
            {
                Console.WriteLine($"When an item is not found, indexof return {index}");
            }
            else
            {
                Console.WriteLine($"The name {names[index]} is at index {index}");
            }

            index = names.IndexOf("Not Found");
            if (index == -1)
            {
                Console.WriteLine($"When an item is not found, IndexOf returns {index}");
            }
            else
            {
                Console.WriteLine($"The name {names[index]} is at index {index}");

            }


            // The items in your list can be sorted as well. The Sort method sorts all the items in the list in their normal order (alphabetically for strings)
            names.Sort();
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}");
            }
        }

        static void number()
        {
            List<int> fibonacciNumbers = new List<int> { 1, 1 };
            
            while (fibonacciNumbers.Count < 20)
            {
                int previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
                int previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];
                fibonacciNumbers.Add(previous + previous2);
            }

            foreach (int item in fibonacciNumbers)
            {
                Console.WriteLine(item);
            }
        }


        static void Main(string[] args)
        {
            //WorkingWithStrings();
            number();
        }
    }
}
