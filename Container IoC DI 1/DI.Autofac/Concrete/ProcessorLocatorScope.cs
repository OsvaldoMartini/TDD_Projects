using Autofac;
using DI.Autofac.Interfaces;

namespace DI.Autofac.Concrete
{
    public class ProcessorLocatorScope:IProcessorLocatorScope
    {

        public ProcessorLocatorScope()
        {
            ((IProcessorLocatorScope)this).CreateScope();
        }

        private ILifetimeScope _scope = null;

        void IProcessorLocatorScope.ReleaseScope()
        {
            _scope.Dispose();
        }

        void IProcessorLocatorScope.CreateScope()
        {
            _scope = Program._container.BeginLifetimeScope();
        }

        T IProcessorLocatorScope.GetProcessor<T>()
        {
            return _scope.Resolve<T>();
        }


    }
}
