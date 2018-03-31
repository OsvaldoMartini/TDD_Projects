using System.Collections.Generic;
using DI.Autofac.Concrete;
using DI.Autofac.Interfaces;
using DI.Autofac.Models;

namespace DI.Autofac.BusinessObjects
{
    public class Commerce7
    {
        private IProcessorLocatorGeneric _ProcessorLocatorGeneric;
        private IEnumerable<IPostOrderPlugin> _Plugins;

        public Commerce7(IProcessorLocatorGeneric processorLocatorGeneric, IEnumerable<IPostOrderPlugin> plugins)
        {
            _ProcessorLocatorGeneric = processorLocatorGeneric;
            _Plugins = plugins;
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
        }

    }
}
