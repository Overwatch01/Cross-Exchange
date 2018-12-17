using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XOProject.Api.Model;
using XOProject.Repository.Domain;
using XOProject.Services.Exchange;

namespace XOProject.Api.Controller
{
    [Route("api/share")]
    public class ShareController : ControllerBase
    {
        private readonly IShareService _shareService;

        public ShareController(IShareService shareService)
        {
            _shareService = shareService;
        }

        [HttpPut("{symbol}/{rate}")]
        public async Task<IActionResult> UpdateLastPrice([FromRoute]string symbol, [FromRoute]decimal rate)
        {
            var updated = await _shareService.UpdateLastPriceAsync(symbol, rate);
            if (updated == null)
            {
                return NotFound();
            }

            return Ok(Map(updated));
        }

        [HttpGet("{symbol}")]
        public async Task<IActionResult> Get([FromRoute] string symbol)
        {
            var list = await _shareService.GetBySymbolAsync(symbol);

            if (list.Count == 0)
            {
                return NotFound();
            }

            return Ok(Map(list));
        }

        [HttpGet("{symbol}/latest")]
        public async Task<IActionResult> GetLatestPrice([FromRoute]string symbol)
        {
            var item = await _shareService.GetLastPriceAsync(symbol);
            return Ok(item.Rate);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]HourlyShareRateModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hourlyShareRate = Map(value);
            await _shareService.InsertAsync(hourlyShareRate);
            return Created($"Share/{hourlyShareRate.Id}", Map(hourlyShareRate));
        }

        private IList<HourlyShareRateModel> Map(IList<HourlyShareRate> rates)
        {
            return rates.Select(Map).ToList();
        }

        private HourlyShareRateModel Map(HourlyShareRate rate)
        {
            return new HourlyShareRateModel()
            {
                Id = rate.Id,
                TimeStamp = rate.TimeStamp,
                Rate = rate.Rate,
                Symbol = rate.Symbol
            };
        }

        private HourlyShareRate Map(HourlyShareRateModel rate)
        {
            return new HourlyShareRate()
            {
                Id = rate.Id,
                TimeStamp = rate.TimeStamp,
                Rate = rate.Rate,
                Symbol = rate.Symbol
            };
        }
    }
}