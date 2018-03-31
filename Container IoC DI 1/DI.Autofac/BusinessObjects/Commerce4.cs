using DI.Autofac.Interfaces;
using DI.Autofac.Models;

namespace DI.Autofac.BusinessObjects
{
    public class Commerce4
    {
            private IProcessorLocatorScope _processorLocatorScope;
            private ISingleTest _singleTester;

            public Commerce4(IProcessorLocatorScope processorLocatorScope, ISingleTest singleTester)
            {
                _processorLocatorScope = processorLocatorScope;
                _singleTester = singleTester;
            }

            public void ProcessOrder(OrderInfo orderInfo)
            {
                IBillingProcessSuffixID billingProcessor = _processorLocatorScope.GetProcessor<IBillingProcessSuffixID>();
                ICustomerSuffixID customerProcessor = _processorLocatorScope.GetProcessor<ICustomerSuffixID>();
                INotifierSuffixID notifierProcessor = _processorLocatorScope.GetProcessor<INotifierSuffixID>();
                ILoggerSuffixID loggerProcessor = _processorLocatorScope.GetProcessor<ILoggerSuffixID>();

                billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
                loggerProcessor.Log("Billing Processed");
                customerProcessor.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
                loggerProcessor.Log("Customer Updated");
                notifierProcessor.SendReceipt(orderInfo);
                loggerProcessor.Log("Receipt Sent");

                _singleTester.DisplayCounter();

                _processorLocatorScope.ReleaseScope();
            }

        }
    
}
