using Domain.Entities;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    /// <summary>
    /// https://www.litedb.org/docs/getting-started/
    /// </summary>
    internal class CartLiteDB
    {
        private LiteDatabase GetDB()
        {
            // Open database (or create if doesn't exist)
            return new LiteDatabase(@"C:\Temp\CartServiceData.db");
        }

        private ILiteCollection<Cart> GetCartsCollection(LiteDatabase db)
        {
            // Get a collection (or create, if doesn't exist)
            return db.GetCollection<Cart>("crarts");
        }

        public bool InsertCart(Cart cart)
        {
            using (var db = GetDB())
            {                
                var cartsCollection = GetCartsCollection(db);
                // Insert new document (Id will be auto-incremented)
                cartsCollection.Insert(cart);
            }

            return true;
        }

        public bool UpdateCart(Cart cart)
        {
            using (var db = GetDB())
            {
                var cartsCollection = GetCartsCollection(db);
                // Insert new document (Id will be auto-incremented)
                cartsCollection.Update(cart);
            }

            return true;
        }

        public Cart GetCart(int cartId)
        {
            using (var db = GetDB())
            {
                var cartsCollection = GetCartsCollection(db);
                return cartsCollection.Query()
                    .Where(x => x.CartId == cartId).FirstOrDefault();
            }
        }
    }
}
