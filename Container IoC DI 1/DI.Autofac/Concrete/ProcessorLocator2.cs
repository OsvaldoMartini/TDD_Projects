using Autofac;
using DI.Autofac.Interfaces;

namespace DI.Autofac.Concrete
{
    public class ProcessorLocator2:IProcessorLocator2
    {

        public ProcessorLocator2()
        {
            ((IProcessorLocator2)this).CreateScope();
        }

        private ILifetimeScope _scope = null;

        void IProcessorLocator2.ReleaseScope()
        {
            _scope.Dispose();
        }

        void IProcessorLocator2.CreateScope()
        {
            _scope = Program._container.BeginLifetimeScope();
        }

        T IProcessorLocator2.GetProcessor<T>()
        {
            return _scope.Resolve<T>();
        }


    }
}
