using DI.Autofac.Interfaces;
using DI.Autofac.Models;

namespace DI.Autofac.BusinessObjects
{
    public class Commerce5
    {
        private IBillingProcessSuffixID _BillingProcessor;
        private ICustomerSuffixID _Customer;
        private INotifierSuffixID _Notifier;
        private ILoggerSuffixID _Logger;

        public Commerce5(IBillingProcessSuffixID billingProcessor, ICustomerSuffixID customer, INotifierSuffixID notifier, ILoggerSuffixID logger)

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

