using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountStoreReact.Services
{
    public class CartService : ICartService
    {
        private Dictionary<Guid, Item> _items = new Dictionary<Guid, Item>();

        public void Add(Item item)
        {
            if (_items.TryGetValue(item.Id, out Item found))
            {
                found.Count += 1;
                return;
            }
            item.Count = 1;
            _items.Add(item.Id, item);
        }

        public void Remove(Guid itemId)
        {
            if (_items.TryGetValue(itemId, out Item found))
            {
                if (found.Count <= 1)
                {
                    _items.Remove(itemId);
                    return;
                }
                found.Count -= 1;
            }
        }

        public decimal GetTotal()
        {
            decimal totalPrice = 0;
            foreach (Item item in _items.Values)
            {
                if (item.Discount == null)
                {
                    totalPrice += item.Price * item.Count;
                    continue;
                }
                int notApplicableCount = item.Count % item.Discount.ApplicableCount;
                int applicableCount = item.Count - notApplicableCount;
                totalPrice += item.Price * notApplicableCount + (applicableCount * item.Price * (1 - item.Discount.DiscountPercentage));
            }
            return Math.Round(totalPrice, 2);
        }

        public List<Item> GetList()
        {
            return _items.Values.ToList();
        }
    }
}
