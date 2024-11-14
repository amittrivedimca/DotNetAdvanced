using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared.DTO;

namespace OnionArch_CartService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CartController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet(Name = "InitCart")]
        public ActionResult InitCart()
        {
            _serviceManager.CartService.InitCart();
            return Ok();
        }

        [HttpGet(Name = "GetCartItems")]
        public ActionResult<List<CartItemDTO>> GetCartItems(int cartId)
        {
            return Ok(_serviceManager.CartService.GetCartItems(cartId));
        }

        [HttpPost(Name = "AddCartItem")]
        public ActionResult AddCartItem(CartItemDTO cartItem)
        {
            _serviceManager.CartService.AddItem(cartItem);
            return Ok();
        }

        [HttpPost(Name = "RemoveCartItem")]        
        public ActionResult RemoveCartItem([FromQuery]int cartId, [FromQuery]int itemId)
        {
            _serviceManager.CartService.RemoveItem(cartId,itemId);
            return Ok();
        }
    }
}
