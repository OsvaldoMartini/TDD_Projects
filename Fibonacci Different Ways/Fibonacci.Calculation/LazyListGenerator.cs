using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci.Calculation
{
    public static class LazyListGenerator
    {
        public static Func<IList<int>> EvenNumbers()
        {

            //BigInteger x = Enumerable.Range(1, 10).Select(i => new BigInteger(i)).Aggregate((total, next) => total * next);
            //int[] y = Array.ConvertAll(x.ToString().ToArray(), a => (int)(a - '0'));
            //System.Diagnostics.Debug.WriteLine(y.Sum());

            List<int> numbers = Enumerable.Range(1, 70).ToList();

            numbers = ShuffleList(numbers); // You can find implementations all over the place.

            var evens = numbers.Where(x => x % 2 == 0).Take(25);
            //var odds = numbers.Where(x => x % 2 == 1).Take(25);

            List<int> list = new List<int>();
            foreach (var even in evens) list.Add(even);
            return list.ToList;
        }


        public static Func<IList<int>> PrimeNumbers()
        {

            //BigInteger x = Enumerable.Range(1, 10).Select(i => new BigInteger(i)).Aggregate((total, next) => total * next);
            //int[] y = Array.ConvertAll(x.ToString().ToArray(), a => (int)(a - '0'));
            //System.Diagnostics.Debug.WriteLine(y.Sum());

            List<int> numbers = Enumerable.Range(1, 70).ToList();

            numbers = ShuffleList(numbers); // You can find implementations all over the place.

            //var evens = numbers.Where(x => x % 2 == 0).Take(25);
            var odds = numbers.Where(x => x % 2 != 0).Take(25);
            var primes = numbers.Where(x => x % 2 == 1).Where(x => x % 2 != 0).Take(25);

            List<int> list = new List<int>();
            foreach (var prime in primes) list.Add(prime);
            return list.ToList;

        }

        public static Func<IList<int>> OddNumbers()
        {

            //BigInteger x = Enumerable.Range(1, 10).Select(i => new BigInteger(i)).Aggregate((total, next) => total * next);
            //int[] y = Array.ConvertAll(x.ToString().ToArray(), a => (int)(a - '0'));
            //System.Diagnostics.Debug.WriteLine(y.Sum());

            List<int> numbers = Enumerable.Range(1, 70).ToList();

            numbers = ShuffleList(numbers); // You can find implementations all over the place.

            //var evens = numbers.Where(x => x % 2 == 0).Take(25);
            var odds = numbers.Where(x => x % 2 != 0).Take(25);

            List<int> list = new List<int>();
            foreach (var odd in odds) list.Add(odd);
            return list.ToList;

        }


        public static Func<IList<BigInteger>> FibonacciBigIntegerNumbers(int n)
        {
            /** BigInteger easily holds the first 1000 numbers in the Fibonacci Sequence. **/
            List<BigInteger> fibonacci = new List<BigInteger>();
            fibonacci.Add(0);
            fibonacci.Add(1);
            BigInteger i = 2;
            while (i < n)
            {
                int first = (int)i - 2;
                int second = (int)i - 1;

                BigInteger firstNumber = fibonacci[first];
                BigInteger secondNumber = fibonacci[second];
                BigInteger sum = firstNumber + secondNumber;
                fibonacci.Add(sum);
                i++;
            }

            //foreach (BigInteger f in fibonacci) { System.Diagnostics.Debug.WriteLine(f); }
            return fibonacci.ToList;
        }

        public static Func<IList<int>> FibonacciNumbersInteger(int n)
        {
            /** Int easily holds the first 1000 numbers in the Fibonacci Sequence. **/
            List<int> fibonacci = new List<int>();
            fibonacci.Add(0);
            fibonacci.Add(1);
            BigInteger i = 2;
            while (i < n)
            {
                int first = (int)i - 2;
                int second = (int)i - 1;

                int firstNumber = fibonacci[first];
                int secondNumber = fibonacci[second];
                int sum = firstNumber + secondNumber;
                fibonacci.Add(sum);
                i++;
            }

            //foreach (int f in fibonacci) { System.Diagnostics.Debug.WriteLine(f); }
            return fibonacci.ToList;
        }

        private static List<E> ShuffleList<E>(List<E> inputList)
        {
            List<E> randomList = new List<E>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList; //return the new random list
        }

    }
}
