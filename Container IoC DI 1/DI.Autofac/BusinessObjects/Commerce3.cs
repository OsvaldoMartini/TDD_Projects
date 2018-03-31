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
            IBillingProcess billingProcessor = _ProcessorLocator.GetProcessor<IBillingProcess>();
            ICustomer customerProcessor = _ProcessorLocator.GetProcessor<ICustomer>();
            INotifier notifierProcessor = _ProcessorLocator.GetProcessor<INotifier>();
            ILogger loggerProcessor = _ProcessorLocator.GetProcessor<ILogger>();

            billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            loggerProcessor.Log("Billing Processed");
            customerProcessor.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            loggerProcessor.Log("Customer Updated");
            notifierProcessor.SendReceipt(orderInfo);
            loggerProcessor.Log("Receipt Sent");
        }

    }
}
