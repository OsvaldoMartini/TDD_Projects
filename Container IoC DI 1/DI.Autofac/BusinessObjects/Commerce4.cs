using DI.Autofac.Interfaces;
using DI.Autofac.Models;

namespace DI.Autofac.BusinessObjects
{
    public class Commerce4
    {
            private IProcessorLocator2 _processorLocator2;
            private ISingleTest _singleTester;

            public Commerce4(IProcessorLocator2 processorLocator2, ISingleTest singleTester)
            {
                _processorLocator2 = processorLocator2;
                _singleTester = singleTester;
            }

            public void ProcessOrder(OrderInfo orderInfo)
            {
                IBillingProcess billingProcessor = _processorLocator2.GetProcessor<IBillingProcess>();
                ICustomer customerProcessor = _processorLocator2.GetProcessor<ICustomer>();
                INotifier notifierProcessor = _processorLocator2.GetProcessor<INotifier>();
                ILogger loggerProcessor = _processorLocator2.GetProcessor<ILogger>();

                billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
                loggerProcessor.Log("Billing Processed");
                customerProcessor.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
                loggerProcessor.Log("Customer Updated");
                notifierProcessor.SendReceipt(orderInfo);
                loggerProcessor.Log("Receipt Sent");

                _singleTester.DisplayCounter();

                _processorLocator2.ReleaseScope();
            }

        }
    
}
