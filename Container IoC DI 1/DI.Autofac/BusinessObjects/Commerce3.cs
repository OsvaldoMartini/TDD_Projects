using DI.Autofac.Concrete;
using DI.Autofac.Interfaces;
using DI.Autofac.Models;

namespace DI.Autofac.BusinessObjects
{
    public class Commerce3
    {
        private IProcessorLocatorGeneric _ProcessorLocatorGeneric;

        public Commerce3(IProcessorLocatorGeneric processorLocatorGeneric)
        {
            _ProcessorLocatorGeneric = processorLocatorGeneric;
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
