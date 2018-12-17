using System;
using XOProject.Repository.Domain;
using XOProject.Repository.Exchange;

namespace XOProject.Services.Exchange
{
    public class PortfolioService : GenericService<Portfolio>, IPortfolioService
    {
        public PortfolioService(IPortfolioRepository portfolioRepository) : base(portfolioRepository)
        {
        }
    }
}