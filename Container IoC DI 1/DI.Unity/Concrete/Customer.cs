using System;
using DI.Unity.Interfaces;

namespace DI.Unity.Concrete
{
    public class Customer:ICustomer
    {
        public void UpdateCustomerOrder(string customer, string product)
        {
            //update customer record with purchase
            Console.WriteLine(String.Format("Customer record for '{0}' updated with purchase the product '{1}'", customer, product));
        }
    }
}
