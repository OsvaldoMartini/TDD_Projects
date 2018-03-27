using DI.Autofac.Interfaces;
using DI.Autofac.Models;

namespace DI.Autofac.BusinessObjects
{
    public class Commerce2
    {
        private IBillingProcessorLocator _BillingProcessorLocator;
        private ICustomer _Customer;
        private INotifier _Notifier;
        private ILogger _Logger;

        public Commerce2(IBillingProcessorLocator billingProcessorLocator, ICustomer customer, INotifier notifier, ILogger logger)
        {
            _BillingProcessorLocator = billingProcessorLocator;
            _Customer = customer;
            _Notifier = notifier;
            _Logger = logger;
        }

        public void ProcessOrder(OrderInfo orderInfo)
        {
            IBillingProcessor billingProcessor = _BillingProcessorLocator.GetBillingProcessor();

            billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            _Logger.Log("Billing Processed");
            _Customer.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            _Logger.Log("Customer Updated");
            _Notifier.SendReceipt(orderInfo);
            _Logger.Log("Receipt Sent");
        }

    }
}
