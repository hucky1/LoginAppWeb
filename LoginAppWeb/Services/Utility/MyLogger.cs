using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginAppWeb.Services.Utility
{
    public class MyLogger : ILogger
    {
        //singleton patern example. Only one instance of the class can be instanciated  
        private static MyLogger instance;
        private static Logger logger;
        
        // single design pattern - private constructor
        private MyLogger()
        {

        }
        public static MyLogger GetInstance()
        {
            if (instance is null)
            {
                instance = new MyLogger();
            }
            return instance;
        }
        private Logger GetLogger(string theLogger)
        {
            if (logger is null)
            {
                logger = LogManager.GetLogger(theLogger);
            }
            return logger;
        }
        public void Debug(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLogerrule").Debug(message);
            else
                GetLogger("myAppLogerrule").Debug(message,arg);
        }

        public void Error(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLogerrule").Error(message);
            else
                GetLogger("myAppLogerrule").Error(message, arg);
        }

        public void Info(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLogerrule").Info(message);
            else
                GetLogger("myAppLogerrule").Info(message, arg);
        }

        public void Warning(string message, string arg = null)
        {
            if (arg == null)
                GetLogger("myAppLogerrule").Warn(message);
            else
                GetLogger("myAppLogerrule").Warn(message, arg);
        }
    }
}