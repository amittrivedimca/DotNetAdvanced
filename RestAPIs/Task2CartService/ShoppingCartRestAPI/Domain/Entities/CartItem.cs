using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CartItem
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public ItemImageInfo ItemImage { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
    }
}
