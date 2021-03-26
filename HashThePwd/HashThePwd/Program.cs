//using Org.BouncyCastle.Crypto.Generators;
using System;
using BCrypt.Net;

namespace HashThePwd
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "EnterYourPassword";
            Console.WriteLine(password);

            //Hashing a password in ASP.NET Core
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            Console.WriteLine(passwordHash);

            //Verify a password against a hash in ASP.NET Core
            bool verified = BCrypt.Net.BCrypt.Verify(password, passwordHash);
            Console.WriteLine(verified); // true the password is the same
        }
    }
}
