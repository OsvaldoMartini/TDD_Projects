using DI.Abstraction.Interfaces;
using DI.Abstraction.Models;

namespace DI.Abstraction.BusinessObjects
{
    public class Commerce
    {
        private IBillingProcessor _BillingProcessor;
        private ICustomer _Customer;
        private INotifier _Notifier;
        private ILogger _Logger;

        public Commerce(IBillingProcessor billingProcessor,ICustomer customer, INotifier notifier, ILogger logger)
        {
            _BillingProcessor = billingProcessor;
            _Customer = customer;
            _Notifier = notifier;
            _Logger = logger;
        }

        public void ProcessOrder(OrderInfo orderInfo)
        {
            _BillingProcessor.ProcessPayment(orderInfo.CustomerName,orderInfo.CreditCard,orderInfo.Price);
            _Logger.Log("Billing Processed");
            _Customer.UpdateCustomerOrder(orderInfo.CustomerName,orderInfo.Product);
            _Logger.Log("Customer Updated");
            _Notifier.SendReceipt(orderInfo);
            _Logger.Log("Receipt Sent");
        }

    }
}
