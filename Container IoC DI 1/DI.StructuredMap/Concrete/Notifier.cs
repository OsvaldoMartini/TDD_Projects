using System;
using DI.StructuredMap.Interfaces;
using DI.StructuredMap.Models;

namespace DI.StructuredMap.Concrete
{
    public class Notifier:INotifier
    {
        //send email to customer with receipt
        public void SendReceipt(OrderInfo orderInfo)
        {
            Console.WriteLine(string.Format("Receipt sent to customer '{0}' via email.", DateTime.Now,
                orderInfo));

        }
    }
}
