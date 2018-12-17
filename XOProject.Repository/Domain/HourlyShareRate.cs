using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace XOProject.Repository.Domain
{
    public class HourlyShareRate
    {
        public int Id { get; set; }

        public DateTime TimeStamp { get; set; }

        public string Symbol { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Rate { get; set; }
    }
}
