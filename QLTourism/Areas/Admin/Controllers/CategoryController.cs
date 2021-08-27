using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using QLTourism.Models;

namespace QLTourism.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private TourismDB db = new TourismDB();
        private List<Category> Categories;

        // GET: Admin/Category
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.currentSort = sortOrder;

            ViewBag.SapXepTheoId = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.SapXepTheoTen = sortOrder == "ten" ? "ten_desc" : "ten";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.currentFilter = searchString;
            var categories = db.Categories.Select(p => p);
            // Lọc danh mục
            if (!String.IsNullOrEmpty(searchString))
            {
                categories = categories.Where(p => p.name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "id_desc":
                    categories = categories.OrderByDescending(s => s.id);
                    break;
                case "ten":
                    categories = categories.OrderBy(s => s.name);
                    break;
                case "ten_desc":
                    categories = categories.OrderByDescending(s => s.name);
                    break;
                default:
                    categories = categories.OrderBy(s => s.id);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(categories.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            this.Categories = db.Categories.ToList();
            var categories = categoryRecusive(0);
            ViewBag.parentId = categories;
            return View(new Category());
        }

        public List<Category> categoryRecusive(int parent_id = 0, int id = 0, string text = " ")
        {
            var Categories = this.Categories;
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
        // POST: Admin/Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "id,name,parentId")] Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Categories.Add(category);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Đã xảy ra lỗi " + ex.Message;
                ViewBag.parentId = new SelectList(db.Categories, "id", "name", category.parentId);
                return View(category);
            }
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = category;
            this.Categories = db.Categories.ToList();
            var categories = categoryRecusive(0);
            ViewBag.parentId = categories;
            return View();
        }

        // POST: Admin/Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,parentId")] Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(category).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Đã xảy ra lỗi " + ex.Message;
                ViewBag.parentId = new SelectList(db.Categories, "id", "name", category.parentId);
                return View(category);
            }
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            try
            {
                db.Categories.Remove(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Đã xảy ra lỗi " + ex.Message;
                return View(category);
            }
            
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
