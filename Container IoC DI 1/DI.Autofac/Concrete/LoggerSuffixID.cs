using System;
using DI.Autofac.Interfaces;

namespace DI.Autofac.Concrete
{
    public class LoggerSuffixID:ILoggerSuffixID
    {
        public void Log(string message)
        {
            //log message to log file
            Console.WriteLine(string.Format("Log entry @ {0}: {1}",DateTime.Now, message));
            Console.WriteLine("");
        }
    }
}
