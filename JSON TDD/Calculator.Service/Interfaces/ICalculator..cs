using System;

namespace Calculator.Service.Interfaces
{
    public interface ICalculator
    {
        DateTime GetSunset(DateTime date);
        DateTime GetSunrise(DateTime date);

    }
}
