using System;
using DI.PoorMainContainer.Interfaces;
using DI.PoorMainContainer.Models;

namespace DI.PoorMainContainer.Concrete
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
