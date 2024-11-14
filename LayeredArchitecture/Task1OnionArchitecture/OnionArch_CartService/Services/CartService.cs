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

        int cartId = 1;

        public void InitCart()
        {
            Cart existingCart = _repositoryManager.CartRepository.GetCart(cartId);

            if (existingCart == null)
            {
                List<CartItem> items = new List<CartItem>() {
                    new CartItem(){ ItemId = 1, Name = "Item 1", Price = 10, Quantity = 100, ItemImage = new ItemImageInfo() },
                    new CartItem(){ ItemId = 2, Name = "Item 2", Price = 20, Quantity = 200, ItemImage = new ItemImageInfo() },
                };

                var cart = new Cart()
                {
                    CartId = cartId,
                    CartItems = items
                };
                _repositoryManager.CartRepository.InsertCart(cart);
            }
        }

        public bool AddItem(CartItemDTO item)
        {
            return _repositoryManager.CartRepository.AddItem(item.CartId, item.ToCartItem());
        }

        public List<CartItemDTO> GetCartItems(int cartId)
        {
            Cart cart = _repositoryManager.CartRepository.GetCart(cartId);
            List<CartItemDTO> cartItems = cart.CartItems.Select(i => i.ToCartItemDTO(cartId)).ToList();
            return cartItems;
        }

        public bool RemoveItem(int cartId, int itemId)
        {
            return _repositoryManager.CartRepository.RemoveItem(cartId, itemId);
        }
    }
}
