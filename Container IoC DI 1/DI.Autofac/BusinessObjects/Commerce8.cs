using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using DI.Autofac.Concrete;
using DI.Autofac.Interfaces;
using DI.Autofac.Models;

namespace DI.Autofac.BusinessObjects
{
    public class Commerce8
    {
        //Second Case the AutoFac will inject this properties
        public IProcessorLocatorGeneric _ProcessorLocatorGeneric { get; set; }
        public IEnumerable<IPostOrderPlugin> _Plugins { get; set; }
        public Commerce8()
        {
            //When you finally get newing up, go ahead and Resolve the Process
            //Recursive process to find teh property and find the Dependency Injection
            //First Case UnCommented the code Below
            //Second Case Just Let commented
            //Program._container.InjectProperties(this);
        }

        public void ProcessOrder(OrderInfo orderInfo)
        {
            IBillingProcessSuffixID billingProcessor = _ProcessorLocatorGeneric.GetProcessor<IBillingProcessSuffixID>();
            ICustomerSuffixID customerProcessor = _ProcessorLocatorGeneric.GetProcessor<ICustomerSuffixID>();
            INotifierSuffixID notifierProcessor = _ProcessorLocatorGeneric.GetProcessor<INotifierSuffixID>();
            ILoggerSuffixID loggerProcessor = _ProcessorLocatorGeneric.GetProcessor<ILoggerSuffixID>();

            billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            loggerProcessor.Log("Billing Processed");
            customerProcessor.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            loggerProcessor.Log("Customer Updated");
            notifierProcessor.SendReceipt(orderInfo);
            loggerProcessor.Log("Receipt Sent");

            foreach (IPostOrderPlugin plugin in _Plugins)
            {
                plugin.DoSomething();

            }

        }
    }
}
