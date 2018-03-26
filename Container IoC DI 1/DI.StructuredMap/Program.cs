using System;
using DI.StructuredMap.BusinessObjects;
using DI.StructuredMap.Concrete;
using DI.StructuredMap.Interfaces;
using DI.StructuredMap.Models;
using StructureMap;

namespace DI.StructuredMap
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("StructuredMap DI Container");
            Console.WriteLine("");

            //Not Found this Application of Container();
            //Container _container = new Container();

            Container _container = new Container();

            _container.Configure(reg => reg.For<IBillingProcessor>().Use<BillingProcessor>());
            _container.Configure(reg => reg.For<ICustomer>().Use<Customer>());
            _container.Configure(reg => reg.For<INotifier>().Use<Notifier>());
            _container.Configure(reg => reg.For<ILogger>().Use<Logger>());
            
            OrderInfo orderInfo = new OrderInfo()
            {
                CustomerName = "Claudia Almeida",
                Email = "claudiabhz@gmail.com",
                Product = "LCD Monitor Smart Samsung",
                Price = 259.00f,
                CreditCard = "1234.5678.9876.5432"
            };

            Console.WriteLine("Production");
            Console.WriteLine("");

            //Stoped to "Newing Up classes"
            Commerce commerce = _container.GetInstance<Commerce>();
            commerce.ProcessOrder(orderInfo);

            Console.WriteLine("");
            Console.WriteLine("Press [Enter] to exit...");
            Console.ReadLine();


        }
    }
}
