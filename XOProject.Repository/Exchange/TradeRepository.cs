using XOProject.Repository.Domain;

namespace XOProject.Repository.Exchange
{
    public class TradeRepository : GenericRepository<Trade>, ITradeRepository
    {
        public TradeRepository(ExchangeContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}