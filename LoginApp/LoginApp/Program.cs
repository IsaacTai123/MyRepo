using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace LoginApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //User user = new User("jason", "email@gmail.com");
            //user.Name = "New name";
            ////user.Email = "New mail"; // this is nsot allow cause Email is defined as a getter property, so you will get the message this is read only

            //LoginManager loginMgr = new LoginManager();
            //if (loginMgr.Login(user))
            //{
            //    // Login was successful
            //}
            //else
            //{
            //    // not successful
            //}
            var date = DateTime.Now;
            var newdate = date.ToString("yyyyMMddHHmmssffff");

            var Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(); // transform the datetime.now to second
            
            Console.WriteLine(date);
            Console.WriteLine(newdate);
            Console.WriteLine(Timestamp);
            Console.WriteLine(Timestamp + 30);

        }    
    }
}

