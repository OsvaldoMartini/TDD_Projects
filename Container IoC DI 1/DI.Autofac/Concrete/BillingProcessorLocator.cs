using DI.Autofac.Interfaces;
using Autofac;

namespace DI.Autofac.Concrete
{
    public class BillingProcessorLocator : IBillingProcessLocator
    {
        IBillingProcess IBillingProcessLocator.GetBillingProcessor()
        {
            return Program._container.Resolve<IBillingProcess>();
        }
    }
}
