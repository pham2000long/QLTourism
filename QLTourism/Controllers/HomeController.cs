using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTourism.Models;

namespace QLTourism.Controllers
{
    public class HomeController : Controller
    {
        private TourismDB db = new TourismDB();
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult TourMenu()
        {
            IEnumerable<Category> danhmucs = db.Categories.Select(p => p);
            return PartialView(danhmucs);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}