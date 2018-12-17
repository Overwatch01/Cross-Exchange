using System;
using Microsoft.Extensions.DependencyInjection;
using XOProject.Services.Exchange;

namespace XOProject.Services
{
    public static class ServicesModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IShareService, ShareService>();
            services.AddTransient<IPortfolioService, PortfolioService>();
            services.AddTransient<ITradeService, TradeService>();
            services.AddTransient<IAnalyticsService, AnalyticsService>();
        }
    }
}
