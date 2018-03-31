using DI.Autofac.Models;

namespace DI.Autofac.Interfaces
{
    public interface INotifierSufixoID
    {
        void SendReceipt(OrderInfo orderInfo);
    }
}
