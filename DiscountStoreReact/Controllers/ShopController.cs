using DiscountStoreReact.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountStoreReact.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ShopController : ControllerBase
    {
        private IShopService _ShopService;

        public ShopController(IShopService ShopService)
        {
            _ShopService = ShopService;
        }

        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return _ShopService.GetList();
        }
    }
}
