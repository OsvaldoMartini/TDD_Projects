using System;
using DI.Coupled.Models;

namespace DI.Coupled
{
    public class Notifier
    {
        //send email to customer with receipt
        public void SendReceipt(OrderInfo orderInfo)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Receipt sent to customer '{0}' via email.", DateTime.Now,
                orderInfo));

        }
    }
}
