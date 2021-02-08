using System;
using System.Collections.Generic;
using System.Text;

namespace DemoLibrary
{
    class callingDemo
    {
        private void MakeDemoCalls()
        {
            AccessDemo demo = new AccessDemo();
            demo.InternalDemo();
        }
    }
}
