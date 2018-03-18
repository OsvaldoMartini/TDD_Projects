using System;
using DI.Abstraction.Interfaces;

namespace DI.Abstraction.Concrete
{
    public class Logger:ILogger
    {
        public void Log(string message)
        {
            //log message to log file
            System.Diagnostics.Debug.WriteLine(string.Format("Log entry @ {0}: {1}",DateTime.Now, message));
            System.Diagnostics.Debug.WriteLine("");
        }
    }
}
