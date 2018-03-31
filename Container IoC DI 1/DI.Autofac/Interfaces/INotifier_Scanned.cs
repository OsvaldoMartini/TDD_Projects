using DI.Autofac.Models;

namespace DI.Autofac.Interfaces
{
    public interface INotifier_Scanned
    {
        void SendReceipt(OrderInfo orderInfo);
    }
}
