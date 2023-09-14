using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanMyPham.Models;
using WebBanMyPham.Dao;


namespace WebBanMyPham.Controllers
{
    public class ProductController : Controller
    {
        WebBanMyPhamEntities _db = new WebBanMyPhamEntities();

        // GET: Product
        public ActionResult Index(string meta)
        {
            var v = from t in _db.categories
                    where t.meta == meta
                    select t;
            return View(v.FirstOrDefault());
        }
        public ActionResult Detail(long id)
        {
            var v = from t in _db.products
                    where t.id == id
                    select t;
            return View(v.FirstOrDefault());
        }
        public ActionResult getProduct_index()
        {
            ViewBag.meta = "san-pham";
            var v = from t in _db.products
                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
    }
}