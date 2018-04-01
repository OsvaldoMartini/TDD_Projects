using System;

namespace Bank.Queue.Oper_2
{
    class ProgramTest
    {
        static void Main(string[] args)
        {
            QueueDemo ThomastonBankandTrust;
            ThomastonBankandTrust = new QueueDemo();
            ThomastonBankandTrust.QueueCustomers();
            // pause
            Console.Read();
        }
    }
}
