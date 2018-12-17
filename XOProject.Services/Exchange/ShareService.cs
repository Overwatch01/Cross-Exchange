using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XOProject.Repository.Domain;
using XOProject.Repository.Exchange;

namespace XOProject.Services.Exchange
{
    public class ShareService : GenericService<HourlyShareRate>, IShareService
    {
        public ShareService(IShareRepository shareRepository) : base(shareRepository)
        {
        }

        public async Task<IList<HourlyShareRate>> GetBySymbolAsync(string symbol)
        {
            return await EntityRepository
                .Query()
                .Where(x => x.Symbol.Equals(symbol))
                .ToListAsync();
        }

        public async Task<HourlyShareRate> GetHourlyAsync(string symbol, DateTime dateAndHour)
        {
            var date = dateAndHour.Date;
            var hour = dateAndHour.Hour;

            return await EntityRepository
                .Query()
                .Where(x => x.Symbol.Equals(symbol)
                            && x.TimeStamp.Date == date
                            && x.TimeStamp.Hour == hour)
                .FirstOrDefaultAsync();
        }

        public async Task<HourlyShareRate> GetLastPriceAsync(string symbol)
        {
            var share = await EntityRepository
                .Query()
                .Where(x => x.Symbol.Equals(symbol))
                .OrderByDescending(x => x.TimeStamp)
                .FirstOrDefaultAsync();
            return share;
        }

        public async Task<HourlyShareRate> UpdateLastPriceAsync(string symbol, decimal rate)
        {

            var share = await EntityRepository
                .Query()
                .Where(x => x.Symbol.Equals(symbol))
                .OrderByDescending(x => x.Rate)
                .FirstOrDefaultAsync();

            if (share == null)
            {
                return null;
            }

            share.Rate = rate;
            await EntityRepository.UpdateAsync(share);

            return share;
        }
    }
}
