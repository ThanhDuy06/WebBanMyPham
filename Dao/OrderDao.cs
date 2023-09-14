using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanMyPham.Models;

namespace WebBanMyPham.Dao
{
    public class OrderDao
    {
        WebBanMyPhamEntities db = null;
        public OrderDao()
        {
            db = new WebBanMyPhamEntities();
        }
        public long Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.ID;
        }
    }
}