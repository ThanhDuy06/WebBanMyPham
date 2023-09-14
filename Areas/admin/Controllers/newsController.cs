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
    public class newsController : Controller
    {
        private WebBanMyPhamEntities db = new WebBanMyPhamEntities();

        // GET: admin/news
        public ActionResult Index()
        {
            return View(db.news.ToList());
        }

        // GET: admin/news/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            news news = db.news.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: admin/news/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/news/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]

        public ActionResult Create([Bind(Include = "Id,name,img,description,link,detail,meta,hide,order,datebegin")] news news, HttpPostedFileBase img)
        {
            try
            {
                var path = "";
                var filename = "";
                if (ModelState.IsValid)
                {
                    if (img != null)
                    {
                        //filename = Guid.NewGuid().ToString() + img.FileName;
                        filename = img.FileName;
                        path = Path.Combine(Server.MapPath("~/Content/upload/img/news"), filename);
                        img.SaveAs(path);
                        news.img = filename; //Lưu ý
                    }
                    else
                    {
                        news.img = "logo.png";
                    }
                    news.meta = Functions.ConvertToUnSign(news.meta); //convert Tiếng Việt không dấu
                    news.datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    db.news.Add(news);
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

            return View(news);
        }

        // GET: admin/news/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            news news = db.news.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: admin/news/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]

        public ActionResult Edit([Bind(Include = "Id,name,img,description,link,detail,meta,hide,order,datebegin")] news news, HttpPostedFileBase img)
        {
            try
            {
                var path = "";
                var filename = "";
                news temp = getById(news.Id);
                if (ModelState.IsValid)
                {
                    if (img != null)
                    {
                        //filename = Guid.NewGuid().ToString() + img.FileName;
                        filename = img.FileName;
                        path = Path.Combine(Server.MapPath("~/Content/upload/img/news"), filename);
                        img.SaveAs(path);
                        temp.img = filename; //Lưu ý
                    }
                    // temp.datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());                   
                    temp.name = news.name;
                    temp.description = news.description;
                    temp.detail = news.detail;
                    temp.meta = Functions.ConvertToUnSign(news.meta); //convert Tiếng Việt không dấu
                    temp.hide = news.hide;
                    temp.order = news.order;
                    temp.link = news.link;
                    db.Entry(temp).State = EntityState.Modified;
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

            return View(news);
        }
        public news getById(long id)
        {
            return db.news.Where(x => x.Id == id).FirstOrDefault();

        }
        // GET: admin/news/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            news news = db.news.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: admin/news/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            news news = db.news.Find(id);
            db.news.Remove(news);
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
