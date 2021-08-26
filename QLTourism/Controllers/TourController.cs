﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTourism.Models;
using System.Data.Entity;

namespace QLTourism.Controllers
{
    public class TourController : Controller
    {
        private TourismDB db = new TourismDB();
        // GET: Tour
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListTour(string searchString, int? madm)
        {
            ViewBag.searchString = searchString;
            ViewBag.madm = madm;
            var tours = db.Packages.Select(p => p);
            if (!String.IsNullOrEmpty(searchString))
            {
                tours = tours.Where(p => p.pkgName.Contains(searchString));
            }
            if(madm != null && madm != 0)
            {
                tours = tours.Where(p => p.categoryId == madm);
                ViewBag.DanhMuc = db.Categories.Where(p => p.id == madm).FirstOrDefault();
            }
            return View(tours.OrderBy(p => p.id).ToList());
        }

        public ActionResult Details(int? id)
        {
            Package package = db.Packages.Include(p=>p.Programs).Include(p => p.Media).Include(p => p.Prices).Include(p => p.Category).FirstOrDefault(p => p.id == id);
            return View(package);
        }
    }
}