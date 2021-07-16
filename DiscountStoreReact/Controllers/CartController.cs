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
    public class CartController : ControllerBase
    {
        private ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return _cartService.GetList();
        }

        [HttpGet("price")]
        public decimal Price()
        {
            return _cartService.GetTotal();
        }

        [HttpPost]
        public string Add([FromBody] Item item)
        {
            _cartService.Add(item);
            return "Added";
        }

        [HttpDelete]
        public string Delete([FromBody] Guid itemId)
        {
            _cartService.Remove(itemId);
            return "Removed";
        }
    }
}
