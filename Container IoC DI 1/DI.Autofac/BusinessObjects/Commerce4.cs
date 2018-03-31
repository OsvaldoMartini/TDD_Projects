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
                IBillingProcess_Scanned billingProcessor = _processorLocator2.GetProcessor<IBillingProcess_Scanned>();
                ICustomer_Scanned customerProcessor = _processorLocator2.GetProcessor<ICustomer_Scanned>();
                INotifier_Scanned notifierProcessor = _processorLocator2.GetProcessor<INotifier_Scanned>();
                ILogger_Scanned loggerProcessor = _processorLocator2.GetProcessor<ILogger_Scanned>();

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
