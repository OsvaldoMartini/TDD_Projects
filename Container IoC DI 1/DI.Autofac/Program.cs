using System;
using System.Linq;
using System.Reflection;
using Autofac;
using DI.Autofac.BusinessObjects;
using DI.Autofac.Concrete;
using DI.Autofac.Interfaces;
using DI.Autofac.Models;

namespace DI.Autofac
{
    public class Program
    {
        public static IContainer _container;

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
                            Console.WriteLine("1 - Regular DI Usage");
                            Console.WriteLine();
                            
                            builder.RegisterType<Commerce1>();
                            builder.RegisterType<BillingProcess_Scanned>().As<IBillingProcess_Scanned>();
                            builder.RegisterType<Customer_Scanned>().As<ICustomer_Scanned>();
                            builder.RegisterType<Notifier_Scanned>().As<INotifier_Scanned>();
                            builder.RegisterType<Logger_Scanned>().As<ILogger_Scanned>();

                            _container = builder.Build();

                            Commerce1 commerce1 = _container.Resolve<Commerce1>();

                            commerce1.ProcessOrder(orderInfo);
                            break;
                        case "2":
                            //specific service locator (Commerce2)
                            Console.WriteLine("2 - Specify service locator");
                            Console.WriteLine();

                            builder.RegisterType<Commerce2>();
                            builder.RegisterType<BillingProcess_Scanned>().As<IBillingProcess_Scanned>();
                            builder.RegisterType<Customer_Scanned>().As<ICustomer_Scanned>();
                            builder.RegisterType<Notifier_Scanned>().As<INotifier_Scanned>();
                            builder.RegisterType<Logger_Scanned>().As<ILogger_Scanned>();
                            builder.RegisterType<BillingProcessorLocator>().As<IBillingProcessLocator>();

                            _container = builder.Build();

                            Commerce2 commerce2 = _container.Resolve<Commerce2>();

                            commerce2.ProcessOrder(orderInfo);
                            break;
                        case "3":
                            //general service locator (Commerce3)
                            Console.WriteLine("3 - General service locator");
                            Console.WriteLine();
                            
                            builder.RegisterType<Commerce3>();
                            builder.RegisterType<BillingProcess_Scanned>().As<IBillingProcess_Scanned>();
                            builder.RegisterType<Customer_Scanned>().As<ICustomer_Scanned>();
                            builder.RegisterType<Notifier_Scanned>().As<INotifier_Scanned>();
                            builder.RegisterType<Logger_Scanned>().As<ILogger_Scanned>();
                            builder.RegisterType<ProcessorLocator>().As<IProcessorLocator>();

                            _container = builder.Build();

                            Commerce3 commerce3 = _container.Resolve<Commerce3>();

                            commerce3.ProcessOrder(orderInfo);
                            break;
                        case "4":
                            //lifetime scope & singleton (Commerce4)
                            Console.WriteLine("4 - Lifetime scope");
                            Console.WriteLine();
                            
                            builder.RegisterType<Commerce4>();
                            builder.RegisterType<BillingProcess_Scanned>().As<IBillingProcess_Scanned>();
                            builder.RegisterType<Customer_Scanned>().As<ICustomer_Scanned>();
                            builder.RegisterType<Notifier_Scanned>().As<INotifier_Scanned>();
                            builder.RegisterType<Logger_Scanned>().As<ILogger_Scanned>();
                            builder.RegisterType<ProcessorLocator2>().As<IProcessorLocator2>();
                            builder.RegisterType<SingleTest>().As<ISingleTest>().SingleInstance();

                            _container = builder.Build();

                            //Sample lifetame scope resolving
                                //using (ILifetimeScope scope = _container.BeginLifetimeScope())
                                //{
                                //    Commerce4 scopedCommerce = scope.Resolve<Commerce4>();
                                //}
                            //if dependencies were "Disposable", they would now be disposable and released
                            //without lifetime scope the container would hold on to  disposable components

                            Commerce4 commerce4 = _container.Resolve<Commerce4>();

                            commerce4.ProcessOrder(orderInfo);

                            Console.WriteLine("Press 'Enter' to process again...");
                            Console.ReadLine();

                            commerce4 = _container.Resolve<Commerce4>();
                            commerce4.ProcessOrder(orderInfo);
                            
                            Console.WriteLine("Press 'Enter' to process again...");
                            Console.ReadLine();
 
                            commerce4 = _container.Resolve<Commerce4>();
                            commerce4.ProcessOrder(orderInfo);


                            break;
                        case "5":
                            //assembly scanning (Commerce5)
                            Console.WriteLine("5 - Assembly scanning");
                            Console.WriteLine();

                            builder.RegisterType<Commerce5>();
                            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .Where(t => t.Name.EndsWith("_Scanned")).As(t =>
                                    t.GetInterfaces().FirstOrDefault(i => i.Name.StartsWith("I" + t.Name)));

                            _container = builder.Build();
                            Commerce5 commerce5 = _container.Resolve<Commerce5>();

                            commerce5.ProcessOrder(orderInfo);
                            
                            break;

                        case "6":
                            //module usage (Commerce6)
                            Console.WriteLine("6 - Module Usage");
                            Console.WriteLine();
                            builder.RegisterType<Commerce6>();
                            builder.RegisterModule<ProcessorRegistrationModule>();
                          
                            _container = builder.Build();
                            Commerce6 commerce6 = _container.Resolve<Commerce6>();

                            commerce6.ProcessOrder(orderInfo);

                            break;

                        case "7":
                            Console.WriteLine("7 - One-to-many");
                            Console.WriteLine();
                            break;
                        case "8":
                            Console.WriteLine("8 - Post Construction resolve & Property injection");
                            Console.WriteLine();
                            break;

                        case "9":
                            Console.WriteLine("9 - Construction finder");
                            Console.WriteLine();
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
