using Domain.Entities;
using Shared.DTO;

namespace Services.Abstractions
{
    public interface ICartService
    {
        public void InitCart();
        public List<CartItemDTO> GetCartItems(int cartId);
        public bool AddItem(CartItemDTO item);
        public bool RemoveItem(int cartId, int itemId);
    }
}
