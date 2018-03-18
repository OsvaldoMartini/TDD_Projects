using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Coupled
{
    public class Commerce
    {
        private BillingProcessor _BillingProcessor;
        private Customer _Customer;
        private Notifier _Notifier;
        private Logger _Logger;

        public Commerce()
        {
            _BillingProcessor = new BillingProcessor();
            _Customer = new Customer();
            _Notifier = new Notifier();
            _Logger = new Logger();
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
