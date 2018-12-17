using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XOProject.Repository;
using XOProject.Repository.Domain;

namespace XOProject.Services.Exchange
{
    public interface IShareService : IGenericService<HourlyShareRate>
    {
        Task<HourlyShareRate> UpdateLastPriceAsync(string symbol, decimal rate);
        Task<HourlyShareRate> GetLastPriceAsync(string symbol);
        Task<IList<HourlyShareRate>> GetBySymbolAsync(string symbol);
        Task<HourlyShareRate> GetHourlyAsync(string symbol, DateTime dateAndHour);
    }
}