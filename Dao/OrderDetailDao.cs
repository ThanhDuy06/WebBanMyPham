using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanMyPham.Models;

namespace WebBanMyPham.Dao
{
    public class OrderDetailDao
    {
        WebBanMyPhamEntities db = null;
        public OrderDetailDao()
        {
            db = new WebBanMyPhamEntities();
        }
        public bool Insert(OrderDetail detail)
        {
            try
            {
                db.OrderDetails.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }
    }
}