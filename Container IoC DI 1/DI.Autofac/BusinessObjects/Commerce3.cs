using DI.Autofac.Concrete;
using DI.Autofac.Interfaces;
using DI.Autofac.Models;

namespace DI.Autofac.BusinessObjects
{
    public class Commerce3
    {
        private IProcessorLocatorGeneric _processorLocatorGeneric;

        public Commerce3(IProcessorLocatorGeneric processorLocatorGeneric)
        {
            _processorLocatorGeneric = processorLocatorGeneric;
        }

        public void ProcessOrder(OrderInfo orderInfo)
        {
            IBillingProcessSuffixID billingProcessor = _processorLocatorGeneric.GetProcessor<IBillingProcessSuffixID>();
            ICustomerSuffixID customerProcessor = _processorLocatorGeneric.GetProcessor<ICustomerSuffixID>();
            INotifierSuffixID notifierProcessor = _processorLocatorGeneric.GetProcessor<INotifierSuffixID>();
            ILoggerSuffixID loggerProcessor = _processorLocatorGeneric.GetProcessor<ILoggerSuffixID>();

            billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            loggerProcessor.Log("Billing Processed");
            customerProcessor.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            loggerProcessor.Log("Customer Updated");
            notifierProcessor.SendReceipt(orderInfo);
            loggerProcessor.Log("Receipt Sent");
        }

    }
}
