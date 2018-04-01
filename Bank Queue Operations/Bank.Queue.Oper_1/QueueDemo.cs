using System;
using Bank.Queue.Oper_1.Concrete;
using DefinedQueue = System.Collections.Queue;
// needed for Queue 
namespace Bank.Queue.Oper_1
{
    public class Bank
    {
        public DefinedQueue localBankQueue = new DefinedQueue();
        public int AmountOnDeposit = 10000;
        public enum BankingActivity
        { deposit, withdrawl, transferFunds };


        public void QueueContentsCopy(DefinedQueue localQueue)
        {
            BankCustomer tempCustomer = new BankCustomer();
            DefinedQueue copyoflocalQueue = new DefinedQueue();
            // make the copy 
            copyoflocalQueue = (DefinedQueue)localQueue.Clone();
            Console.WriteLine(" ");
            Console.WriteLine("View the queue using a copy");
            do
            {
                tempCustomer = (BankCustomer)copyoflocalQueue.Dequeue();
                Console.WriteLine("Name: " + tempCustomer.name + ",  Activity: " + tempCustomer.bankingActivity + ",  Account no: " + tempCustomer.accountNumber.ToString() + ", Amount $" + tempCustomer.amount.ToString());
            } while (copyoflocalQueue.Count != 0);
        }
        public void QueueContentsEnum(DefinedQueue localQueue)
        {
            BankCustomer tempCustomer = new BankCustomer();
            // get the built in enumerator
            System.Collections.IEnumerator en = localQueue.GetEnumerator();
            Console.WriteLine(" ");
            Console.WriteLine("View the queue using an enumerator");
            while (en.MoveNext())
            {
                tempCustomer = (BankCustomer)en.Current;
                Console.WriteLine("Name: " + tempCustomer.name + ",  Activity: " + tempCustomer.bankingActivity + ",  Account no: " + tempCustomer.accountNumber.ToString() + ", Amount $" + tempCustomer.amount.ToString());

            }
        }
        public void QueuePeek(DefinedQueue localQeue)
        {
            BankCustomer tempCustomer = new BankCustomer();
            tempCustomer = (BankCustomer)localQeue.Peek();
            Console.WriteLine("The next Customer in line: " + tempCustomer.name);
        }

        public void ProcessCustomerRequest(BankCustomer customer)
        {
            Console.WriteLine("Customer: " + customer.name);
            Console.WriteLine("Activity: " + customer.bankingActivity);
            if ((customer.bankingActivity == "deposit") | customer.bankingActivity == "transferFunds")
            {
                AmountOnDeposit += customer.amount;
                Console.WriteLine("Amount on Deposit: " + AmountOnDeposit);
            }
            if (customer.bankingActivity == "withdrawl" && (customer.name != "John Dillinger"))
            {
                AmountOnDeposit -= customer.amount;
                Console.WriteLine("Amount on Deposit: " + AmountOnDeposit);
            }
            if ((customer.bankingActivity == "withdrawl") && (customer.name == "John Dillinger"))
            {
                AmountOnDeposit = 0;
                Console.WriteLine("Big Bank Robery !!!    Amount on Deposit: " + AmountOnDeposit);
            }
            Console.WriteLine("------------------------------------------------");
        }
    }
}
