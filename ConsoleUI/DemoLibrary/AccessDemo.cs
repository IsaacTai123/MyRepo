using System;

namespace DemoLibrary
{
    public class AccessDemo
    {
        private void PrivateDemo()
        {

        }

        //we can access private protected methods inside the same assembly "DemoLibrary" but not outside of it
        //So it's private if it's outside the assembly, if it's inside the assembly it's protected
        private protected void PrivateProtectedDemo()
        {

        }

        //so we have access to inside a same assembly and also from wherever inherits So basically this is internal inside its own and it is protected inside of any class that inherits from it
        protected internal void ProtectedInternalDemo()
        {

        }

        protected void ProtectedDemo()
        {

        }

        internal void InternalDemo()
        {

        }
    }
}
