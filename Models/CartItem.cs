using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanMyPham.Models
{
    [Serializable]
    public class CartItem
    {
        public product Product {set;get;}
        public int Quantity { set;get;}

        public decimal Total { set;get;}
    }
}