using System;
using DI.Abstraction.Interfaces;

namespace DI.Abstraction.Concrete
{
    public class Notifier:INotifier
    {
        //send email to customer with receipt
        public void SendReceipt(OrderInfo orderInfo)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Receipt sent to customer '{0}' via email.", DateTime.Now,
                orderInfo));

        }
    }
}
