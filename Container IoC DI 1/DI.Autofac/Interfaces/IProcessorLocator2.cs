namespace DI.Autofac.Interfaces
{
    public interface IProcessorLocator2
    {
        T GetProcessor<T>();

        void ReleaseScope();

        void CreateScope();
    }
}
