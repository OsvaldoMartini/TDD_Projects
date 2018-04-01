namespace Bank.Queue.Oper_1.Concrete
{

    public class BankCustomer
    {

        private string customerName;
        private string customerActivity;
        private int customerNumber;
        private int customerAmount;

        public BankCustomer()
        { }
        public BankCustomer(string name, string bankingActivity, int accountNumber, int amount)
        {
            customerName = name;
            customerActivity = bankingActivity;
            customerNumber = accountNumber;
            customerAmount = amount;
        }
        public string name
        {
            get { return customerName; }
            set { customerName = value; }
        }
        public string bankingActivity
        {
            get { return customerActivity; }
            set { customerActivity = value; }
        }
        public int accountNumber
        {
            get { return customerNumber; }
            set { customerNumber = value; }
        }
        public int amount
        {
            get { return customerAmount; }
            set { customerAmount = value; }
        }
    }


}
