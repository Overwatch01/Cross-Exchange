using System.Linq;
using Microsoft.EntityFrameworkCore;
using XOProject.Repository.Domain;

namespace XOProject.Repository.Exchange
{
    public class PortfolioRepository : GenericRepository<Portfolio>, IPortfolioRepository
    {
        public PortfolioRepository(ExchangeContext dbContext)
        {
            DbContext = dbContext;
        }

        public IQueryable<Portfolio> GetAll()
        {
            return DbContext.Portfolios.Include(x => x.Trades).AsQueryable();
        }
    }
}