using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fibonacci.Calculation;
using NUnit.Framework;
using System.Numerics;
using Fibonacci = Fibonacci.Calculation.FibonacciCalculus;

namespace Fibonacci_Tests
{

    [TestFixture]
    public class TestsFibonacci
    {
        [Test]
        public void LazyApplication_with_Even_Odd()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();


            //Arrange

            //IEnumerable<int> infinite = new List<long>(ListGenerator.GetInfiniteRandomNumbers());
            //Load All qhen appplication Starts

            //Actions
            IList<int> evens = new List<int>(ListGenerator.EvenNumbers());
            IList<int> primes = new List<int>(ListGenerator.PrimeNumbers());
            IList<BigInteger> fibsBigInteger = new List<BigInteger>(ListGenerator.FibonacciBigIntegerNumbers(1000));
            IList<int> fibsInteger = new List<int>(ListGenerator.FibonacciNumbersInteger(1000));

            ////Load All qhen appplication Starts
            IList<int> evensLazy = new LazyList<int>(LazyListGenerator.EvenNumbers());
            IList<int> primesLazy = new LazyList<int>(LazyListGenerator.PrimeNumbers());
            IList<BigInteger> fibsBigIntegerLazy =
                new LazyList<BigInteger>(LazyListGenerator.FibonacciBigIntegerNumbers(1000));
            IList<int> fibsIntegerLazy = new LazyList<int>(LazyListGenerator.FibonacciNumbersInteger(1000));

            sw.Stop();


            //Asserts

            Assert.Pass();

        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(4, 3)]
        [TestCase(5, 5)]
        [TestCase(6, 8)]
        [TestCase(10,55)]

        public void Fibonacci_Test_Recursive(int input, int expected)
        {
            //Arrange

            //Action
            int result = FibonacciCalculus.Fibonacci_Recursive(input);

            //Assert
            Assert.AreEqual(expected, result);
        }


        [Test]
        [TestCase(10, 55)]
        [TestCase(34, 5702887)]
        public void Fibonacci_AtPosition_Recursive(int input, int expected)
        {
            //Arrange

            //Action
            int result = FibonacciCalculus.Fibonacci_Recursive(input);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(10, 55)]
        [TestCase(34, 5702887)]
        public void Fibonacci_AtPosition_ByLoop(int input, int expected)
        {
            //Arrange

            //Action
            int result = FibonacciCalculus.Fibonacci_By_Loop(input);

            //Assert
            Assert.AreEqual(expected, result);
        }


        [Test]
        [TestCase(10, 10)]
        public void Fibonacci_Return_List_Integers(int input, int expected)
        {
            //Arrange

            //Action
            var result = new List<int>(ListGenerator.FibonacciNumbersInteger(input));

            //Assert
            Assert.AreEqual(expected, result.Count);
        }

        [Test]
        [TestCase(new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 }, 10)]
        public void Fibonacci_Check_Return_Values(int[] expected, int sizeFibo)
        {
            //Arrange

            //Action
            var result = new List<int>(ListGenerator.FibonacciNumbersInteger(sizeFibo));

            //Assert
            Assert.That(expected, Is.EquivalentTo(result));
        }

    }
}
