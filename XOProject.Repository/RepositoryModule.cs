using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using XOProject.Repository.Exchange;

namespace XOProject.Repository
{
    public static class RepositoryModule
    {
        public static void Register(IServiceCollection services, string connection, string migrationsAssembly)
        {
            services.AddDbContext<ExchangeContext>(options => options.UseSqlServer(connection, builder => builder.MigrationsAssembly(migrationsAssembly)));
            services.AddTransient<IShareRepository, ShareRepository>();
            services.AddTransient<IPortfolioRepository, PortfolioRepository>();
            services.AddTransient<ITradeRepository, TradeRepository>();
        }
    }
}