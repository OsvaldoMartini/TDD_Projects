using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Linq;
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

            //Load All qhen appplication Starts
            IList<int> evens = new List<int>(ListGenerator.EvenNumbers());
            IList<int> primes = new List<int>(ListGenerator.PrimeNumbers());
            IList<BigInteger> fibsBigInteger = new List<BigInteger>(ListGenerator.FibonacciNumbers(1000));
            IList<int> fibsInteger = new List<int>(ListGenerator.FibonacciNumbersInteger(1000));

            ////Load All qhen appplication Starts
            //IList<int> evens = new LazyList<int>(ListGenerator.EvenNumbers());
            //IList<int> primes = new LazyList<int>(ListGenerator.PrimeNumbers());
            //IList<BigInteger> fibsBigInteger = new LazyList<BigInteger>(ListGenerator.FibonacciNumbers(1000));
            //IList<int> fibsInteger = new LazyList<int>(ListGenerator.FibonacciNumbersInteger(1000));


            sw.Stop();

            Console.WriteLine("List created: {0} ", sw.Elapsed);

            //int origWidth = Console.WindowWidth;
            //int origHeight = Console.WindowHeight;

            int maxWidth = Console.LargestWindowWidth;
            int maxHeight = Console.LargestWindowHeight;

            if (Console.WindowHeight != 300 || Console.WindowWidth != 500)
            {
                Console.SetWindowSize(maxWidth, maxHeight);
            }

            while (true)
            {
                Console.WriteLine("Press (P) to print Primes Numbers");
                Console.WriteLine("Press (E) to print Even Numbers");
                Console.WriteLine("Press (F) to print Fibonacci BigInteger Number");
                Console.WriteLine("Press (I) to print Fibonacci Integer Number");
                Console.WriteLine("Press (W) to print a set of Prime Fib Numbers");

                ConsoleKeyInfo result = Console.ReadKey();
                if (result.KeyChar == 'E')
                {
                    Console.WriteLine(string.Format("Primes Numbers", evens));

                    break;
                }
                else if (result.KeyChar == 'P')
                {
                    Console.WriteLine(string.Format("Primes Numbers", primes));

                    break;
                }
                else if (result.KeyChar == 'F')
                {
                    Console.WriteLine(string.Format("Fibonacci Numbers", fibsBigInteger.Count));
                    foreach (BigInteger x in fibsBigInteger)
                    {
                        Console.WriteLine(x);

                    }

                    break;
                }
                else if (result.KeyChar == 'I')
                {
                    Console.WriteLine(string.Format("Fibonacci Numbers", fibsBigInteger.ToList()));
                    break;
                }



            }

            System.Environment.Exit(1);


        }

    }
}
