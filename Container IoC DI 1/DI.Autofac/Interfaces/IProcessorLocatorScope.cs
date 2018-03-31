namespace DI.Autofac.Interfaces
{
    public interface IProcessorLocatorScope
    {
        T GetProcessor<T>();

        void ReleaseScope();

        void CreateScope();
    }
}
