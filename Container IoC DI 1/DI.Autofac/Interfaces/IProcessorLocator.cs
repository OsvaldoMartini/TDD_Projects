namespace DI.Autofac.Concrete
{
    public interface IProcessorLocator
    {
        T GetProcessor<T>();

    }
}
