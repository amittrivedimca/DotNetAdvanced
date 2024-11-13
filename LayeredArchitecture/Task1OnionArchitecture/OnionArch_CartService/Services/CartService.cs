using Domain.Entities;
using Domain.RepositoryInterfaces;
using Services.Abstractions;
using Shared.DTO;

namespace Services
{
    internal sealed class CartService : ICartService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CartService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public bool AddItem(int cartId, CartItemDTO item)
        {
            throw new NotImplementedException();
        }

        public List<CartItemDTO> GetCartItems(int cartId)
        {
            Cart cart = _repositoryManager.CartRepository.GetCart(cartId);
            List<CartItemDTO> cartItems = cart.CartItems.Select(i => new CartItemDTO()
            {
                ItemId = i.ItemId,
                ItemImage = new ItemImageInfoDTO() { Url = i.ItemImage.Url, AltText = i.ItemImage.AltText },
                Name = i.Name,
                Price = i.Price,
                Quantity = i.Quantity
            }).ToList();

            return cartItems;
        }

        public bool RemoveItem(int cartId, int itemId)
        {
            throw new NotImplementedException();
        }
    }
}
