using QLTourism.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLTourism.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private TourismDB db = new TourismDB();
        // GET: Admin/Login
        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Index()
        {
            if (Session["idUser"] != null)
            {
                Session["Message"] = "Bạn đã đăng nhập!";
                return RedirectToAction("Index", "Dashboard");
            }
            return View(new User());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = db.Users.Where(s => s.username.Equals(username) && s.password.Equals(password)).ToList();
                    if (data.Count() > 0)
                    {
                        //add session
                        Session["username"] = data.FirstOrDefault().username;
                        Session["idUser"] = data.FirstOrDefault().id;
                        Session["avatar"] = data.FirstOrDefault().avatar;
                        Session["roleId"] = data.FirstOrDefault().roleId;
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                    {
                        Session["error"] = "Tài khoản hoặc mật khẩu không chính xác!";
                        return RedirectToAction("Index");
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi không thể đăng nhập!" + ex.Message;
                return View();
            }
        }

        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Logout()
        {
            Session["username"] = null;
            Session["idUser"] = null;
            Session["avatar"] = null;
            Session["roleId"] = null;
            return RedirectToAction("Index");
        }
    }
}