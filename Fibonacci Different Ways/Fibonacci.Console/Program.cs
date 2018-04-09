using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Fibonacci.Calculation;

namespace Fibonacci.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            LazyApplication_with_Even_Odd();
        }

        public static void LazyApplication_with_Even_Odd()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();


            //IEnumerable<int> infinite = new List<long>(ListGenerator.GetInfiniteRandomNumbers());

            //Load All when appplication Starts
            IList<int> primes = new List<int>(ListGenerator.PrimeNumbers());
            IList<int> evens = new List<int>(ListGenerator.EvenNumbers());
            IList<int> odds = new List<int>(ListGenerator.OddNumbers());
            IList<BigInteger> fibsBigInteger = new List<BigInteger>(ListGenerator.FibonacciBigIntegerNumbers(1000));
            IList<int> fibsInteger = new List<int>(ListGenerator.FibonacciNumbersInteger(1000));

            ////Load All when appplication Starts
            IList<int> evensLazy = new LazyList<int>(LazyListGenerator.EvenNumbers());
            IList<int> primesLazy = new LazyList<int>(LazyListGenerator.PrimeNumbers());
            IList<BigInteger> fibsBigIntegerLazy = new LazyList<BigInteger>(LazyListGenerator.FibonacciBigIntegerNumbers(1000));
            IList<int> fibsIntegerLazy = new LazyList<int>(LazyListGenerator.FibonacciNumbersInteger(1000));


            sw.Stop();

            System.Console.WriteLine("List created: {0} ", sw.Elapsed);

            //int origWidth = System.Console.WindowWidth;
            //int origHeight = System.Console.WindowHeight;

            int maxWidth = System.Console.LargestWindowWidth;
            int maxHeight = System.Console.LargestWindowHeight;

            if (System.Console.WindowHeight != 300 || System.Console.WindowWidth != 500)
            {
                System.Console.SetWindowSize(maxWidth, maxHeight);
            }

            bool exit = false;
            while (!exit)
            {
                System.Console.WriteLine("P - to print Primes Numbers");
                System.Console.WriteLine("E - to print Even Numbers");
                System.Console.WriteLine("O - to print Odds Numbers");
                System.Console.WriteLine("F - to print Fibonacci BigInteger Number");
                System.Console.WriteLine("I - to print Fibonacci Integer Number");
                System.Console.WriteLine("W - to print a set of Lazy Evens Numbers");
                System.Console.WriteLine("L - to print a set of Lazy Prime Numbers");
                System.Console.WriteLine("0 - Exit");
                System.Console.WriteLine();

                string choice = System.Console.ReadLine().ToUpper();
                if (choice == "0")
                    exit = true;
                else
                {
                
                    //String str = System.Console.ReadKey().ToString().ToUpper();
                    //ConsoleKeyInfo result = System.Console.ReadKey(); //char
                    char result;
                    char.TryParse(choice, out result);
                    //if (result == 'E')
                    switch (choice)
                    {
                        case "P":
                            System.Console.WriteLine(string.Format("Primes Numbers", primes.Count));
                            foreach (int x in primes)
                            {
                                System.Console.WriteLine(x);

                            }

                            break;
                        case "E":
                            System.Console.WriteLine(string.Format("Even Numbers", evens.Count));
                            foreach (int x in evens)
                            {
                                System.Console.WriteLine(x);

                            }

                            break;
                        case "O":
                            System.Console.WriteLine(string.Format("Odds Numbers", odds.Count));
                            foreach (int x in odds)
                            {
                                System.Console.WriteLine(x);

                            }

                            break;
                        case "F":
                            System.Console.WriteLine(string.Format("Fibonacci BigInteger Numbers", fibsBigInteger.Count));
                            foreach (BigInteger x in fibsBigInteger)
                            {
                                System.Console.WriteLine(x);

                            }

                            break;
                        case "I":
                            System.Console.WriteLine(string.Format("Fibonacci Integer Numbers", fibsInteger.Count));
                            foreach (int x in fibsInteger)
                            {
                                System.Console.WriteLine(x);

                            }

                            break;
                        case "W":
                            System.Console.WriteLine(string.Format("Lazy Evens Numbers", evensLazy.Count));
                            foreach (int x in evensLazy)
                            {
                                System.Console.WriteLine(x);

                            }

                            break;
                        case "L":
                            System.Console.WriteLine(string.Format("Lazy Primes Numbers", primesLazy.Count));
                            foreach (int x in primesLazy)
                            {
                                System.Console.WriteLine(x);

                            }

                            break;

                    }

                }

            }

            System.Console.WriteLine("Press 'Enter'");
            System.Console.ReadKey();
            
            System.Environment.Exit(1);


        }

    }
}
