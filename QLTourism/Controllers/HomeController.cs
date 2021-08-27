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
        List<Category> dropDown;
        public ActionResult Index()
        {
            var newsz = db.News.Select(p => p);
            newsz = newsz.OrderByDescending(p => p.id);
            ViewBag.News = newsz;
            var packages = db.Packages.Include(p => p.Category);
            packages = packages.OrderByDescending(p => p.id);
            ViewBag.TongTour = packages.Count();
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
            }
            ViewBag.DropDown = dropDownOrder;
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
    }
}