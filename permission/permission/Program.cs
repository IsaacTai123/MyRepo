using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace permission
{
    class Program
    {
        static void Main(string[] args)
        {
            var perm = new PermissionSet(PermissionState.None);

            perm.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
            perm.AddPermission(new FileIOPermission(FileIOPermissionAccess.NoAccess, @"c:\"));
            var setup = new AppDomainSetup();

            setup.ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

             // App domain which secured 
             AppDomain securedDomain = AppDomain.CreateDomain("securedDomain", null, setup, perm);

            try
            {
                Type thirdparty = typeof(ThirdParty);
                securedDomain.CreateInstanceAndUnwrap(thirdparty.Assembly.FullName, thirdparty.FullName);
            }
            catch (Exception ex)
            {
                AppDomain.Unload(securedDomain);
            }
            

            // In to the current app domain
            Class1 obj = new Class1();
            Class2 obj2 = new Class2();
            Console.WriteLine("finished running");
            Console.Read();
        }
    }

    [Serializable]
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
