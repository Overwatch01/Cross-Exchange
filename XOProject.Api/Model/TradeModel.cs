using System.ComponentModel.DataAnnotations;

namespace XOProject.Api.Model
{
    public class TradeModel
    {
        [Required]
        public string Symbol { get; set; }

        [Required]
        public int NoOfShares { get; set; }

        [Required]
        public int PortfolioId { get; set; }

        public string Action { get; set; }
    }
}