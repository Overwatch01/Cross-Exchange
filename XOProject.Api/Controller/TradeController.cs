using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XOProject.Api.Model;
using XOProject.Repository.Domain;
using XOProject.Services.Exchange;

namespace XOProject.Api.Controller
{
    [Route("api/trade")]
    public class TradeController : ControllerBase
    {
        private readonly ITradeService _tradeService;

        public TradeController(ITradeService tradeService)
        {
            _tradeService = tradeService;
        }

        [HttpGet("{portfolioId}")]
        public async Task<IActionResult> GetAllTradings([FromRoute] int portfolioId)
        {
            if (portfolioId <= 0)
            {
                return BadRequest();
            }

            var list = await _tradeService.GetByPortfolioId(portfolioId);

            if (list.Count == 0)
            {
                return NotFound();
            }

            return Ok(Map(list));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TradeModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _tradeService.BuyOrSell(model.PortfolioId, model.Symbol, model.NoOfShares, model.Action);

            return Created($"Trade/{result.PortfolioId}", Map(result));
        }

        private TradeModel Map(Trade trade)
        {
            return new TradeModel()
            {
                Symbol = trade.Symbol,
                Action = trade.Action,
                NoOfShares = trade.NoOfShares,
                PortfolioId = trade.PortfolioId
            };
        }

        private IList<TradeModel> Map(IList<Trade> trades)
        {
            return trades.Select(Map).ToList();
        }
    }
}