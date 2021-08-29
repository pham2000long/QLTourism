using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTourism.Models;
using System.Data.Entity;
using Newtonsoft.Json;

namespace QLTourism.Controllers
{
    public class TourController : Controller
    {
        private TourismDB db = new TourismDB();
        List<Category> dropDown;
        // GET: Tour
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListTour(string searchString, int? madm = 0)
        {
            if(madm == 0)
            {
                ViewBag.TenDanhMuc = "Tất cả các tour";
            }
            else
            {
                ViewBag.TenDanhMuc = db.Categories.Where(p => p.id == madm).FirstOrDefault().name;
            }
            this.dropDown = db.Categories.AsNoTracking().ToList();
            var dropDownCate = categoryRecusive(0);
            List<Category> dropDownOrder = new List<Category>();
            int type = 0;
            foreach(var item in dropDownCate.ToList())
            {
                if (!item.name.Contains("--"))
                {
                    dropDownOrder.Add(item);
                    foreach(var itemz in dropDownCate.ToList())
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
                if(item.id == madm)
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
            ViewBag.searchString = searchString;
            ViewBag.madm = madm;
            var tours = db.Packages.Include(p => p.Category);
            if (!String.IsNullOrEmpty(searchString))
            {
                tours = tours.Where(p => p.pkgName.Contains(searchString));
            }
            if(madm != 0)
            {
                if (type == 1)
                {
                    tours = tours.Where(p => p.categoryId == madm);
                }
                else if (type == 2)
                {
                    tours = tours.Where(p => p.Category.parentId == madm);
                }
                else
                {
                    var kz = db.Categories.Where(p => p.parentId == madm).ToList();
                    List<int> ds = new List<int>();
                    foreach(var itemzz in kz)
                    {
                        ds.Add(itemzz.id);
                    }
                    tours = tours.Where(p => ds.Contains(p.Category.parentId));
                }

            }
            ViewBag.DanhMuc = db.Categories.Where(p => p.id == madm).FirstOrDefault();
            var result = tours.OrderByDescending(p => p.id).ToList();
            if (tours.Count() > 6)
            {
                List<Package> dstour = new List<Package>();
                int countIndex = 0;
                foreach(var item in result)
                {
                    dstour.Add(item);
                    countIndex++;
                    if (countIndex >= 6)
                        break;
                }
                return View(dstour);
            }
            else
            {
                return View(result);
            }
        }

        public ActionResult Details(int? id)
        {
            Package package = db.Packages.Include(p=>p.Programs).Include(p => p.Media).Include(p => p.Prices).Include(p => p.Category).FirstOrDefault(p => p.id == id);
            return View(package);
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

        [HttpPost]
        public JsonResult AddMore(string searchString, int madm, int index)
        {
            this.dropDown = db.Categories.AsNoTracking().ToList();
            var dropDownCate = categoryRecusive(0);
            int type = 0;
            foreach (var item in dropDownCate.ToList())
            {
                if (item.id == madm)
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
            var tours = db.Packages.OrderByDescending(p => p.id).Include(p => p.Category);
            if (!String.IsNullOrEmpty(searchString))
            {
                tours = tours.Where(p => p.pkgName.Contains(searchString));
            }
            if (madm != 0)
            {
                if (type == 1)
                {
                    tours = tours.Where(p => p.categoryId == madm);
                }
                else if (type == 2)
                {
                    tours = tours.Where(p => p.Category.parentId == madm);
                }
                else
                {
                    var kz = db.Categories.Where(p => p.parentId == madm).ToList();
                    List<int> ds = new List<int>();
                    foreach (var itemzz in kz)
                    {
                        ds.Add(itemzz.id);
                    }
                    tours = tours.Where(p => ds.Contains(p.Category.parentId));
                }
            }
            List<Package> dsThem = new List<Package>();
            int dem = 0;
            int dembatdau = 0;
            foreach (var item in tours.ToList())
            {
                if(dembatdau >= index)
                {
                    item.thumbail = Url.Content("~/Areas/Admin/wwwroot/thumbail/" + item.thumbail);
                    if (item.pkgDesc == null)
                    {
                        item.pkgDesc = "Chưa có mô tả";
                    }
                    else
                        item.pkgDesc = item.pkgDesc.Split('>', '<')[2];

                    dsThem.Add(item);
                    dem++;
                    if (dem >= 3)
                        break;
                }
                dembatdau++;
            }
            int isFull = 0;
            if (dsThem.Count() <= 0)
                isFull = 1;
            for(int i=0; i< dsThem.Count(); i++)
            {
                string[] ifo = dsThem[i].pkgDesc.Split('>', '<');
                if(ifo.Count() < 3)
                {
                    dsThem[i].pkgDesc = "...";
                }
                else if (ifo[2].Length > 150)
                    dsThem[i].pkgDesc = ifo[2].Substring(0, 155);
                else
                    dsThem[i].pkgDesc = ifo[2];
            }

            return Json(new { pkg = dsThem, fullStatus = isFull }, JsonRequestBehavior.AllowGet);
        }
    }
}