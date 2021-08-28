using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using QLTourism.Models;

namespace QLTourism.Controllers
{
    public class UserBookingController : Controller
    {
        private TourismDB db = new TourismDB();
        // GET: UserBooking
        public ActionResult Index()
        {
            return View();
        }
    }
}