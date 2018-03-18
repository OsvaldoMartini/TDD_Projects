using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
