using Autofac;
using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure(); //configure the container, and the container is what holds all of our instantiation set up for how to instantiate something

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>(); // i need an IApplication object,   check the url 27:00
                app.Run();
            }

            Console.ReadLine();
        }
    }
}
