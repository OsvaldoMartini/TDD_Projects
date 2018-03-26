using DI.Abstraction.BusinessObjects;
using DI.Abstraction.Interfaces;
using DI.Abstraction.Models;
using Moq;
using NUnit.Framework;

namespace Container.IoC.DI
{
    [TestFixture]
    public class Mocking_Tests
    {
        [Test]

        public void MockingObjects_DI_Abstraction()
        {
            //Arrange
            Mock<IBillingProcessor> mockBilling = new Mock<IBillingProcessor>();
            Mock<ICustomer> mockCustomer = new Mock<ICustomer>();
            Mock<INotifier> mockNotifier = new Mock<INotifier>();
            Mock<ILogger> mockLogger = new Mock<ILogger>();

            mockBilling.Setup(obj => obj.ProcessPayment(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<double>()));
            mockCustomer.Setup(obj => obj.UpdateCustomerOrder(It.IsAny<string>(), It.IsAny<string>()));
            mockNotifier.Setup(obj => obj.SendReceipt(It.IsAny<OrderInfo>()));
            mockLogger.Setup(obj => obj.Log(It.IsAny<string>()));


            //Action
            Commerce commerce = new Commerce(mockBilling.Object,mockCustomer.Object, mockNotifier.Object, mockLogger.Object);

            commerce.ProcessOrder(new OrderInfo());

            //Assert
            Assert.IsTrue(1 == 1); //this Test just asserts that ProcessOrder can be called
        }

    }
}
