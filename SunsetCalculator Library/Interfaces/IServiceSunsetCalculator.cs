using System;

namespace SunsetCalculator_Library.Interfaces
{
    public interface IServiceSunsetCalculator
    {
        DateTime GetSunset(DateTime date);
        DateTime GetSunrise(DateTime date);

    }
}
