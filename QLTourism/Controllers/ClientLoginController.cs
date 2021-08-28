using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

        public ActionResult LoginPage(string username, string password, string returnUrl)
        {
            if (!String.IsNullOrEmpty(returnUrl))
                ViewBag.oldUrl = returnUrl;
            if (Session["ClientidUser"] != null)
            {
                if(!String.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
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
                    Session["ClientAvatar"] = tk.avatar;
                    if (!String.IsNullOrEmpty(returnUrl))
                        return Redirect(returnUrl);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Sai tên tài khoản hoặc mật khẩu!";
                }
            }
            else if (username != null && password != null)
            {
                if (username.Equals("") || password.Equals(""))
                {
                    ViewBag.Error = "Sai tên tài khoản hoặc mật khẩu!";
                    return View();
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
                Session["ClientAvatar"] = tk.avatar;
                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
        }
        public new ActionResult Profile(int? id)
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

        // POST: /ClientLogin/EditProfile/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile([Bind(Include = "id,username,password,name,email,phone,gender,city,country,birthday,address")] Customer customer, HttpPostedFileBase editImage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Customer modifyCustomer = db.Customers.Find(customer.id);
                    modifyCustomer.username = customer.username;
                    modifyCustomer.password = customer.password;
                    modifyCustomer.name = customer.name;
                    modifyCustomer.email = customer.email;
                    modifyCustomer.phone = customer.phone;
                    modifyCustomer.gender = customer.gender;
                    modifyCustomer.city = customer.city;
                    modifyCustomer.country = customer.country;
                    modifyCustomer.birthday = customer.birthday;
                    modifyCustomer.address = customer.address;
                    if (modifyCustomer != null)
                    {
                        if (editImage != null && editImage.ContentLength > 0)
                        {
                            string fileName = System.IO.Path.GetFileName(editImage.FileName);
                            string urlImage = Server.MapPath("~/Assets/img/images/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + fileName);
                            editImage.SaveAs(urlImage);
                            modifyCustomer.avatar = DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + fileName;
                        }
                    }
                    db.Entry(modifyCustomer).State = EntityState.Modified;
                    db.SaveChanges();
                    Session["ClientAvatar"] = db.Customers.Find(customer.id).avatar;
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Đã xảy ra lỗi " + ex.Message;
                return View(customer);
            }
        }

        public ActionResult Logout(string returnUrl)
        {
            Session["ClientidUser"] = null;
            Session["ClientUsername"] = null;
            Session["ClientName"] = null;
            Session["ClientAvatar"] = null;
            if (!String.IsNullOrEmpty(returnUrl))
                return Redirect(returnUrl);
            return RedirectToAction("Index", "Home");
        }
        [ChildActionOnly]
        public ActionResult login()
        {
            return PartialView();
        }

    }
}