using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountStoreReact.Services
{
    public class Discount
    {
        public Discount() { }
        public Discount(string description, decimal discountPercentage, int applicableCount)
        {
            Description = description;
            DiscountPercentage = discountPercentage;
            ApplicableCount = applicableCount;
        }

        public string Description { get; set; }
        public decimal DiscountPercentage { get; set; }
        public int ApplicableCount { get; set; }
        public string V1 { get; }
        public decimal V2 { get; }
        public int V3 { get; }
    }
}
