using System.Linq;
using XOProject.Repository.Domain;

namespace XOProject.Repository.Exchange
{
    public interface IPortfolioRepository : IGenericRepository<Portfolio>
    {
        IQueryable<Portfolio> GetAll();
    }
}