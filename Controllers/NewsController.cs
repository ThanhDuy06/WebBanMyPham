using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanMyPham.Models;

namespace WebBanMyPham.Controllers
{
    public class NewsController : Controller
    {
        WebBanMyPhamEntities _db = new WebBanMyPhamEntities();
        // GET: News
        public ActionResult Index()
        {
            var v = from t in _db.news
                    where t.hide == true
                    select t;
            return View(v.ToList());
        }
        public ActionResult Detail_new(long id)
        {
            var v = from t in _db.news
                    where t.Id == id
                    select t;
            return View(v.FirstOrDefault());
        }
    }
}