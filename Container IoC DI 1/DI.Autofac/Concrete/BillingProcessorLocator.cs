using DI.Autofac.Interfaces;
using Autofac;

namespace DI.Autofac.Concrete
{
    public class BillingProcessorLocator : IBillingProcessLocator
    {
        IBillingProcessSufixoID IBillingProcessLocator.GetBillingProcessor()
        {
            return Program._container.Resolve<IBillingProcessSufixoID>();
        }
    }
}
