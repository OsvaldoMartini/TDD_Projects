﻿using System;
using DI.Abstraction.Interfaces;

namespace DI.Abstraction.Concrete
{
    public class Customer:ICustomer
    {
        public void UpdateCustomerOrder(string customer, string product)
        {
            //update customer record with purchase
            System.Diagnostics.Debug.WriteLine(String.Format("Customer record for '{0}' updated with purchase the product '{1}'", customer, product));
        }
    }
}
