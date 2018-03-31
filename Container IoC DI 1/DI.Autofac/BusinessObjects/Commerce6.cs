using DI.Autofac.Interfaces;
using DI.Autofac.Models;

namespace DI.Autofac.BusinessObjects
{
    public class Commerce6
    {
        private IBillingProcessSufixoID _BillingProcessor;
        private ICustomerSufixoID _Customer;
        private INotifierSufixoID _Notifier;
        private ILoggerSufixoID _Logger;

        public Commerce6(IBillingProcessSufixoID billingProcessor, ICustomerSufixoID customer, INotifierSufixoID notifier, ILoggerSufixoID logger)
        {
            _BillingProcessor = billingProcessor;
            _Customer = customer;
            _Notifier = notifier;
            _Logger = logger;
        }

        public void ProcessOrder(OrderInfo orderInfo)
        {
            _BillingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            _Logger.Log("Billing Processed");
            _Customer.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            _Logger.Log("Customer Updated");
            _Notifier.SendReceipt(orderInfo);
            _Logger.Log("Receipt Sent");
        }

    }
}

