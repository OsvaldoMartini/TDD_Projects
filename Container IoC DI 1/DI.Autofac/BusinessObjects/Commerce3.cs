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
            IBillingProcessSufixoID billingProcessor = _ProcessorLocator.GetProcessor<IBillingProcessSufixoID>();
            ICustomerSufixoID customerProcessor = _ProcessorLocator.GetProcessor<ICustomerSufixoID>();
            INotifierSufixoID notifierProcessor = _ProcessorLocator.GetProcessor<INotifierSufixoID>();
            ILoggerSufixoID loggerProcessor = _ProcessorLocator.GetProcessor<ILoggerSufixoID>();

            billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            loggerProcessor.Log("Billing Processed");
            customerProcessor.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            loggerProcessor.Log("Customer Updated");
            notifierProcessor.SendReceipt(orderInfo);
            loggerProcessor.Log("Receipt Sent");
        }

    }
}
