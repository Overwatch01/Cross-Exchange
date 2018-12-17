using System;
using System.Threading.Tasks;
using XOProject.Services.Domain;

namespace XOProject.Services.Exchange
{
    public interface IAnalyticsService
    {
        Task<AnalyticsPrice> GetDailyAsync(string symbol, DateTime day);
        Task<AnalyticsPrice> GetWeeklyAsync(string symbol, int year, int week);
        Task<AnalyticsPrice> GetMonthlyAsync(string symbol, int year, int month);
    }
}
