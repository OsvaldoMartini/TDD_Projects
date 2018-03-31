using Autofac;
using DI.Autofac.BusinessObjects;
using DI.Autofac.Concrete;
using DI.Autofac.Interfaces;
using DI.Autofac.Models;
using NUnit.Framework;

namespace DI.Autofac.Tests
{
    [TestFixture]
    class Test_Autofac_Containers
    {
        public static IContainer _container;
        public ContainerBuilder builder;

        [SetUp]
        public void Init()
        {
            builder = new ContainerBuilder();
        }

        //If  I not get "InvalidOperationException" the Test should  fail
        [Test, Order(0)]
        public void Should_Not_Register_Abstract_Type()
        {
            //try
            //{

            //    _container.Register<IBillingProcessor, AbstractBillingProcessor>();
            //    //Not Raise the Expected "Exception"
            //    Assert.Fail();

            //}
            //catch (InvalidOperationException)
            //{
            //    // Expected "Exception" was Throwed
            //    Assert.Pass();
            //}
            //catch (Exception)
            //{
            //    // not raised the right kind of "Exception"
            //    Assert.Fail();

            //}
        }

        [Test, Order(1)]
        public void Registry_Count_Types()
        {
            //Checking If the Container is Registering the Types
            
            //Arrange
            //_container.Register<IBillingProcessor, BillingProcessor>();
            //_container.Register<ICustomer, Customer>();

            //Assert
           // Assert.IsTrue(_container.Register().Count == 2);

        }

        [Test]
        public void Resolve_Type()
        {
            //Checing It the Container is REsolving the Type
            
            //Arrange
            //_container.Register<INotifier, Notifier>();

            //Action
            //INotifier instance = _container.Resolve<INotifier>();
            
            //Assert
            //Assert.IsNotNull(instance);
            //Assert.IsTrue(instance.GetType() == typeof(Notifier));


        }

        [Test]
        public void Should_Resolve_Commerce1()
        {
            //Arrange
            OrderInfo orderInfo = new OrderInfo()
            {
                CustomerName = "Claudia Almeida",
                Email = "claudiabhz@gmail.com",
                Product = "LCD Monitor Smart Samsung",
                Price = 259.00f,
                CreditCard = "1234.5678.9876.5432"
            };

            builder.RegisterType<Commerce1>();
            builder.RegisterType<BillingProcess_Scanned>().As<IBillingProcess_Scanned>();
            builder.RegisterType<Customer_Scanned>().As<ICustomer_Scanned>();
            builder.RegisterType<Notifier_Scanned>().As<INotifier_Scanned>();
            builder.RegisterType<Logger_Scanned>().As<ILogger_Scanned>();

            _container = builder.Build();

            Commerce1 commerce1 = _container.Resolve<Commerce1>();

            //Assert
            Assert.IsNotNull(commerce1);
            Assert.IsTrue(commerce1.GetType() == typeof(Commerce1));
        }
    }
}
