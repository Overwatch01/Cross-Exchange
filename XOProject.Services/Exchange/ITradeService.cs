using System.Collections.Generic;
using System.Threading.Tasks;
using XOProject.Repository;
using XOProject.Repository.Domain;

namespace XOProject.Services.Exchange
{
    public interface ITradeService : IGenericService<Trade>
    {
        Task<IList<Trade>> GetByPortfolioId(int portfolioId);
        Task<Trade> BuyOrSell(int portfolioId, string symbol, int noOfShares, string action);
    }
}