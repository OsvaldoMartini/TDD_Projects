﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Coupled
{
    public class Customer
    {
        public void UpdateCustomerOrder(string customer, string product)
        {
            //update customer record with purchase
            System.Diagnostics.Debug.WriteLine(String.Format("Customer record for '{0}' updated with purchase the product '{1}'", customer, product));
        }
    }
}