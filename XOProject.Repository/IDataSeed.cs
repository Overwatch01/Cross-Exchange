using System;
using XOProject.Repository.Domain;

namespace XOProject.Repository
{
    public interface IDataSeed
    {
        Portfolio[] GetPortfolios();
        Trade[] GetTrades();
        HourlyShareRate[] GetRates();
    }
}