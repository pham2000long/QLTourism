using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTourism.Models;

namespace QLTourism.Views.Home
{
    public class ClientLoginController : Controller
    {
        private TourismDB db = new TourismDB();
        // GET: ClientLogin
        public ActionResult Index()
        {
            if (Session["ClientidUser"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult LoginPage(string username, string password)
        {
            if (Session["ClientidUser"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if(!String.IsNullOrEmpty(username)&& !String.IsNullOrEmpty(password))
            {
                var tk = db.Customers.Where(p => p.username.Equals(username) && p.password.Equals(password)).FirstOrDefault();
                if (tk != null)
                {
                    Session["ClientidUser"] = tk.id;
                    Session["ClientUsername"] = tk.username;
                    Session["ClientName"] = tk.name;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Sai tên tài khoản hoặc mật khẩu!";
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult ValidateUser(string username, string password)
        {
            var tk = db.Customers.Where(p => p.username.Equals(username) && p.password.Equals(password)).FirstOrDefault();
            if (tk != null)
            {
                Session["ClientidUser"] = tk.id;
                Session["ClientUsername"] = tk.username;
                Session["ClientName"] = tk.name;
                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
        }

        [ChildActionOnly]
        public ActionResult login()
        {
            return PartialView();
        }
    }
}