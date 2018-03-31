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
                IBillingProcessSufixoID billingProcessor = _processorLocator2.GetProcessor<IBillingProcessSufixoID>();
                ICustomerSufixoID customerProcessor = _processorLocator2.GetProcessor<ICustomerSufixoID>();
                INotifierSufixoID notifierProcessor = _processorLocator2.GetProcessor<INotifierSufixoID>();
                ILoggerSufixoID loggerProcessor = _processorLocator2.GetProcessor<ILoggerSufixoID>();

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
