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
using PagedList;

namespace QLTourism.Areas.Admin.Controllers
{
    public class PackageController : Controller
    {
        private TourismDB db = new TourismDB();
        List<Category> dropDown;

        // GET: Admin/Package
        public ActionResult Index(string searchString, int dmFilter = 0, int page = 1, int pageSize = 10)
        {
            this.dropDown = db.Categories.AsNoTracking().ToList();
            var dropDownCate = categoryRecusive(0);
            List<Category> dropDownOrder = new List<Category>();
            int type = 0;
            foreach (var item in dropDownCate.ToList())
            {
                if (!item.name.Contains("--"))
                {
                    dropDownOrder.Add(item);
                    foreach (var itemz in dropDownCate.ToList())
                    {
                        if (itemz.parentId == item.id)
                        {
                            dropDownOrder.Add(itemz);
                            foreach (var itemzz in dropDownCate.ToList())
                            {
                                if (itemzz.parentId == itemz.id)
                                {
                                    dropDownOrder.Add(itemzz);
                                }
                            }
                        }
                    }
                }
                if (item.id == dmFilter)
                {
                    if (item.name.Contains("----"))
                    {
                        type = 1;
                    }
                    else if (item.name.Contains("--"))
                    {
                        type = 2;
                    }
                    else
                    {
                        type = 3;
                    }
                }
            }
            ViewBag.DropDown = dropDownOrder;
            var packages = db.Packages.Include(p => p.Category);
            ViewBag.searchString = searchString;
            ViewBag.dmFilter = dmFilter;
            if (!String.IsNullOrEmpty(searchString))
            {
                packages = packages.Where(p => p.pkgName.Contains(searchString));
            }
            if (dmFilter != 0)
            {
                if (type == 1)
                {
                    packages = packages.Where(p => p.categoryId == dmFilter);
                }
                else if (type == 2)
                {
                    packages = packages.Where(p => p.Category.parentId == dmFilter);
                }
                else
                {
                    var kz = db.Categories.Where(p => p.parentId == dmFilter).ToList();
                    List<int> ds = new List<int>();
                    foreach (var itemzz in kz)
                    {
                        ds.Add(itemzz.id);
                    }
                    packages = packages.Where(p => ds.Contains(p.Category.parentId));
                }
            }
            return View(packages.OrderByDescending(sp => sp.id).ToPagedList(page, pageSize));
        }

        // GET: Admin/Package/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Where(p => p.id == id).Include(p => p.Category).FirstOrDefault();
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // GET: Admin/Package/Create
        public ActionResult Create()
        {
            this.dropDown = db.Categories.AsNoTracking().ToList();
            var dropDownCate = categoryRecusive(0);
            List<Category> dropDownOrder = new List<Category>();
            foreach (var item in dropDownCate.ToList())
            {
                if (!item.name.Contains("--"))
                {
                    dropDownOrder.Add(item);
                    foreach (var itemz in dropDownCate.ToList())
                    {
                        if (itemz.parentId == item.id)
                        {
                            dropDownOrder.Add(itemz);
                            foreach (var itemzz in dropDownCate.ToList())
                            {
                                if (itemzz.parentId == itemz.id)
                                {
                                    dropDownOrder.Add(itemzz);
                                }
                            }
                        }
                    }
                }
            }
            ViewBag.categoryId = dropDownOrder;
            return View(new Package());
        }

        // POST: Admin/Package/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,pkgName,pkgStartDate,pkgTimePeriod,pkgStartPlace,pkgEndPlace,pkgDesc,pkgRules,pkgTransporter,pkgBasePrice,pkgCondition,pkgSlot,active,categoryId")] Package package, HttpPostedFileBase image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (image != null && image.ContentLength > 0)
                    {
                        string fileName = System.IO.Path.GetFileName(image.FileName);
                        string urlImage = Server.MapPath("~/Areas/Admin/wwwroot/thumbail/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + fileName);
                        image.SaveAs(urlImage);
                        package.thumbail = DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + fileName;
                    }
                    package.pkgDesc = System.Net.WebUtility.HtmlDecode(package.pkgDesc);
                    db.Packages.Add(package);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu " + ex.Message;
                ViewBag.categoryId = new SelectList(db.Categories, "id", "name", package.categoryId);
                return View(package);
            }
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
            this.dropDown = db.Categories.AsNoTracking().ToList();
            var dropDownCate = categoryRecusive(0);
            List<Category> dropDownOrder = new List<Category>();
            foreach (var item in dropDownCate.ToList())
            {
                if (!item.name.Contains("--"))
                {
                    dropDownOrder.Add(item);
                    foreach (var itemz in dropDownCate.ToList())
                    {
                        if (itemz.parentId == item.id)
                        {
                            dropDownOrder.Add(itemz);
                            foreach (var itemzz in dropDownCate.ToList())
                            {
                                if (itemzz.parentId == itemz.id)
                                {
                                    dropDownOrder.Add(itemzz);
                                }
                            }
                        }
                    }
                }
            }
            ViewBag.categoryId = dropDownOrder;
            return View(package);
        }

