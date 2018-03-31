using DI.Autofac.Interfaces;
using DI.Autofac.Models;

namespace DI.Autofac.BusinessObjects
{
    public class Commerce2
    {
        private IBillingProcessLocator _BillingProcessorLocator;
        private ICustomerSufixoID _Customer;
        private INotifierSufixoID _Notifier;
        private ILoggerSufixoID _Logger;

        public Commerce2(IBillingProcessLocator billingProcessorLocator, ICustomerSufixoID customer, INotifierSufixoID notifier, ILoggerSufixoID logger)
        {
            _BillingProcessorLocator = billingProcessorLocator;
            _Customer = customer;
            _Notifier = notifier;
            _Logger = logger;
        }

        public void ProcessOrder(OrderInfo orderInfo)
        {
            IBillingProcessSufixoID billingProcessor = _BillingProcessorLocator.GetBillingProcessor();

            billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            _Logger.Log("Billing Processed");
            _Customer.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            _Logger.Log("Customer Updated");
            _Notifier.SendReceipt(orderInfo);
            _Logger.Log("Receipt Sent");
        }

    }
}
