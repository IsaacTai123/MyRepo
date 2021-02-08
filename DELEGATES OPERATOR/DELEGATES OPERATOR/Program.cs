using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DELEGATES_OPERATOR
{
    class Program
    {
        // https://www.youtube.com/watch?v=3ZfwqWl-YI0 vidio for this tutorial



        public delegate void TestDelegate();
        public delegate bool TestBoolDelegate(int i);

        private TestDelegate testDelegateFuction;
        private TestBoolDelegate testBoolDelegateFunction;


        // there are some build-in delegate inside System
        private Action testAction; // return void and takes no parameters
        private Action<int, float> testIntFloatAction; // Generic version of Action that take parameters of any type

        // build-in delegate with return value
        private Func<bool> testFunc; // This one by default has a generic and generic won't be our result so essentially our return type
        private Func<int, bool> testIntBoolFunc; // the last one is always a result

        private void Start()
        {
            testDelegateFuction = new TestDelegate(MyTestDelegateFunction); //two way of pass in function this is more official way 
            testDelegateFuction += MySecondTestDelegateFunction; // and this is the simple way, it will cast it automatically
            testDelegateFuction();

            testBoolDelegateFunction = MyTestBoolDelegateFunction;
            Debug.WriteLine(testBoolDelegateFunction(2));


            //using anonymoud methods
            testDelegateFuction = delegate () { Debug.WriteLine("Anonymous method");  }; // this is a method how we create a function inside of a code block it is easier than having to create a seperate function in most cases
            testDelegateFuction();

            //anonymous methods (Lambda Expressions)
            testDelegateFuction = () => { Debug.WriteLine("Lambda Expressions"); }; //a easiest and most compact way of defining a function
            testDelegateFuction();

            testBoolDelegateFunction = (int i) => { return i < 5; };
            testBoolDelegateFunction = (int i) => i < 5; //more simply way


            // build-in delegate
            testIntFloatAction = (int i, float f) => { Debug.WriteLine("Test int float action"); };

            testFunc = () => false;
            testIntBoolFunc = (int i) => { return i < 5; };
        }

        private void MyTestDelegateFunction()
        {
            Debug.WriteLine("MyTestDelegateFunction");
        }


        private void MySecondTestDelegateFunction()
        {
            Debug.WriteLine("MySecondTestDelegateFunction");
        }

        private bool MyTestBoolDelegateFunction(int parameter)
        {
            return parameter < 5;
        }




        static void Main(string[] args)
        {
            // Declare a Func variable and assign a lambda expression to the
            // variable. The method takes a string and converts it to uppercase.
            Func<string, string> selector = str => str.ToUpper();

            // Create an array of strings.
            string[] words = { "orange", "apple", "Article", "elephant" };
            // Query the array and select strings according to the selector method.
            IEnumerable<String> aWords = words.Select(selector);

            // Output the results to the console.
            foreach (String word in aWords)
                Console.WriteLine(word);
            /*
            This code example produces the following output:

            ORANGE
            APPLE
            ARTICLE
            ELEPHANT

            */
        }
    }
}
