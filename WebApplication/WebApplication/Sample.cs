using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class Sample : ISample
    {
        private static int _counter;

        public Sample()
        {
            Id = ++_counter;
        }

        public int Id { get; }
    }
}
