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
    public class UserController : Controller
    {
        private TourismDB db = new TourismDB();

        // GET: Admin/User
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Role);
            return View(users.ToList());
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/User/Create
        public ActionResult Create()
        {
            ViewBag.roleId = new SelectList(db.Roles, "id", "name");
            return View();
        }

        // POST: Admin/User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,username,password,name,email,phone,gender,birthday,address,roleId")] User user, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null && image.ContentLength > 0)
                {
                    string fileName = System.IO.Path.GetFileName(image.FileName);
                    string urlImage = Server.MapPath("~/Areas/Admin/wwwroot/avatar/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + fileName);
                    image.SaveAs(urlImage);
                    user.avatar = DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + fileName;
                }
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.roleId = new SelectList(db.Roles, "id", "name", user.roleId);
            return View(user);
        }

        // GET: Admin/User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.roleId = new SelectList(db.Roles, "id", "name", user.roleId);
            return View(user);
        }

        // POST: Admin/User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,username,password,name,email,phone,gender,birthday,address,roleId")] User user, HttpPostedFileBase editImage)
        { 
            if (ModelState.IsValid)
            {
                User modifyUser = db.Users.Find(user.id);
                modifyUser.username = user.username;
                modifyUser.password = user.password;
                modifyUser.name = user.name;
                modifyUser.email = user.email;
                modifyUser.phone = user.phone;
                modifyUser.gender = user.gender;
                modifyUser.birthday = user.birthday;
                modifyUser.address = user.address;
                modifyUser.roleId = user.roleId;
                if (modifyUser != null )
                {
                    if (editImage != null && editImage.ContentLength > 0)
                    {
                        string fileName = System.IO.Path.GetFileName(editImage.FileName);
                        string urlImage = Server.MapPath("~/Areas/Admin/wwwroot/avatar/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + fileName);
                        editImage.SaveAs(urlImage);
                        modifyUser.avatar = DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + fileName;
                    }
                }
                db.Entry(modifyUser).State = EntityState.Modified;
                db.SaveChanges();
                Session["avatar"] = db.Users.Find(user.id).avatar;
                return RedirectToAction("Index");
            }
            ViewBag.roleId = new SelectList(db.Roles, "id", "name", user.roleId);
            return View(user);
        }

        // GET: Admin/User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
