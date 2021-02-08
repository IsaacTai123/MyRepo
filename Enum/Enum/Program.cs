using System;

namespace Enums
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer[] customers = new Customer[3];

            customers[0] = new Customer
            {
                Name = "Mark",
                Gender = Gender.Male
            };

            customers[1] = new Customer
            {
                Name = "Kora",
                Gender = Gender.Female
            };

            customers[2] = new Customer
            {
                Name = "Sam",
                Gender = Gender.Unknown
            };

            foreach (Customer customer in customers)
            {
                Console.WriteLine("Name = {0} && Gender = {1}", customer.Name, customer.Gender);
            }


            int[] Values = (int[]) Enum.GetValues(typeof(Gender)); //return the type of the enum, 雖然enum的 default 值是int 但我們還是需要用 (int[]) 去做轉換

            foreach (int value in Values)
            {
                Console.WriteLine(value);
            }

            string[] Names = Enum.GetNames(typeof(Gender));

            foreach (string name in Names)
            {
                Console.WriteLine(name);
            }
        }

        public static string GetGender(Gender gender)
        {
            switch (gender)
            {
                case Gender.Unknown:
                    return "Unknown";
                case Gender.Male:
                    return "Male";
                case Gender.Female:
                    return "Female";
                default:
                    return "Invalid data detected";
            }
        }
    }


    // 0 - unknown
    // 1 - Male
    // 2 - Female
    public class Customer
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
    }

    public enum Gender
    {
        Unknown = 1,
        Male = 100,
        Female
    }

}
