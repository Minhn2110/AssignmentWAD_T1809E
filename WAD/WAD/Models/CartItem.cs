using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAD.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductThumbnail { get; set; }
        public double ProductPrice { get; set; }
        public int Quantity { get; set; }
        public double TotalItemPrice => ProductPrice * Quantity;
    }
}