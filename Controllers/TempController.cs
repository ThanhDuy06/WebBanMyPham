using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanMyPham.Commons;
using WebBanMyPham.Models;

namespace WebBanMyPham.Controllers
{
    public class TempController : Controller
    {
        WebBanMyPhamEntities _db = new WebBanMyPhamEntities();
        // GET: Temp
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getMenu()
        {
            var v = from t in _db.menus

                    where t.hide==true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }
    }
}
