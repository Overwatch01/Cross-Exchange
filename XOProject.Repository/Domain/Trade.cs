using System.ComponentModel.DataAnnotations.Schema;

namespace XOProject.Repository.Domain
{
    public class Trade
    {
        public int Id { get; set; }
        
        public string Symbol { get; set; }

        public int NoOfShares { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ContractPrice { get; set; }

        public int PortfolioId { get; set; }
        
        public string Action { get; set; }
    }
}