using DI.Autofac.Interfaces;
using Autofac;

namespace DI.Autofac.Concrete
{
    public class BillingProcessorLocator : IBillingProcessLocator
    {
        IBillingProcess_Scanned IBillingProcessLocator.GetBillingProcessor()
        {
            return Program._container.Resolve<IBillingProcess_Scanned>();
        }
    }
}
