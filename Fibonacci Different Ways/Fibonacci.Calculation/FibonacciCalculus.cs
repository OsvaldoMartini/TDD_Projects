using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci.Calculation
{
    public static class FibonacciCalculus
    {
        //Calculation Fibonacci at Positrion
        public static int Fibonacci_Recursive(int position)
        {
            if (position < 0) throw new Exception();
            switch (position)
            {
                case 0:
                    return 0;
                    break;
                case 1:
                    return 1;
                default:
                    return Fibonacci_Recursive(position - 1) + Fibonacci_Recursive(position - 2);
                    break;
            }
        }

        public static int Fibonacci_By_Loop(int position)
        {
            int N, N1, N2;
            if (position < 0) throw new Exception();
            switch (position)
            {
                case 0:
                    return 0;
                break;
                case 1:
                    return 1;
                    break;
                default:
                    N=0;
                    N1=0;
                    N2=1;
                    
                    for (int I = 2; I <= position; I++)
                    {
                        N = N2 + N1;
                        N1 = N2;
                        N2 = N;

                    }

                    return N;
                    break;
            }
        }
    }
}
