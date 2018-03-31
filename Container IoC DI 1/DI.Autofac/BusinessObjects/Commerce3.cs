using DI.Autofac.Concrete;
using DI.Autofac.Interfaces;
using DI.Autofac.Models;

namespace DI.Autofac.BusinessObjects
{
    public class Commerce3
    {
        private IProcessorLocator _ProcessorLocator;
        
        public Commerce3(IProcessorLocator processorLocator)
        {
            _ProcessorLocator = processorLocator;
        }

        public void ProcessOrder(OrderInfo orderInfo)
        {
            IBillingProcess_Scanned billingProcessor = _ProcessorLocator.GetProcessor<IBillingProcess_Scanned>();
            ICustomer_Scanned customerProcessor = _ProcessorLocator.GetProcessor<ICustomer_Scanned>();
            INotifier_Scanned notifierProcessor = _ProcessorLocator.GetProcessor<INotifier_Scanned>();
            ILogger_Scanned loggerProcessor = _ProcessorLocator.GetProcessor<ILogger_Scanned>();

            billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            loggerProcessor.Log("Billing Processed");
            customerProcessor.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            loggerProcessor.Log("Customer Updated");
            notifierProcessor.SendReceipt(orderInfo);
            loggerProcessor.Log("Receipt Sent");
        }

    }
}
