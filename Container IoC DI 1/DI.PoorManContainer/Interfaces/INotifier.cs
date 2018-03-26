using DI.PoorMainContainer.Models;

namespace DI.PoorMainContainer.Interfaces
{
    public interface INotifier
    {
        void SendReceipt(OrderInfo orderInfo);
    }
}
