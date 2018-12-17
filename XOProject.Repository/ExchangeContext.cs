using System;
using Microsoft.EntityFrameworkCore;
using XOProject.Repository.Domain;

namespace XOProject.Repository
{
    public class ExchangeContext : DbContext
    {
        private readonly IDataSeed _dataSeed;

        public ExchangeContext(IDataSeed dataSeed)
        {
            _dataSeed = dataSeed;
        }

        public ExchangeContext(DbContextOptions<ExchangeContext> options, IDataSeed dataSeed) : base(options)
        {
            _dataSeed = dataSeed;
        }


        public DbSet<Portfolio> Portfolios { get; set; }

        public DbSet<Trade> Trades { get; set; }

        public DbSet<HourlyShareRate> Shares { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Portfolio>().HasData(_dataSeed.GetPortfolios());
            modelBuilder.Entity<HourlyShareRate>().HasData(_dataSeed.GetRates());
            modelBuilder.Entity<Trade>().HasData(_dataSeed.GetTrades());

            base.OnModelCreating(modelBuilder);
        }
        
    }
}
