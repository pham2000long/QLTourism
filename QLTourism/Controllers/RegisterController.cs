using QLTourism.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLTourism.Controllers
{
    public class RegisterController : Controller
    {
        private TourismDB db = new TourismDB();
        // Get: /Customer
        // Call Form register
        public ActionResult Index()
        {
            return View(new Customer());
        }

        // POST: Admin/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "username,password,name,email,phone,city,address")] Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Customers.Add(customer);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Đã xảy ra lỗi " + ex.Message;
                return View(customer);
            }
        }
    }
}