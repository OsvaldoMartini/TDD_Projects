using System;

namespace Calculator.Service.Interfaces
{
    public interface IGetServices
    {
        string GetServiceDate(DateTime date);
        string GetServiceQtdMovies(string value);
    }
}
