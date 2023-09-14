using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using WebBanMyPham.Models;

namespace WebBanMyPham.Dao
{
    public class ProductCategoryDao
    {
        WebBanMyPhamEntities _db = null;
        public ProductCategoryDao()
        {
            _db = new WebBanMyPhamEntities();
        }
        public List<category> ListAll()
        {
            return _db.categories.Where(x => x.hide == true).OrderBy(x => x.order).ToList();
        }
    }
}