using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTourism.Models;
using System.Data.Entity;

namespace QLTourism.Controllers
{
    public class HomeController : Controller
    {
        private TourismDB db = new TourismDB();
        public ActionResult Index()
        {
            var packages = db.Packages.Include(p => p.Category);
            packages = packages.OrderByDescending(p => p.id);
            ViewBag.TongTour = packages.Count();
            return View(packages.ToList());
        }

        [ChildActionOnly]
        public ActionResult TourMenu()
        {
            IEnumerable<Category> danhmucs = db.Categories.Select(p => p);
            return PartialView(danhmucs);
        }

        [ChildActionOnly]
        public ActionResult HomeSlider()
        {
            IEnumerable<Slider> slider = db.Sliders.Select(p => p);
            return PartialView(slider);
        }
    }
}