using System;

namespace CalculatorLibrary.Interfaces
{
    public interface IGetServices
    {
        string GetServiceDate(DateTime date);
        string GetServiceQtdMovies(string value);
    }
}
