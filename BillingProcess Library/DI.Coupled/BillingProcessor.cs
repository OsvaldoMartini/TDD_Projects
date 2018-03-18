using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Coupled
{
    public class BillingProcessor
    {
        public void ProcessPayment(string customer, string creditCard, double price)
        {
            //performing billing gateway processing
            System.Diagnostics.Debug.WriteLine(String.Format("Payment processed for customer '{0}' on credit Card '{1} and value '{2}'",customer,creditCard,price));
        }
    }
}
