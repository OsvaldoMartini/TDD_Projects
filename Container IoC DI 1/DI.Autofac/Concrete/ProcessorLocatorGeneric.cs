using Autofac;

namespace DI.Autofac.Concrete
{
    public class ProcessorLocatorGeneric: IProcessorLocatorGeneric
    {
        T IProcessorLocatorGeneric.GetProcessor<T>()
        {
            return Program._container.Resolve<T>();
        }
    }
}
