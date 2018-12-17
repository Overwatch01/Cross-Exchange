using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XOProject.Api.Model;
using XOProject.Repository.Domain;
using XOProject.Services.Exchange;

namespace XOProject.Api.Controller
{
    [Route("api/portfolio")]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [HttpGet("{portfolioId}")]
        public async Task<IActionResult> GetPortfolio([FromRoute]int portfolioId)
        {
            var portfolio = await _portfolioService.GetByIdAsync(portfolioId);

            if (portfolio == null)
            {
                return NotFound();
            }
            
            return Ok(Map(portfolio));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PortfolioModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var portfolio = Map(value);
            await _portfolioService.InsertAsync(portfolio);

            return Created($"Portfolio/{portfolio.Id}", Map(portfolio));
        }

        private PortfolioModel Map(Portfolio portfolio)
        {
            return new PortfolioModel()
            {
                Id = portfolio.Id,
                Name = portfolio.Name
            };
        }

        private Portfolio Map(PortfolioModel portfolio)
        {
            return new Portfolio()
            {
                Id = portfolio.Id,
                Name = portfolio.Name
            };
        }
    }
}
