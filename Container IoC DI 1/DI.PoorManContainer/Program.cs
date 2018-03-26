using System;
using DI.PoorMainContainer.BusinessObjects;
using DI.PoorMainContainer.Concrete;
using DI.PoorMainContainer.Interfaces;
using DI.PoorMainContainer.Models;
using Unity;

namespace DI.PoorMainContainer
{
    class Program
    {
        private static UnityContainer _container;

        static void Main(string[] args)
        {
            Console.WriteLine("Poor Man DI Containar");
            Console.WriteLine("");

            //Not Found this Application of Container();
            //Container _container = new Container();
            
            _container = new UnityContainer();

            ////Classes  A, B AND C
            //IUnityContainer objContainer = new UnityContainer();
            //objContainer.RegisterType<User>();
            //objContainer.RegisterType<Idal, MySQLDal>();
            //objContainer.RegisterType<Idal, SQLDal>();
            
            //User userObj = objContainer.Resolve<User>();

            //User userInject1 = new User(new MySQLDal());
            //userInject1.AddByInject();
            //User userInject2 = new User(new SQLDal());
            //userInject2.AddByInject();
            
            _container.RegisterType<IBillingProcessor, BillingProcessor>();
            _container.RegisterType<ICustomer, Customer>();
            _container.RegisterType<INotifier, Notifier>();
            _container.RegisterType<ILogger, Logger>();
            
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

            _container.RegisterType<Commerce>();
            //Stoped to "Newing Up classes"
            Commerce commerce = _container.Resolve<Commerce>();
            commerce.ProcessOrder(orderInfo);

            Console.WriteLine("");
            Console.WriteLine("Press [Enter] to exit...");
            Console.ReadLine();


        }
    }
}
