using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountStoreReact.Services
{
    public class ShopService : IShopService
    {
        private List<Item> _items = new() { new Item("Vase", 1.2m), new Item("Big mug", 1, new Discount("2 for 1.5€", 0.25m, 2)), new Item("Napkins", 0.45m, new Discount("3 for 0.90€", 0.33m, 3)) };

        public ShopService()
        {

        }

        public List<Item> GetList()
        {
            return _items;
        }
    }
}
