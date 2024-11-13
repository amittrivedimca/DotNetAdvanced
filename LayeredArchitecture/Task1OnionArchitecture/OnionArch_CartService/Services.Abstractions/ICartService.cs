using Domain.Entities;
using Shared.DTO;

namespace Services.Abstractions
{
    public interface ICartService
    {
        public List<CartItemDTO> GetCartItems(int cartId);
        public bool AddItem(int cartId, CartItemDTO item);
        public bool RemoveItem(int cartId, int itemId);
    }
}
