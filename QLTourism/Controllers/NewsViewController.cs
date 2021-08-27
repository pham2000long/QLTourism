using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTourism.Models;
using System.Data.Entity;

namespace QLTourism.Controllers
{
    public class NewsViewController : Controller
    {
        private TourismDB db = new TourismDB();
        // GET: News
        public ActionResult Index(string searchString)
        {
            var newsz = db.News.Select(p => p);
            if (!String.IsNullOrEmpty(searchString))
            {
                newsz = newsz.Where(p => p.title.Contains(searchString));
            }
            newsz = newsz.OrderByDescending(p => p.id);
            ViewBag.searchString = searchString;
            return View(newsz.ToList());
        }
        // GET: News
        public ActionResult ArticleDetail(int? id)
        {
            var newsz = db.News.Find(id);
            return View(newsz);
        }
        public ActionResult SideMenu()
        {
            var newsz = db.News.Select(p => p);
            newsz = newsz.OrderByDescending(p => p.id);
            return PartialView(newsz.ToList());
        }
    }
}