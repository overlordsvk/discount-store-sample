using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountStoreReact.Services
{
    public interface IShopService
    {
        List<Item> GetList();
    }
}
