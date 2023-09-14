using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanMyPham.Models;

namespace WebBanMyPham.Controllers
{
    public class HomeController : Controller
    {
        WebBanMyPhamEntities _db = new WebBanMyPhamEntities();
        public ActionResult Index()
        {
            var productDao = new ProductDao();
            ViewBag.NewProducts = productDao.ListNewProduct(12);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult getBanner()
        {
            var v = from t in _db.banners

                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
        public ActionResult getBlock()
        {
            var v = from t in _db.blocks

                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
        public ActionResult getNew()
        {
            var v = from t in _db.news

                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
        public ActionResult getCategory()
        {
            ViewBag.meta = "san-pham";
            var v = from t in _db.categories

                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
        public ActionResult getProduct(long id)
        {
            ViewBag.meta = "san-pham";
            var v = from t in _db.products
                    where t.id_category == id && t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
    }
}