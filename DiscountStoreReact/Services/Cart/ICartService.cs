using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountStoreReact.Services
{
    public interface ICartService
    {
        void Add(Item item);
        void Remove(Guid itemId);
        decimal GetTotal();
        List<Item> GetList();
    }
}
