using System;
using System.Diagnostics;
using DI.Coupled.BusinessObjects;
using DI.Coupled.Models;

namespace DI.Coupled
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Debug.WriteLine("Abstraction Example");
            Debug.WriteLine("");

            var orderInfo = new OrderInfo
            {
                CustomerName = "Claudia Almeida",
                Email = "claudiabhz@gmail.com",
                Product = "LCD Monitor Smart Samsung",
                Price = 259.00f,
                CreditCard = "1234.5678.9876.5432"
            };

            Debug.WriteLine("Production");
            Debug.WriteLine("");

            var commerce = new Commerce();
            commerce.ProcessOrder(orderInfo);

            Console.WriteLine("");
            Console.WriteLine("Press [Enter] to exit...");
            Console.WriteLine("");
        }
    }
}