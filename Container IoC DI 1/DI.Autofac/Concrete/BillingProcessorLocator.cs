using DI.Autofac.Interfaces;
using Autofac;

namespace DI.Autofac.Concrete
{
    public class BillingProcessorLocator : IBillingProcessLocator
    {
        IBillingProcessSuffixID IBillingProcessLocator.GetBillingProcessor()
        {
            return Program._container.Resolve<IBillingProcessSuffixID>();
        }
    }
}
