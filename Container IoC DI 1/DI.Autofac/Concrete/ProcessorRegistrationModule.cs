using System.Linq;
using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace DI.Autofac.Concrete
{
    public class ProcessorRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("SufixoID")).As(t =>
                    t.GetInterfaces().FirstOrDefault(i => i.Name.StartsWith("I" + t.Name)));

        }
    }
}

