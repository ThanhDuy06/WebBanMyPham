using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanMyPham.Models;

namespace WebBanMyPham.Dao
{
    public class CategoryDao
    {
        WebBanMyPhamEntities _db = null;
        public CategoryDao()
        {
            _db = new WebBanMyPhamEntities();
        }
        public List<category> ListAll() {
            return _db.categories.Where(x=> x.hide == true).ToList();
        }
        public category ViewDetail(long id)
        {
            return _db.categories.Find(id);
        }
    }
}