using System;

namespace DemoLibrary
{
    // https://www.youtube.com/watch?v=NnZZMkwI6KI&t=1292s dependency inversion.. ""make everything disconnected, make everything talk to interface""
    public class BookList
    {
        // test is the DataType can work in different class withour creating an object (and the result is Yes, you can check the TestBookType.cs)
        private string name { get; set; }
        public int page { get; set; }
    }
}
