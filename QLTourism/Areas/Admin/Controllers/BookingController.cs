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
    public class BookingController : Controller
    {
        private TourismDB db = new TourismDB();

        // GET: Admin/Booking
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.currentSort = sortOrder;

            ViewBag.SapXepTheoTen = sortOrder == "ten" ? "ten_desc" : "ten";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.currentFilter = searchString;
            var bookings = db.Bookings.Include(b => b.Customer);

            if (!String.IsNullOrEmpty(searchString))
            {
                bookings = bookings.Where(p => p.Customer.name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "ten":
                    bookings = bookings.OrderBy(s => s.Customer.name);
                    break;
                case "ten_desc":
                    bookings = bookings.OrderByDescending(s => s.Customer.name);
                    break;
                default:
                    bookings = bookings.OrderByDescending(s => s.id);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            
            return View(bookings.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Booking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            
            var bookingDetails = db.BookingDetails.Where(p => p.bookingId == id).Include(p=>p.Package);
            ViewBag.BookingDetails = bookingDetails;
            ViewBag.CustomerName = db.Customers.Where(p => p.id == booking.customerId).Select(p => p.name).FirstOrDefault();
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Admin/Booking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Admin/Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            try
            {
                db.Bookings.Remove(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Đã xảy ra lỗi " + ex.Message;
                return View(booking);
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
