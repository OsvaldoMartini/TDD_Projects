using DI.Autofac.Models;

namespace DI.Autofac.Interfaces
{
    public interface INotifier
    {
        void SendReceipt(OrderInfo orderInfo);
    }
}
