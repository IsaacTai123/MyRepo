using System;
using FirstProject.People;
using ClassLibrary1;

namespace FirstProject
{
    public enum ProductCodes
    {
        Milk = 0,
        Juice = 1,
        Tea = 2
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "john";
            person.Age = 28;
            person.HasPet = true;

            person.Greeting();



            int result = Calculator.Add(5, 10);
            Console.WriteLine(result);

            int result2 = Calculator.Sub(1, 6);

            //create an Array
            string name01 = "Dnaiel";
            string name02 = "John";
            string name03 = "jane";
            string name04 = "Tobi";

            string[] names = new string[4];
            names[0] = "Daniel";
            names[1] = "John";
            names[2] = "jane";
            names[3] = "Tobi";
            Console.WriteLine(names[2]);

            string[] name = new string[4] { "Daniel", "John", "Jane", "Tobi" };

            //Rectangular array
            var namesList = new string[4, 2] 
            {
                { "Daniel", "28y" },
                { "john", "34y" },
                { "Jane", "23y" },
                { "Tobi", "22y" },
            };
            Console.WriteLine(namesList[1, 0]);

            var namesList2 = new string[2, 2, 3]
            {
                {
                    { "Daniel", "28y", "eye color is blue" },
                    { "Daniel", "28y", "eye color is yello" }
                },
                {
                    { "Daniel", "28y", "eye color is red" },
                    { "Daniel", "28y", "eye color is brown" }
                },
            };
            Console.WriteLine(namesList2[1, 0, 2]);

            //Jagged array
            var namesList3 = new int[4][];
            namesList3[0] = new int[2];
            namesList3[1] = new int[3];
            namesList3[2] = new int[1];
            namesList3[3] = new int[3];

            namesList3[0][0] = 5;
            namesList3[0][1] = 3;

            namesList3[1][0] = 234;
            namesList3[1][1] = 333;
            namesList3[1][2] = 444;

            Console.WriteLine(namesList3[1][0]);
            

            //parse the string datatype to int
            string num = "2";
            int num2 = Int32.Parse(num);

            //get user input in c#
            Console.WriteLine("what is your age ?");
            string age = Console.ReadLine();
            int num3 = Int32.Parse(age);
            int newAge = num3 + 5;

            Console.WriteLine("youe age in five year is going to be " + newAge);


            //Enum
            ProductCodes test = ProductCodes.Milk;
            Console.WriteLine((int)test);

            int test2 = 1;
            Console.WriteLine((ProductCodes)test2);

            string test3 = "Tea";
            ProductCodes getParse;
            bool checkParse = Enum.TryParse(test3, out getParse);
            Console.WriteLine(getParse);
        }
    }
}
