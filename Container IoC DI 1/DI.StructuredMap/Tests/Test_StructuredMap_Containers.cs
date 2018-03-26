﻿using NUnit.Framework;

namespace DI.StructuredMap.Tests
{
    [TestFixture]
    class Test_StructuredMap_Containers
    {
        //private StructuredMap SomeContainer;

        [SetUp]
        public void Init()
        {
            //_container = new StructuredMap();
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
    }
}
