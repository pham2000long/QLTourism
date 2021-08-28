using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLTourism.Models;

namespace QLTourism.Areas.Admin.Controllers
{
    public class BookingController : Controller
    {
        private TourismDB db = new TourismDB();

        // GET: Admin/Booking
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.Customer).Include(b => b.Package).Include(b => b.TripType);
            return View(bookings.ToList());
        }

        // GET: Admin/Booking/Details/5
        public ActionResult Details(int? id)
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

        // GET: Admin/Booking/Create
        public ActionResult Create()
        {
            ViewBag.customerId = new SelectList(db.Customers, "id", "username");
            ViewBag.packageId = new SelectList(db.Packages, "id", "pkgName");
            ViewBag.tripTypeId = new SelectList(db.TripTypes, "id", "ttName");
            return View();
        }

        // POST: Admin/Booking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,bookingDate,bookingNo,travelerCount,customerId,tripTypeId,packageId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customerId = new SelectList(db.Customers, "id", "username", booking.customerId);
            ViewBag.packageId = new SelectList(db.Packages, "id", "pkgName", booking.packageId);
            ViewBag.tripTypeId = new SelectList(db.TripTypes, "id", "ttName", booking.tripTypeId);
            return View(booking);
        }

        // GET: Admin/Booking/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.customerId = new SelectList(db.Customers, "id", "username", booking.customerId);
            ViewBag.packageId = new SelectList(db.Packages, "id", "pkgName", booking.packageId);
            ViewBag.tripTypeId = new SelectList(db.TripTypes, "id", "ttName", booking.tripTypeId);
            return View(booking);
        }

        // POST: Admin/Booking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,bookingDate,bookingNo,travelerCount,customerId,tripTypeId,packageId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customerId = new SelectList(db.Customers, "id", "username", booking.customerId);
            ViewBag.packageId = new SelectList(db.Packages, "id", "pkgName", booking.packageId);
            ViewBag.tripTypeId = new SelectList(db.TripTypes, "id", "ttName", booking.tripTypeId);
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
            db.Bookings.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("Index");
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
