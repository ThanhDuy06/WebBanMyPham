using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanMyPham.Help;
using WebBanMyPham.Models;

namespace WebBanMyPham.Areas.admin.Controllers
{
    public class bannersController : Controller
    {
        private WebBanMyPhamEntities db = new WebBanMyPhamEntities();

        // GET: admin/banners
        public ActionResult Index()
        {
            return View(db.banners.ToList());
        }

        // GET: admin/banners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            banner banner = db.banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // GET: admin/banners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/banners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]

        public ActionResult Create([Bind(Include = "id,name,url,detail1,detail2,link,meta,hide,order,datebegin,detail3")] banner banner, HttpPostedFileBase img)
        {
            var path = "";
            var filename = "";
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    //filename = Guid.NewGuid().ToString() + img.FileName;
                    filename = img.FileName;
                    path = Path.Combine(Server.MapPath("~/Content/upload/img/slider"), filename);
                    img.SaveAs(path);
                    banner.url = filename; //Lưu ý
                }
                else
                {
                    banner.url = "logo.png";
                }
                db.banners.Add(banner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(banner);
        }

        // GET: admin/banners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            banner banner = db.banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // POST: admin/banners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]

        public ActionResult Edit([Bind(Include = "id,name,url,detail1,detail2,link,meta,hide,order,datebegin,detail3")] banner banner, HttpPostedFileBase img)
        {
            try
            {
                var path = "";
                var filename = "";
                banner temp = getById(banner.id);
                if (ModelState.IsValid)
                {
                    if (img != null)
                    {
                        //filename = Guid.NewGuid().ToString() + img.FileName;
                        filename = img.FileName;
                        path = Path.Combine(Server.MapPath("~/Content/upload/img/slider"), filename);
                        img.SaveAs(path);
                        banner.url = filename; //Lưu ý
                    }
                    // temp.datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());                   
                    temp.name = banner.name;
                    temp.detail1 = banner.detail1;
                    temp.detail2 = banner.detail2;
                    temp.meta = Functions.ConvertToUnSign(banner.meta); //convert Tiếng Việt không dấu
                    temp.hide = banner.hide;
                    temp.order = banner.order;
                    db.Entry(banner).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(banner);
        }
        public banner getById(long id)
        {
            return db.banners.Where(x => x.id == id).FirstOrDefault();

        }
        // GET: admin/banners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            banner banner = db.banners.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // POST: admin/banners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            banner banner = db.banners.Find(id);
            db.banners.Remove(banner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
