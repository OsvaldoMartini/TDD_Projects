using System;
using DI.Autofac.Interfaces;

namespace DI.Autofac.Plugins
{
    public class Plugin2 : IPostOrderPlugin
    {
        void IPostOrderPlugin.DoSomething()
        {
            Console.WriteLine("Plug-in #2 executed.");
        }
    }
}
