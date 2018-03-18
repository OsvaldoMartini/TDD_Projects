using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DI.Abstraction;
using DI.Abstraction.Concrete;
using DI.Abstraction.Interfaces;
using Moq;
using NUnit.Framework;

namespace TDD_Case_2
{
    [TestFixture]
    public class UnitTest
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
