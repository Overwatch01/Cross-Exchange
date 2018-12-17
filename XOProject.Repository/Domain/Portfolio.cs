using System.Collections.Generic;

namespace XOProject.Repository.Domain
{
    public class Portfolio
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public List<Trade> Trades { get; set; }
    }
}