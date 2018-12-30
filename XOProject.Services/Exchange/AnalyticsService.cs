using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XOProject.Repository.Domain;
using XOProject.Repository.Exchange;
using XOProject.Services.Domain;

namespace XOProject.Services.Exchange
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly IShareRepository _shareRepository;

        public AnalyticsService(IShareRepository shareRepository)
        {
            _shareRepository = shareRepository;
        }

        public async Task<AnalyticsPrice> GetDailyAsync(string symbol, DateTime day)
        {
            var analyticsPrice = new AnalyticsPrice();
            var date = day.Date;

            var price = await _shareRepository
                .Query()
                .Where(x => x.Symbol.Equals(symbol)
                            && x.TimeStamp.Date == date)
                .ToListAsync();

            analyticsPrice.Open = price.OrderBy(x => x.TimeStamp).FirstOrDefault().Rate;
            analyticsPrice.High = price.Max(x => x.Rate);
            analyticsPrice.Open = price.Min(x => x.Rate);
            analyticsPrice.Close = price.OrderByDescending(x => x.TimeStamp).FirstOrDefault().Rate;
                       
            return analyticsPrice;
        }

        public async Task<AnalyticsPrice> GetWeeklyAsync(string symbol, int year, int week)
        {
            var analyticsPrice = new AnalyticsPrice();
            DateTime date = GetFirstDateOfWeekByWeekNumber(year, week);
            
            var price = await _shareRepository
                .Query()
                .Where(x => x.Symbol.Equals(symbol)
                            && x.TimeStamp.Date >= date && x.TimeStamp.Date <= date.AddDays(7))
                .ToListAsync();

            analyticsPrice.Open = price.OrderBy(x => x.TimeStamp).FirstOrDefault().Rate;
            analyticsPrice.High = price.Max(x => x.Rate);
            analyticsPrice.Open = price.Min(x => x.Rate);
            analyticsPrice.Close = price.OrderByDescending(x => x.TimeStamp).FirstOrDefault().Rate;

            return analyticsPrice;
        }

        public async Task<AnalyticsPrice> GetMonthlyAsync(string symbol, int year, int month)
        {
            var analyticsPrice = new AnalyticsPrice();

            var price = await _shareRepository
                .Query()
                .Where(x => x.Symbol.Equals(symbol)
                            && x.TimeStamp.Year == year && x.TimeStamp.Month == month).ToListAsync();

            analyticsPrice.Open = price.OrderBy(x => x.TimeStamp).FirstOrDefault().Rate;
            analyticsPrice.High = price.Max(x => x.Rate);
            analyticsPrice.Open = price.Min(x => x.Rate);
            analyticsPrice.Close = price.OrderByDescending(x => x.TimeStamp).FirstOrDefault().Rate;

            return analyticsPrice;
        }

        private DateTime GetFirstDateOfWeekByWeekNumber(int year, int weekNumber)
        {
            var date = new DateTime(year, 01, 01);
            var firstDayOfYear = date.DayOfWeek;
            var result = date.AddDays(weekNumber * 7);

            if (firstDayOfYear == DayOfWeek.Monday)
                return result.Date;
            if (firstDayOfYear == DayOfWeek.Tuesday)
                return result.AddDays(-1).Date;
            if (firstDayOfYear == DayOfWeek.Wednesday)
                return result.AddDays(-2).Date;
            if (firstDayOfYear == DayOfWeek.Thursday)
                return result.AddDays(-3).Date;
            if (firstDayOfYear == DayOfWeek.Friday)
                return result.AddDays(-4).Date;
            if (firstDayOfYear == DayOfWeek.Saturday)
                return result.AddDays(-5).Date;
            return result.AddDays(-6).Date;
        }
    }
}