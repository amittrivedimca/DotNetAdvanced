﻿using Application;
using Application.CartAL;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingCartRestAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IApplicationManager _applicationManager;
        public CartController(IApplicationManager applicationManager)
        {
            _applicationManager = applicationManager;
        }

        /// <summary>
        /// Get Cart by id
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetCart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CartDTO> GetCart(string cartId)
        {
            var cart = _applicationManager.CartProvider.GetCart(cartId);
            if (cart != null)
            {
                return Ok(cart);
            }
            return NotFound();
        }

        /// <summary>
        /// Get Cart Items by CartId
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetCartItems")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<CartItemDTO>> GetCartItems(string cartId)
        {
            var items = _applicationManager.CartProvider.GetCartItems(cartId);
            if (items != null)
            {
                return Ok(items);
            }
            return NotFound();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cartItem"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]        
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost(Name = "AddCartItem")]
        public ActionResult AddCartItem(CartItemDTO cartItem)
        {
            try
            {
                _applicationManager.CartProvider.AddItem(cartItem);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Delete cart item
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]        
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete(Name = "RemoveCartItem")]
        public ActionResult RemoveCartItem([FromQuery] string cartId, [FromQuery] int itemId)
        {
            try
            {
                _applicationManager.CartProvider.RemoveItem(cartId, itemId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
