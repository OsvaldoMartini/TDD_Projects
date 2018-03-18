using System;
using DI.Abstraction.Interfaces;

namespace DI.Abstraction.Concrete
{
    public class BillingProcessor : IBillingProcessor
    {
        public void ProcessPayment(string customer, string creditCard, double price)
        {
            //performing billing gateway processing
            System.Diagnostics.Debug.WriteLine(String.Format("Payment processed for customer '{0}' on credit Card '{1} and value '{2}'",customer,creditCard,price));
        }
    }
}
