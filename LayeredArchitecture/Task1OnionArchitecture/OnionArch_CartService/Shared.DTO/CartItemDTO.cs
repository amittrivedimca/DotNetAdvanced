using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class CartItemDTO
    {
        public int CartId { get; set; }
        public int ItemId { get; set; }
        public string Name { get; set; }
        public ItemImageInfoDTO ItemImage { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
    }
}
