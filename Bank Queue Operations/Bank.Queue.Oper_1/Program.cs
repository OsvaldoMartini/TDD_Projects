using System;
using Bank.Queue.Oper_1.Concrete;

namespace Bank.Queue.Oper_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a Bank
            Bank ThomastonBankandTrust = new Bank();
            // create a customer
            BankCustomer JP = new BankCustomer("J P Morgan", Bank.BankingActivity.deposit.ToString(), 335445, 30000);
            // add the customer to the TellerLine
            ThomastonBankandTrust.localBankQueue.Enqueue(JP);
            BankCustomer Butch = new BankCustomer("Butch Cassidy", Bank.BankingActivity.transferFunds.ToString(), 555445, 3500);
            BankCustomer Sundance = new BankCustomer("Sundance Kid", Bank.BankingActivity.withdrawl.ToString(), 555444, 3500);
            BankCustomer John = new BankCustomer("John Dillinger", Bank.BankingActivity.withdrawl.ToString(), 12345, 2000);
            ThomastonBankandTrust.localBankQueue.Enqueue(Sundance);
            ThomastonBankandTrust.localBankQueue.Enqueue(Butch);
            ThomastonBankandTrust.localBankQueue.Enqueue(John);

            Console.WriteLine("Peek: " + ThomastonBankandTrust.localBankQueue.Peek());

            // Pause
            Console.ReadLine();
            ThomastonBankandTrust.QueuePeek(ThomastonBankandTrust.localBankQueue);
            // View the queue using a copy 
            ThomastonBankandTrust.QueueContentsCopy(ThomastonBankandTrust.localBankQueue);
            // view the queue through enumeration 
            ThomastonBankandTrust.QueueContentsEnum(ThomastonBankandTrust.localBankQueue);

            // Pause
            Console.ReadLine();
            // verify that the origional queue is not modified.
            Console.WriteLine("Count of items in queue after copy & enum :" + ThomastonBankandTrust.localBankQueue.Count.ToString());
            do
            {
                BankCustomer nextInLine = new BankCustomer();
                nextInLine = (BankCustomer)ThomastonBankandTrust.localBankQueue.Dequeue();
                ThomastonBankandTrust.ProcessCustomerRequest(nextInLine);
                // Pause
                Console.ReadLine();
            } while (ThomastonBankandTrust.localBankQueue.Count != 0);

            // Pause
            Console.ReadLine();

        }
    }
}
