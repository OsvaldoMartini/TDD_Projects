using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace DI.Autofac.Concrete
{
    //class ProcessorRegistrationModule  : Autofac.Module
    //{
    //    protected override void Load(ContainerBuilder builder)
    //    {
    //        builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
    //            .Where(t => t.Name.EndsWith("Processor")).As(t =>
    //                t.GetInterfaces().FirstOrDefault(i => i.Name.StartsWith("I" + t.Name)));

    //    }
    //}
}
