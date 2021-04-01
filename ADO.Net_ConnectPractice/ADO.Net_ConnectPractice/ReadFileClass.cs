using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ADO.Net_ConnectPractice
{
    class ReadFileClass : IDisposable
    {
        Boolean disposed = false;

        // 這個Dispose 就會clear managed and unmanaged resources了,
        // Right now we are not providing the implementation for the object of finalized (我們其實並不一定要用) 因為我們已經freeing up 
        // the managed and unmanaged resources from Dispose() method了
        public void Dispose() // 這個會pubilc Dispose will do nothing but call 下面的 virtual Dispose method. 並且參數帶入 true.
        {
            Dispose(true);
            GC.SuppressFinalize(this); 
        }

        // This dispose method will always clean up the unmanaged resources, when it will be called from the public disposed method
        // then the disposing argument is going to be "true", 如果disposing 是true, we will free up the managed resources and unmanaged resources
        // 當這個virtual Dispose 不是藉由上面的public Dispose() 呼叫的話, 那麼就是called from this object finalized method 
        // 這時disposing argument 就會是false, this will mean that the garbage collector is going to free up the managed resources but
        // still it is this dispose method job to clean up the unmanaged to resources.
        // (意思就是說 如果沒有呼叫上面的public Dispose呼叫的話, 那麼garbage collector就會自己呼叫objects finalized method 然後釋放managed resources,
        // 而virtual Dispose 只要呼叫他就會釋放 "unmanaged resources"
        protected virtual void Dispose(Boolean disposing)
        {
            if (disposed) return;

            if (disposing)
            {
                Console.WriteLine("Freeing managed resources.");
            }

            Console.WriteLine("Freeing unmanged resources");

            disposed = true;
        }


        // 但是if you still want to implement the object of finalized that you are thinking that you want to dispose some stuff
        // when the object is going to be collected by the garbage collector then you can do this. 
        // providing the destructure for the class for which we are implementing the dispose pattern 
        ~ReadFileClass()
        {
            // this will simply mean that the managed to resources are going to be freed by the garbage collector but the unmanaged resources
            // are always going to be freed no matter what the value of 上面的 "Boolean disposing" 是false 還是 true.
            Dispose(false);
        }
    }


    // safe handle object
    class ReadFileClassSafeHandle : IDisposable
    {
        Boolean disposed = false;
        SafeHandle safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(Boolean disposing)
        {
            if (disposed) return;

            if (disposing)
            {
                // Free unmanaged resource using the safe handle object
                safeHandle.Dispose();

                Console.WriteLine("Freeing managed resources.");
            }

            disposed = true;
        }


        ~ReadFileClassSafeHandle()
        {
            
            Dispose(false);
        }
    }


}
