using System;
using DI.Abstraction.BusinessObjects;
using DI.Abstraction.Concrete;
using DI.Abstraction.Models;

namespace DI.Abstraction
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Debug.WriteLine("Abstraction Example");
            System.Diagnostics.Debug.WriteLine("");

            OrderInfo orderInfo = new OrderInfo()
            {
                CustomerName = "Claudia Almeida",
                Email = "claudiabhz@gmail.com",
                Product = "LCD Monitor Smart Samsung",
                Price = 259.00f,
                CreditCard = "1234.5678.9876.5432"
            };

            System.Diagnostics.Debug.WriteLine("Production");
            System.Diagnostics.Debug.WriteLine("");
            //A Little coupled here (Newing Up classes), But we can consider this as Kick Start
            Commerce commerce = new Commerce(new BillingProcessor(), new Customer(), new Notifier(), new Logger());
            commerce.ProcessOrder(orderInfo);

            Console.WriteLine("");
            Console.WriteLine("Press [Enter] to exit...");
            Console.WriteLine("");


        }
    }
}
