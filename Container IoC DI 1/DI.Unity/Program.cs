using System;
using DI.Unity.BusinessObjects;
using DI.Unity.Concrete;
using DI.Unity.Interfaces;
using DI.Unity.Models;
using Unity;

namespace DI.Unity
{
    class Program
    {
        private static UnityContainer _container;

        static void Main(string[] args)
        {
            Console.WriteLine("Unity DI Container");
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
