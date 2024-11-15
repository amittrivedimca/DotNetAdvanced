using Domain.Entities;
using Shared.DTO;

namespace Services
{
    internal static class ExtentionMethods
    {
        public static CartItem ToCartItem(this CartItemDTO cartDTO)
        {
            CartItem cartItem = new CartItem()
            {
                ItemId = cartDTO.ItemId,
                Name = cartDTO.Name,
                Price = cartDTO.Price,
                Quantity = cartDTO.Quantity
            };

            if (cartDTO.ItemImage != null)
            {
                cartItem.ItemImage = new ItemImageInfo()
                {
                    Url = cartDTO.ItemImage.Url,
                    AltText = cartDTO.ItemImage.AltText,
                };
            }
            return cartItem;
        }

        public static CartItemDTO ToCartItemDTO(this CartItem cartItem,int cartId)
        {
            CartItemDTO cartItemDTO = new CartItemDTO()
            {
                CartId = cartId,
                ItemId = cartItem.ItemId,
                Name = cartItem.Name,
                Price = cartItem.Price,
                Quantity = cartItem.Quantity
            };

            if (cartItem.ItemImage != null)
            {
                cartItemDTO.ItemImage = new ItemImageInfoDTO()
                {
                    Url = cartItem.ItemImage.Url,
                    AltText = cartItem.ItemImage.AltText,
                };
            }
            return cartItemDTO;
        }
    }
}
