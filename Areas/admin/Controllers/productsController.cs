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
using WebBanMyPham.Models;
using WebBanMyPham.Help;

namespace WebBanMyPham.Areas.admin.Controllers
{
    public class productsController : Controller
    {
        private WebBanMyPhamEntities db = new WebBanMyPhamEntities();

        // GET: admin/products
        public ActionResult Index(long? id = null)
        {
            getCategory(id);
            //return View(db.products.ToList());
            return View();
        }
        public void getCategory(long? selectedId = null)
        {
            ViewBag.Category = new SelectList(db.categories.Where(x => x.hide == true)
                .OrderBy(x => x.order), "id", "name", selectedId);
        }
        public ActionResult getProduct(long? id)
        {
            if (id == null)
            {
                var v = db.products.OrderBy(x => x.order).ToList();
                return PartialView(v);
            }
            var m = db.products.Where(x => x.id_category == id).OrderBy(x => x.order).ToList();
            return PartialView(m);
        }
        // GET: admin/products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: admin/products/Create
        public ActionResult Create()
        {
            ViewBag.id_category = new SelectList(db.categories, "id", "name");
            return View();
        }

        // POST: admin/products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "id,name,price,detail,img,link,meta,hide,order,date_begin,date_update,id_category")] product product, HttpPostedFileBase img)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var path = "";
                    var filename = "";
                    if (img != null)
                    {
                        //filename = Guid.NewGuid().ToString() + img.FileName;
                        filename = img.FileName;
                        path = Path.Combine(Server.MapPath("~/Content/upload/img/product"), filename);
                        img.SaveAs(path);
                        product.img = filename; //Lưu ý
                    }
                    else
                    {
                        product.img = "logo.png";
                    }
                    //
                    product.meta = Functions.ConvertToUnSign(product.meta); //convert Tiếng Việt không dấu
                    product.order = getMaxOrder(product.id_category);
                    db.products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.id_category = new SelectList(db.categories, "id", "name", product.id_category);
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(product);
        }

        // GET: admin/products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_category = new SelectList(db.categories, "id", "name", product.id_category);
            return View(product);
        }

        // POST: admin/products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "id,name,price,detail,img,link,meta,hide,order,date_begin,date_update,id_category")] product product, HttpPostedFileBase img)
        {
            try
            {
                var path = "";
                var filename = "";
                product temp = db.products.Find(product.id);
                if (ModelState.IsValid)
                {
                    if (img != null)
                    {
                        //filename = Guid.NewGuid().ToString() + img.FileName;
                        filename = img.FileName;
                        path = Path.Combine(Server.MapPath("~/Content/upload/img/product"), filename);
                        img.SaveAs(path);
                        product.img = filename; //Lưu ý
                    }
                    temp.name = product.name;
                    temp.price = product.price;
                    temp.detail = product.detail;
                    temp.meta = Functions.ConvertToUnSign(product.meta); //convert Tiếng Việt không dấu
                    temp.hide = product.hide;
                    temp.order = product.order;
                    temp.date_begin = product.date_begin;
                    db.Entry(temp).State = EntityState.Modified; db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.id_category = new SelectList(db.categories, "id", "name", product.id_category);
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(product);

        }

        // GET: admin/products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: admin/products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product product = db.products.Find(id);
            db.products.Remove(product);
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
        public int getMaxOrder(long? CategoryId)
        {
            if (CategoryId == null)
                return 1;
            return db.products.Where(x => x.id_category == CategoryId).Count();
        }
        //ViewBag.getMaxOrder = getMaxOrder(product.categoryid) + 1;
    }
}
