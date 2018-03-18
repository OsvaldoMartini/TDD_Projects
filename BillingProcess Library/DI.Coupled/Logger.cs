using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Coupled
{
    public class Logger
    {
        public void Log(string message)
        {
            //log message to log file
            System.Diagnostics.Debug.WriteLine(string.Format("Log entry @ {0}: {1}",DateTime.Now, message));
            System.Diagnostics.Debug.WriteLine("");
        }
    }
}
