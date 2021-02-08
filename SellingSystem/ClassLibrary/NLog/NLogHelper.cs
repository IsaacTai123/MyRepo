using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.NLog
{
    public class NLogHelper
    {
        private static Logger nlogger = LogManager.GetCurrentClassLogger();
        public static void Info(string msg)
        {
            nlogger.Info(msg);
        }

        public static void Error(string msg, Exception ex = null)
        {
            if (ex == null)
                nlogger.Error(msg);
            else
                nlogger.Error(msg + "\r\n" + ex.ToString() + "\r\n" + ex.Message);
        }
    }
}
