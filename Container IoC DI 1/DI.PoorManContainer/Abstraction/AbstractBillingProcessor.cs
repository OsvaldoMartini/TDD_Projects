﻿using System;
using DI.PoorMainContainer.Interfaces;

namespace DI.PoorMainContainer.Abstraction
{
    public abstract class AbstractBillingProcessor : IBillingProcessor
    {
        public void ProcessPayment(string customer, string creditCard, double price)
        {
            //performing billing gateway processing
            Console.WriteLine(String.Format("Payment processed for customer '{0}' on credit Card '{1} and value '{2}'", customer, creditCard, price));

        }
    }
}
