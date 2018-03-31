namespace DI.Autofac.Interfaces
{
    public interface IBillingProcessSuffixID
    {
        void ProcessPayment(string customer, string creditCard, double price);
    }
}
