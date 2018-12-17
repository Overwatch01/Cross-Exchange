using XOProject.Repository.Domain;

namespace XOProject.Repository.Exchange
{
    public class ShareRepository : GenericRepository<HourlyShareRate>, IShareRepository
    {
        public ShareRepository(ExchangeContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}