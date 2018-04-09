using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fibonacci.Calculation;
using NUnit.Framework;
using System.Numerics;

namespace Fibonacci.Tests
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
            IList<BigInteger> fibsBigIntegerLazy = new LazyList<BigInteger>(LazyListGenerator.FibonacciBigIntegerNumbers(1000));
            IList<int> fibsIntegerLazy = new LazyList<int>(LazyListGenerator.FibonacciNumbersInteger(1000));

            sw.Stop();
            

            //Asserts

            Assert.Pass();

          


        }

    }
}
