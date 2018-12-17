namespace XOProject.Api.Model.Analytics
{
    public class MonthlyModel
    {
        public string Symbol { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public PriceModel Price { get; set; }
    }
}
