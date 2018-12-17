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
            // TODO: Add implementation for the daily summary
            throw new NotImplementedException();
        }

        public async Task<AnalyticsPrice> GetWeeklyAsync(string symbol, int year, int week)
        {
            // TODO: Add implementation for the weekly summary
            throw new NotImplementedException();
        }

        public async Task<AnalyticsPrice> GetMonthlyAsync(string symbol, int year, int month)
        {
            // TODO: Add implementation for the monthly summary
            throw new NotImplementedException();
        }
    }
}