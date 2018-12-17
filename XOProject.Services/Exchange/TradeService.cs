using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XOProject.Repository.Domain;
using XOProject.Repository.Exchange;

namespace XOProject.Services.Exchange
{
    public class TradeService: GenericService<Trade>, ITradeService
    {
        private readonly IShareService _shareService;

        public TradeService(ITradeRepository tradeRepository, IShareService shareService) : base(tradeRepository)
        {
            _shareService = shareService;
        }

        public async Task<IList<Trade>> GetByPortfolioId(int portfolioId)
        {
            return await EntityRepository
                .Query()
                .Where(x => x.PortfolioId.Equals(portfolioId))
                .ToListAsync();
        }

        public async Task<Trade> BuyOrSell(int portfolioId, string symbol, int noOfShares, string action)
        {
            // get the last price
            var price = await _shareService.GetLastPriceAsync(symbol);

            if (price == null)
            {
                return null;
            }

            var trade = new Trade()
            {
                Action = action,
                PortfolioId = portfolioId,
                Symbol = symbol,
                NoOfShares = noOfShares,
                ContractPrice = price.Rate * noOfShares
            };

            await EntityRepository.InsertAsync(trade);
            return trade;
        }
    }
}
