using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DI.Autofac.Interfaces;

namespace DI.Autofac.Concrete
{
    public class SingleTest:ISingleTest
    {
        private int _counter = 1;
        public void DisplayCounter()
        {
            Console.WriteLine(_counter++);
        }
    }
}
