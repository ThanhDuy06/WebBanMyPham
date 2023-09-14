using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanMyPham.Models;

namespace WebBanMyPham.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        WebBanMyPhamEntities _db = new WebBanMyPhamEntities();
        // GET: News
        public ActionResult Index()
        {
            var v = from t in _db.footer_lienhe
                    where t.hide == true
                    select t;
            return View(v.ToList());
        }
    }
}