using DI.StructuredMap.Models;

namespace DI.StructuredMap.Interfaces
{
    public interface INotifier
    {
        void SendReceipt(OrderInfo orderInfo);
    }
}
