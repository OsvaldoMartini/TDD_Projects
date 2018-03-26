using System;
using Autofac;
using DI.Autofac.BusinessObjects;
using DI.Autofac.Concrete;
using DI.Autofac.Interfaces;
using DI.Autofac.Models;

namespace DI.Autofac
{
    class Program
    {
        private static IContainer _container;

        static void Main(string[] args)
        {
            Console.WriteLine("Poor Man DI Containar");
            Console.WriteLine("");


            bool exit = false;
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("1 - Regular DI Usage");
                Console.WriteLine("2 - Specify service locator");
                Console.WriteLine("3 - General service locator");
                Console.WriteLine("4 - Lifetime scope");
                Console.WriteLine("5 - Assembly scanning");
                Console.WriteLine("6 - Module Usage");
                Console.WriteLine("7 - One-to-many");
                Console.WriteLine("8 - Post Construction resolve & Property injection");
                Console.WriteLine("9 - Construction finder");
                Console.WriteLine("0 - Exit");
                Console.WriteLine();

                string choice = Console.ReadLine();
                if (choice == "0")
                    exit = true;
                else
                {
                    OrderInfo orderInfo = new OrderInfo()
                    {
                        CustomerName = "Claudia Almeida",
                        Email = "claudiabhz@gmail.com",
                        Product = "LCD Monitor Smart Samsung",
                        Price = 259.00f,
                        CreditCard = "1234.5678.9876.5432"
                    };


                    Console.WriteLine("");
                    Console.WriteLine("Order Processing");
                    Console.WriteLine("");

                    ContainerBuilder builder = new ContainerBuilder();
                    switch (choice)
                    {
                        case "1":
                            //regular contgainer usage (Commerce1)
                            builder.RegisterType<Commerce1>();
                            builder.RegisterType<IBillingProcessor>().As<BillingProcessor>();
                            builder.RegisterType<ICustomer>().As<Customer>();
                            builder.RegisterType<INotifier>().As<Notifier>();
                            builder.RegisterType<ILogger>().As<Logger>();

                            _container = builder.Build();

                            Commerce1 commerce1 = _container.Resolve<Commerce1>();

                            commerce1.ProcessOrder(orderInfo);
                            break;
                        case "2":
                            //specific service locator (Commerce2)
                            builder.RegisterType<Commerce1>();
                            builder.RegisterType<IBillingProcessor>().As<BillingProcessor>();
                            builder.RegisterType<ICustomer>().As<Customer>();
                            builder.RegisterType<INotifier>().As<Notifier>();
                            builder.RegisterType<ILogger>().As<Logger>();

                            _container = builder.Build();

                            Commerce2 commerce2 = _container.Resolve<Commerce2>();

                            commerce2.ProcessOrder(orderInfo);
                            break;
                        default:
                            break;

                    }

                }

            }
          

            Console.WriteLine("");
            Console.WriteLine("Press [Enter] to exit...");
            Console.ReadLine();


        }
    }
}
