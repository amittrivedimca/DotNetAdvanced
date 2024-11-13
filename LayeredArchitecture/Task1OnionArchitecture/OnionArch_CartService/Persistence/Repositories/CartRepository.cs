using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CartRepository : ICartRepository
    {
        public Cart GetCart(int cartId)
        {
            //throw new NotImplementedException();

            List<CartItem> items = new List<CartItem>() {
                new CartItem(){ ItemId = 1, Name = "Item 1", Price = 10, Quantity = 100, ItemImage = new ItemImageInfo() },
                new CartItem(){ ItemId = 2, Name = "Item 2", Price = 20, Quantity = 200, ItemImage = new ItemImageInfo() },
            };

            return new Cart()
            {
                CartId = 1,
                CartItems = items
            };
        }

        public bool InsertCart(Cart cart)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCart(Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}
