using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountStoreReact.Services
{
    public class Item
    {
        public Item() { }

        public Item(string sku, decimal price)
        {
            Sku = sku;
            Price = price;
        }

        public Item(string sku, decimal price, Discount discount) : this(sku, price)
        {
            Discount = discount;
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public Discount Discount { get; set; }
    }
}
