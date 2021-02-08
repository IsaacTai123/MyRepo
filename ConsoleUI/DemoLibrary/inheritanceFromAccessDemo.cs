using System;
using System.Collections.Generic;
using System.Text;

namespace DemoLibrary
{
    class inheritanceFromAccessDemo : AccessDemo
    {
        public void Test()
        {
            PrivateProtectedDemo();
        }
    }
}
