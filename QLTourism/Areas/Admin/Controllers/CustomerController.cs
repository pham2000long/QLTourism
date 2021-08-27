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
    public class CustomerController : Controller
    {
        private TourismDB db = new TourismDB();

        // GET: Admin/Customer
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.currentSort = sortOrder;

            ViewBag.SapXepTheoId = String.IsNullOrEmpty(sortOrder) ? "id_asc" : "";
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
            var customers = db.Customers.Select(p => p);
            // Lọc khách hàng
            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(p => p.name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "id_asc":
                    customers = customers.OrderBy(s => s.id);
                    break;
                case "ten":
                    customers = customers.OrderBy(s => s.name);
                    break;
                case "ten_desc":
                    customers = customers.OrderByDescending(s => s.name);
                    break;
                default:
                    customers = customers.OrderByDescending(s => s.id);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(customers.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Admin/Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Admin/Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            try
            {
                db.Customers.Remove(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(customer);
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
