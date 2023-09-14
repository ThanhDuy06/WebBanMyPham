using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBanMyPham.Models;

namespace Model.Dao
{
    public class ProductDao
    {
        WebBanMyPhamEntities db = null;
        public ProductDao()
        {
            db = new WebBanMyPhamEntities();
        }

        public List<product> ListNewProduct(int top)
        {
            // lấy ra sản phẩm có ngày cập nhật mới nhất
            return db.products.OrderByDescending(x => x.date_begin).Take(top).ToList();
        }
        public product ViewDetail(long id)
        {
            return db.products.Find(id);
        }
    }
}
