namespace DI.Autofac.Interfaces
{
    public interface IBillingProcessSufixoID
    {
        void ProcessPayment(string customer, string creditCard, double price);
    }
}
