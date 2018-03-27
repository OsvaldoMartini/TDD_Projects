using DI.Autofac.Interfaces;
using Autofac;

namespace DI.Autofac.Concrete
{
    public class BillingProcessorLocator : IBillingProcessorLocator
    {
        IBillingProcessor IBillingProcessorLocator.GetBillingProcessor()
        {
            return Program._container.Resolve<IBillingProcessor>();
        }
    }
}
