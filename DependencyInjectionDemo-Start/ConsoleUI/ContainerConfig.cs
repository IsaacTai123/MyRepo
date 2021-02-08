using Autofac;
using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

// https://www.youtube.com/watch?v=mCUNrRtVVWY&t=31s

namespace ConsoleUI
{
    public static class ContainerConfig
    {
        public static IContainer Configure() // the whole job of this is configure the Container
        {

            // what the Container is? it is a place to store the definitions thinking like a key value pair list of all of the different classes we want to instantiate, but right is empty so it's gonna return nothing
            var builder = new ContainerBuilder();


            // builder.RegisterType<Application>();  whenever you ask for an actual application i will give you a new instance

            builder.RegisterType<Application>().As<IApplication>();

            // here we're going to tell it to register different pieces
            builder.RegisterType<BusinessLogic>().As<IBusinessLogic>(); //this line of code means:  I am gonna register this class called BusinessLogic and whenever you look for IBusinessLogic interface return an instance of BusinessLogic
            // more simple explanation is someone need <IBusinessLogic> give them <BusinessLogic>.
            //doing this one by one could get a little long


            // here are the way to automate this process (linking every class in the utilities folder) -- after down the coding below, now i've mapped up everthing that's in utilities folder to each other interface to implementation
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(DemoLibrary))) // you can put any object name in here return the string of that object name
                .Where(t => t.Namespace.Contains("Utilities")) // in the DemoLibrary find where the namespace of whatever object you find (where the namespces contains the word "utilities"
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name)); // check the url up there on 19:03 ,  i is interface and t is class



            return builder.Build(); // builds the Container

            
        }
    }
}
