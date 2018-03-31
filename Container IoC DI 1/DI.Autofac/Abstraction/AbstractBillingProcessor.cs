using System;
using DI.Autofac.Interfaces;

namespace DI.Autofac.Abstraction
{
    public abstract class AbstractBillingProcessor : IBillingProcess_Scanned
    {
        public void ProcessPayment(string customer, string creditCard, double price)
        {
            //performing billing gateway processing
            Console.WriteLine(String.Format("Payment processed for customer '{0}' on credit Card '{1} and value '{2}'", customer, creditCard, price));

        }
    }
}
