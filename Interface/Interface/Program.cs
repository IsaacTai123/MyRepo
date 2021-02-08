using System;
using System.Collections.Generic;


namespace Interface
{
    class Program
    {
        //private BookList somtjig;
        static void Main(string[] args)
        {
            // book.cs create a book object https://www.youtube.com/watch?v=-ETZ0nOCU14&list=PLLAZ4kZ9dFpNIBTYHNDrhfE9C-imUXCmk&index=25
            // create an object, an object is an instace of a class, when we create an class we create a template for what a book is but creating an actual physical book inside of our program
            
            Book book1 = new Book(); // create a book Object  (the class is just the specification)
            book1.title = "Harry Potter";
            book1.author = "JK Rowling";
            book1.pages = 400;

            Book book2 = new Book();
            book2.title = "Lord of the Rings";
            book2.author = "Tolkeien";
            book2.pages = 700;

            Book book3 = new Book
            {
                title = "thirdBook",
                author = "me",
                pages = 20
            };

            Console.WriteLine(book3.title);



            // my practice about interface and dataType
            var array = new int[] { 1, 2, 3 };
            array.GetEnumerator();

            List<IInterface1> multiType = Sample();
            IInterface1 firstTest = GetInterface();
            
            foreach (IInterface1 prod in multiType)
            {
                Console.WriteLine($"this is first prod => {prod.GetType()}");
                Console.WriteLine();
            }

            Console.WriteLine("---------------------------------------------------------------");

            // IInterface1 test = new PersonDemo( { firstName = "jason" } );
            
            IInterface1 test2 = new CustomerDemo();

            // ICustomerModel customerModel = new ICustomerModel({ City = "NEW York"});
            ICustomerModel customerModel2 = GetCustomerModel();

            Console.WriteLine(customerModel2.LastName);
        }

        public static ICustomerModel GetCustomerModel()
        {
            //CustomerModel template = new CustomerModel();
            //template.City = "new york";
            //template.EmailAddress = "@gmail.com";

            //return template;

            return new CustomerModel
            {
                FirstName = "Tim",
                LastName = "Corey",
                City = "Scranton",
                EmailAddress = "tim@IAmTimCorey.com",
                // PhoneNumber = "555-1212"
            };
        }

        public static IInterface1 GetInterface()
        {
            return new CustomerDemo { firstNumber = 5 };
        }

        public static CustomerDemo GetCustomer()
        {
            return new CustomerDemo { firstNumber = 5 };
        }

        public void testCustomerDemo(CustomerDemo customer)
        {

        }

        private static List<IInterface1> Sample()
        {
            List<IInterface1> output = new List<IInterface1>();


            //CustomerDemo customer1 = new CustomerDemo();
            //customer1.firstNumber = 5;

            output.Add(new CustomerDemo { firstNumber = 5 });
            output.Add(new CustomerDemo { firstNumber = 10 });

            return output;
        }
    }
}