        // POST: Admin/Package/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,pkgName,pkgStartDate,pkgTimePeriod,pkgStartPlace,pkgEndPlace,pkgDesc,pkgRules,pkgTransporter,pkgBasePrice,pkgCondition,pkgSlot,active,categoryId")] Package package, HttpPostedFileBase editImage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    package.thumbail = db.Packages.AsNoTracking().Where(p => p.id == package.id).FirstOrDefault().thumbail;
                    if (editImage != null && editImage.ContentLength > 0)
                    {
                        string fileName = System.IO.Path.GetFileName(editImage.FileName);
                        string urlImage = Server.MapPath("~/Areas/Admin/wwwroot/thumbail/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + fileName);
                        editImage.SaveAs(urlImage);
                        package.thumbail = DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + fileName;
                    }
                    package.pkgDesc = System.Net.WebUtility.HtmlDecode(package.pkgDesc);
                    db.Entry(package).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu " + ex.Message;
                ViewBag.categoryId = new SelectList(db.Categories, "id", "name", package.categoryId);
                return View(package);
            }
        }

        // GET: Admin/Package/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package package = db.Packages.Where(p => p.id == id).Include(p => p.Category).FirstOrDefault();
            if (package == null)
            {
                return HttpNotFound();
            }
            return View(package);
        }

        // POST: Admin/Package/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Package package = db.Packages.Find(id);
            try
            {
                db.Packages.Remove(package);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi không xóa đươc " + ex.Message;
                return View(package);
            }
            
        }

        public ActionResult Programs(int? id)
        {
            var programs = db.Programs.Where(p => p.packageId == id);
            string ten = db.Packages.Where(p => p.id == id).FirstOrDefault().pkgName;
            ViewBag.Ten = ten;
            ViewBag.Programs = programs.ToList();
            ViewBag.Id = id;
            return View(new Program());
        }

        [HttpPost]
        public ActionResult AddProgram(Program prc)
        {
            try
            {
                db.Programs.Add(prc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Xảy ra lỗi " + ex.Message;
                return View(prc);
            }
        }

        [HttpPost]
        public ActionResult EditProgram(Program prc)
        {
            try
            {
                db.Entry(prc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Xảy ra lỗi " + ex.Message;
                return View(prc);
            }
            
        }

        [HttpPost]
        public JsonResult DeleteProgram(int id)
        {
            bool result = false;
            Program prc = db.Programs.Find(id);
            db.Programs.Remove(prc);
            db.SaveChanges();
            result = true;
            return Json(result, JsonRequestBehavior.AllowGet);
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
            try
            {
                db.Prices.Add(prc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Xảy ra lỗi " + ex.Message;
                return View(prc);
            }
        }

        [HttpPost]
        public ActionResult EditPrice(Price prc)
        {
            try
            {
                db.Entry(prc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Xảy ra lỗi " + ex.Message;
                return View(prc);
            }
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

        public List<Category> categoryRecusive(int parent_id = 0, int id = 0, string text = " ")
        {
            var Categories = this.dropDown;
            foreach (var item in Categories)
            {
                if (item.parentId == id)
                {
                    if (parent_id == 0 && parent_id == id)
                    {
                        item.name = text + item.name;
                    }
                    else
                    {
                        item.name = text + item.name;
                    }
                    categoryRecusive((int)item.parentId, item.id, text + "--");
                }
            }
            return Categories;
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
