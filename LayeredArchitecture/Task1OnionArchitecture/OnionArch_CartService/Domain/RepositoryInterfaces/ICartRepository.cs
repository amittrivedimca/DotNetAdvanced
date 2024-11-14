using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface ICartRepository
    {
        public Cart GetCart(int cartId);
        public bool InsertCart(Cart cart);
        public bool UpdateCart(Cart cart);
        public bool AddItem(int cartId, CartItem item);
        public bool RemoveItem(int cartId, int itemId);
    }
}
