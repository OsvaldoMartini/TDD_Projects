using DI.Autofac.Interfaces;
using DI.Autofac.Models;

namespace DI.Autofac.BusinessObjects
{
    public class Commerce2
    {
        private IBillingProcessLocator _BillingProcessorLocator;
        private ICustomerSuffixID _Customer;
        private INotifierSuffixID _Notifier;
        private ILoggerSuffixID _Logger;

        public Commerce2(IBillingProcessLocator billingProcessorLocator, ICustomerSuffixID customer, INotifierSuffixID notifier, ILoggerSuffixID logger)
        {
            _BillingProcessorLocator = billingProcessorLocator;
            _Customer = customer;
            _Notifier = notifier;
            _Logger = logger;
        }

        public void ProcessOrder(OrderInfo orderInfo)
        {
            IBillingProcessSuffixID billingProcessor = _BillingProcessorLocator.GetBillingProcessor();

            billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            _Logger.Log("Billing Processed");
            _Customer.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            _Logger.Log("Customer Updated");
            _Notifier.SendReceipt(orderInfo);
            _Logger.Log("Receipt Sent");
        }

    }
}
