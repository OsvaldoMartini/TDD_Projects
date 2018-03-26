using System;
using DI.PoorMainContainer.Interfaces;

namespace DI.PoorMainContainer.Concrete
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
