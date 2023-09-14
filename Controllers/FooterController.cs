using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanMyPham.Models;

namespace WebBanMyPham.Controllers
{
    public class FooterController : Controller
    {
        WebBanMyPhamEntities _db = new WebBanMyPhamEntities();

        // GET: Footer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getMenuFooter()
        {
            ViewBag.meta = "san-pham";
            var v = from t in _db.categories

                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
        public ActionResult getFooterHtkh()
        {
            var v = from t in _db.footer_htkh

                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
        public ActionResult getFooterLienhe()
        {
            var v = from t in _db.footer_lienhe

                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
    }
}