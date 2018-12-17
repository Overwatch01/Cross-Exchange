namespace XOProject.Api.Model.Analytics
{
    public class WeeklyModel
    {
        public int Year { get; set; }
        public int Week { get; set; }
        public string Symbol { get; set; }
        public PriceModel Price { get; set; }
    }
}