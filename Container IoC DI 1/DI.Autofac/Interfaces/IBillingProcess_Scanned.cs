namespace DI.Autofac.Interfaces
{
    public interface IBillingProcess_Scanned
    {
        void ProcessPayment(string customer, string creditCard, double price);
    }
}
