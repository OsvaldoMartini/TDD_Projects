using DI.Autofac.Interfaces;
using DI.Autofac.Models;

namespace DI.Autofac.BusinessObjects
{
    public class Commerce6
    {
        private IBillingProcess_Scanned _BillingProcessor;
        private ICustomer_Scanned _Customer;
        private INotifier_Scanned _Notifier;
        private ILogger_Scanned _Logger;

        public Commerce6(IBillingProcess_Scanned billingProcessor, ICustomer_Scanned customer, INotifier_Scanned notifier, ILogger_Scanned logger)
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

