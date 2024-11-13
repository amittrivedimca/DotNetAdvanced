using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared.DTO;

namespace OnionArch_CartService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CartController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet(Name = "GetCartItems")]
        public ActionResult<List<CartItemDTO>> GetCartItems(int cartId)
        {
            return Ok(_serviceManager.CartService.GetCartItems(cartId));
        }
    }
}
