using System;
using DI.Autofac.Interfaces;
using DI.Autofac.Models;

namespace DI.Autofac.Concrete
{
    public class NotifierSufixoID:INotifierSufixoID
    {
        //send email to customer with receipt
        public void SendReceipt(OrderInfo orderInfo)
        {
            Console.WriteLine(string.Format("Receipt sent to customer '{0}' via email.", DateTime.Now,
                orderInfo));

        }
    }
}
