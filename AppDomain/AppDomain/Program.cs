using System;


namespace AppDomain_practice
{
    class Program
    {
        static void Main(string[] args)
        {

            // App domain which secured 
            AppDomain securedDomain = AppDomain.CreateDomain("securedDomain");
            Type thirdparty = typeof(ThirdParty);
            securedDomain.CreateInstanceAndUnwrap(thirdparty.Assembly.FullName, thirdparty.FullName);
            AppDomain.Unload(securedDomain);

            // In to the current app domain
            Class1 obj = new Class1();
            Class2 obj2 = new Class2();
            Console.Read();
        }
    }

    public class ThirdParty
    {
        public ThirdParty()
        {
            Console.WriteLine("Third party loaded");
            System.IO.File.Create(@"c:\x.txt");
        }
        ~ThirdParty()
        {
            Console.WriteLine("Third party unloaded");
        }
    }

    public class Class1
    {

    }

    public class Class2
    {

    }
}
