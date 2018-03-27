using Autofac;

namespace DI.Autofac.Concrete
{
    public class ProcessorLocator: IProcessorLocator
    {
        T IProcessorLocator.GetProcessor<T>()
        {
            return Program._container.Resolve<T>();
        }
    }
}
