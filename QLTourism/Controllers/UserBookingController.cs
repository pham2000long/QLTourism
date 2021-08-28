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
            if (Session["ClientidUser"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Bookings()
        {
            if (Session["ClientidUser"] != null)
            {
                int id = Int32.Parse(Session["ClientidUser"].ToString());
                var item = db.Bookings.Where(p => p.customerId == id).Include(p=>p.BookingDetails);
                return PartialView(item.ToList());
            }
            return new EmptyResult();
        }

        public ActionResult Details(int id)
        {
            if(Session["ClientidUser"] != null)
            {
                int idUser = Int32.Parse(Session["ClientidUser"].ToString());
                var item = db.Bookings.Where(p => p.id == id).Include(p => p.BookingDetails).Include(p=>p.BookingDetails.Select(a=>a.Package)).FirstOrDefault();
                ViewBag.Tk = db.Customers.Where(p => p.id == idUser).FirstOrDefault();
                if (item.customerId == idUser)
                {
                    return View(item);
                }
                else
                {
                    return new EmptyResult();
                }
            }
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Edit(int id, string country = "", string city = "", string address = "", string customerNote = "")
        {
            try
            {
                if (Session["ClientidUser"] == null)
                {
                    return Json(new { Success = 0 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Booking editz = db.Bookings.Where(p => p.id == id).FirstOrDefault();
                    editz.country = country;
                    editz.city = city;
                    editz.address = address;
                    editz.customerNote = customerNote;
                    db.SaveChanges();
                    return Json(new { Success = 1 }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json(new { Success = 2 }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}