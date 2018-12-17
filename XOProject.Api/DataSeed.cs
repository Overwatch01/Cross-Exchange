using System;
using System.IO;
using Newtonsoft.Json;
using XOProject.Repository;
using XOProject.Repository.Domain;

namespace XOProject.Api
{
    public class DataSeed : IDataSeed
    {
        public Portfolio[] GetPortfolios()
        {
            return JsonConvert.DeserializeObject<Portfolio[]>(File.ReadAllText(Path.Combine("Data","portfolio.json")));
        }

        public Trade[] GetTrades()
        {
            return JsonConvert.DeserializeObject<Trade[]>(File.ReadAllText(Path.Combine("Data", "trade.json")));
        }

        public HourlyShareRate[] GetRates()
        {
            return JsonConvert.DeserializeObject<HourlyShareRate[]>(File.ReadAllText(Path.Combine("Data", "rate.json")));
        }
    }
}