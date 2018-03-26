using DI.Abstraction.Models;

namespace DI.Abstraction.Interfaces
{
    public interface INotifier
    {
        void SendReceipt(OrderInfo orderInfo);
    }
}
