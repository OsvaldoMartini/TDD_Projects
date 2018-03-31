using DI.Autofac.Models;

namespace DI.Autofac.Interfaces
{
    public interface INotifierSuffixID
    {
        void SendReceipt(OrderInfo orderInfo);
    }
}
