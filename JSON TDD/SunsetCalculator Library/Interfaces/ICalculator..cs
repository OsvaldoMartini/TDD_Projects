using System;

namespace CalculatorLibrary.Interfaces
{
    public interface ICalculator
    {
        DateTime GetSunset(DateTime date);
        DateTime GetSunrise(DateTime date);

    }
}
