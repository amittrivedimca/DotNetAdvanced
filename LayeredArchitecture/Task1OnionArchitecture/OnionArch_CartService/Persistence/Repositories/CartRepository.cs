using Domain.Entities;
using Domain.RepositoryInterfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CartRepository : ICartRepository
    {
        CartLiteDB cartDB;

        public CartRepository()
        {
            cartDB = new CartLiteDB();
        }

        public Cart GetCart(int cartId)
        {                        
            return cartDB.GetCart(cartId);
        }         

        public bool InsertCart(Cart cart)
        {
            return cartDB.InsertCart(cart);
        }

        public bool UpdateCart(Cart cart)
        {
            return cartDB.UpdateCart(cart);
        }

        public bool AddItem(int cartId, CartItem item) {
            Cart cart = cartDB.GetCart(cartId);
            cart.CartItems.Add(item);
            cartDB.UpdateCart(cart);
            return true;
        }

        public bool RemoveItem(int cartId, int itemId)
        {
            Cart cart = cartDB.GetCart(cartId);
            CartItem? itemToRemove = cart.CartItems.FirstOrDefault(i => i.ItemId == itemId);

            if (itemToRemove != null)
            {
                cart.CartItems.Remove(itemToRemove);
            }

            cartDB.UpdateCart(cart);
            return true;
        }
    }
}
