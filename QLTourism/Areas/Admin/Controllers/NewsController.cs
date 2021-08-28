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
    public class NewsController : Controller
    {
        private TourismDB db = new TourismDB();

        // GET: Admin/News
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.currentSort = sortOrder;

            ViewBag.SapXepTheoTitle = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "title";
            ViewBag.SapXepTheoDate = sortOrder == "ten" ? "date_desc" : "date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.currentFilter = searchString;
            var news = db.News.Select(p => p);
            // Lọc tin tức
            if (!String.IsNullOrEmpty(searchString))
            {
                news = news.Where(p => p.title.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "title":
                    news = news.OrderBy(s => s.title);
                    break;
                case "title_desc":
                    news = news.OrderByDescending(s => s.title);
                    break;
                case "date":
                    news = news.OrderBy(s => s.date);
                    break;
                case "date_desc":
                    news = news.OrderByDescending(s => s.date);
                    break;
                default:
                    news = news.OrderByDescending(s => s.id);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(news.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: Admin/News/Create
        public ActionResult Create()
        {
            ViewBag.categoryId = new SelectList(db.Categories, "id", "name");
            return View(new News());
        }

        // POST: Admin/News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "id,title,date,summary,detail,categoryId,thumbail")] News news, HttpPostedFileBase image)
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
                        news.thumbail = DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + fileName;
                    }
                    db.News.Add(news);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Đã xảy ra lỗi " + ex.Message;
                ViewBag.categoryId = new SelectList(db.Categories, "id", "name", news.categoryId);
                return View(news);
            }
        }

        // GET: Admin/News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryId = new SelectList(db.Categories, "id", "name", news.categoryId);
            return View(news);
        }

        // POST: Admin/News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "id,title,date,summary,detail,categoryId,thumbail")] News news, HttpPostedFileBase editImage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (editImage != null && editImage.ContentLength > 0)
                    {
                        string fileName = System.IO.Path.GetFileName(editImage.FileName);
                        string urlImage = Server.MapPath("~/Areas/Admin/wwwroot/thumbail/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + fileName);
                        editImage.SaveAs(urlImage);
                        news.thumbail = DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + fileName;
                    }
                    db.Entry(news).State = EntityState.Modified;
                    db.SaveChanges(); 
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Đã xảy ra lỗi " + ex.Message;
                ViewBag.categoryId = new SelectList(db.Categories, "id", "name", news.categoryId);
                return View(news);
            }
        }

        // GET: Admin/News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: Admin/News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.News.Find(id);
            try
            {
                db.News.Remove(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Đã xảy ra lỗi " + ex.Message;
                return View(news);
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
