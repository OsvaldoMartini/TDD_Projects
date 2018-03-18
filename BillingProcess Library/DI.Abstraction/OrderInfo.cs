using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Abstraction
{
    public class OrderInfo
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string CreditCard { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
    }
}
