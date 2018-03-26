using System;
using DI.Unity.Interfaces;

namespace DI.Unity.Concrete
{
    public class Logger:ILogger
    {
        public void Log(string message)
        {
            //log message to log file
            Console.WriteLine(string.Format("Log entry @ {0}: {1}",DateTime.Now, message));
            Console.WriteLine("");
        }
    }
}
