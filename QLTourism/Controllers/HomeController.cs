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

        [ChildActionOnly]
        public ActionResult HomeSlider()
        {
            IEnumerable<Slider> slider = db.Sliders.Select(p => p);
            return PartialView(slider);
        }
    }
}