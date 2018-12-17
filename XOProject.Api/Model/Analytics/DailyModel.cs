using System;

namespace XOProject.Api.Model.Analytics
{
    public class DailyModel
    {
        public string Symbol { get; set; }
        public DateTime Day { get; set; }
        public PriceModel Price { get; set; }
    }
}
