using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLTourism.Models;
using System.Dynamic;
using System.Web.Script.Serialization;

namespace QLTourism.Areas.Admin.Controllers
{
    public class PackageController : Controller
    {
        private TourismDB db = new TourismDB();

        // GET: Admin/Package
        public ActionResult Index()
        {
            var packages = db.Packages.Include(p => p.Category);
            return View(packages.ToList());
        }

        // GET: Admin/Package/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // GET: Admin/Package/Create
        public ActionResult Create()
        {
            ViewBag.categoryId = new SelectList(db.Categories, "id", "name");
            return View(new Package());
        }

        // POST: Admin/Package/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,pkgName,pkgStartDate,pkgTimePeriod,pkgStartPlace,pkgEndPlace,pkgDesc,pkgRules,pkgTransporter,pkgBasePrice,pkgCondition,pkgSlot,active,categoryId")] Package package)
        {
            if (ModelState.IsValid)
            {
                package.pkgDesc = System.Net.WebUtility.HtmlDecode(package.pkgDesc);
                db.Packages.Add(package);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryId = new SelectList(db.Categories, "id", "name", package.categoryId);
            return View(package);
        }

        // GET: Admin/Package/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryId = new SelectList(db.Categories, "id", "name", package.categoryId);
            return View(package);
        }

        // POST: Admin/Package/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,pkgName,pkgStartDate,pkgTimePeriod,pkgStartPlace,pkgEndPlace,pkgDesc,pkgRules,pkgTransporter,pkgBasePrice,pkgCondition,pkgSlot,active,categoryId")] Package package)
        {
            if (ModelState.IsValid)
            {
                package.pkgDesc = System.Net.WebUtility.HtmlDecode(package.pkgDesc);
                db.Entry(package).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryId = new SelectList(db.Categories, "id", "name", package.categoryId);
            return View(package);
        }

        // GET: Admin/Package/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Find(id);
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        public ActionResult Prices(int? id)
        {
            var prices = db.Prices.Where(p => p.packageId == id);
            string ten = db.Packages.Where(p => p.id == id).FirstOrDefault().pkgName;
            ViewBag.Ten = ten;
            ViewBag.Prices = prices.ToList();
            ViewBag.Id = id;
            return View(new Price());
        }
        [HttpPost]
        public ActionResult AddPrice(Price prc)
        {
            db.Prices.Add(prc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditPrice(Price prc)
        {
            db.Entry(prc).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult DeletePrice(int id)
        {
            bool result = false;
            Price prc = db.Prices.Find(id);
            db.Prices.Remove(prc);
            db.SaveChanges();
            result = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // POST: Admin/Package/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Package package = db.Packages.Find(id);
            db.Packages.Remove(package);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Media(int? id)
        {
            var medias = db.Media.Where(p => p.packageId == id);
            string ten = db.Packages.Where(p => p.id == id).FirstOrDefault().pkgName;
            ViewBag.Ten = ten;
            ViewBag.Medias = medias.ToList();
            ViewBag.Id = id;
            return View(new Medium());
        }

        public JsonResult AddMedia(string media, HttpPostedFileBase hinhanh)
        {
            try
            {
                JavaScriptSerializer convert = new JavaScriptSerializer();
                Medium item = convert.Deserialize<Medium>(media);
                var f = hinhanh;
                if (f != null && f.ContentLength > 0 && item.type == 1)
                {
                    string fileName = System.IO.Path.GetFileName(f.FileName);
                    string urlImage = Server.MapPath("~/Areas/Admin/wwwroot/tourImage/" + fileName);
                    f.SaveAs(urlImage);
                    item.path = fileName;
                }
                db.Media.Add(item);
                db.SaveChanges();
                return Json(new { status = true, message = "Thêm thành công!" });
            }
            catch (Exception)
            {
                return Json(new { status = false, message = "Thêm không thành công!" });
            }
        }

        public JsonResult EditMedia(string media, HttpPostedFileBase hinhanh)
        {
            try
            {
                bool image = false;
                JavaScriptSerializer convert = new JavaScriptSerializer();
                Medium item = convert.Deserialize<Medium>(media);
                var f = hinhanh;
                string oldImage = "";
                if (f != null && f.ContentLength > 0 && item.type == 1)
                {
                    string fileName = System.IO.Path.GetFileName(f.FileName);
                    string urlImage = Server.MapPath("~/Areas/Admin/wwwroot/tourImage/" + fileName);
                    f.SaveAs(urlImage);
                    if (!item.path.Equals(fileName))
                    {
                        oldImage = urlImage;
                        image = true;
                    }
                    item.path = fileName;
                    image = true;
                }
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                if(image)
                    System.IO.File.Delete(oldImage);
                return Json(new { status = true, message = "Thêm thành công!" });
            }
            catch (Exception)
            {
                return Json(new { status = false, message = "Thêm không thành công!" });
            }
        }

        [HttpPost]
        public JsonResult DeleteMedia(int id)
        {
            bool result = false;
            Medium med = db.Media.Find(id);
            db.Media.Remove(med);
            if(med.type == 1)
            {
                string oldImage = Server.MapPath("~/Areas/Admin/wwwroot/tourImage/" + med.path);
                System.IO.File.Delete(oldImage);
            }
            db.SaveChanges();
            result = true;
            return Json(result, JsonRequestBehavior.AllowGet);
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
