using DI.Unity.Models;

namespace DI.Unity.Interfaces
{
    public interface INotifier
    {
        void SendReceipt(OrderInfo orderInfo);
    }
}
