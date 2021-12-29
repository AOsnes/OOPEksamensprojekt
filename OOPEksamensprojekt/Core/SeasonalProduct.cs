using System;

namespace OOPEksamensprojekt.Core
{
    public class SeasonalProduct : Product
    {
        public DateTime SeasonStartDate { get; private set; }
        public DateTime SeasonEndDate { get; private set; }
        
        public SeasonalProduct(DateTime seasonStartDate, DateTime seasonEndDate, int id, string name, decimal price, bool active) : base(id, name, price, active)
        {
            SeasonStartDate = seasonStartDate;
            SeasonEndDate = seasonEndDate;
        }
        
    }
}