using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DI.Autofac.Interfaces;

namespace DI.Autofac.Plugins
{
    public class Plugin1 : IPostOrderPlugin
    {
        void IPostOrderPlugin.DoSomething()
        {
            Console.WriteLine("Plug-in #1 executed.");
        }
    }
}
