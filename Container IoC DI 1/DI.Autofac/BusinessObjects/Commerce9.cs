using System.Collections.Generic;
using DI.Autofac.Concrete;
using DI.Autofac.ConstructorFinder;
using DI.Autofac.Interfaces;
using DI.Autofac.Models;

namespace DI.Autofac.BusinessObjects
{
    public class Commerce9
    {
        public IProcessorLocatorGeneric _ProcessorLocatorGeneric;
        public IEnumerable<IPostOrderPlugin> _Plugins;

        //I am able to Decorate the constructor like below
        [AwesomeConstructor]
        public Commerce9(IProcessorLocatorGeneric processorLocatorGeneric, IEnumerable<IPostOrderPlugin> plugins)
        {
            _ProcessorLocatorGeneric = processorLocatorGeneric;
            _Plugins = plugins;

        }

        public Commerce9(int a, int b, int c, int d)
        {
        }


        public void ProcessOrder(OrderInfo orderInfo)
        {
            IBillingProcessSuffixID billingProcessor = _ProcessorLocatorGeneric.GetProcessor<IBillingProcessSuffixID>();
            ICustomerSuffixID customerProcessor = _ProcessorLocatorGeneric.GetProcessor<ICustomerSuffixID>();
            INotifierSuffixID notifierProcessor = _ProcessorLocatorGeneric.GetProcessor<INotifierSuffixID>();
            ILoggerSuffixID loggerProcessor = _ProcessorLocatorGeneric.GetProcessor<ILoggerSuffixID>();

            billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            loggerProcessor.Log("Billing Processed");
            customerProcessor.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            loggerProcessor.Log("Customer Updated");
            notifierProcessor.SendReceipt(orderInfo);
            loggerProcessor.Log("Receipt Sent");

            foreach (IPostOrderPlugin plugin in _Plugins)
            {
                plugin.DoSomething();

            }

        }
    }
}
