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
            IBillingProcessor billingProcessor = _ProcessorLocator.GetProcessor<IBillingProcessor>();
            ICustomer customer = _ProcessorLocator.GetProcessor<ICustomer>();
            INotifier notifier = _ProcessorLocator.GetProcessor<INotifier>();
            ILogger logger = _ProcessorLocator.GetProcessor<ILogger>();

            billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            logger.Log("Billing Processed");
            customer.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            logger.Log("Customer Updated");
            notifier.SendReceipt(orderInfo);
            logger.Log("Receipt Sent");
        }

    }
}
