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
    public class RoleController : Controller
    {
        private TourismDB db = new TourismDB();

        // GET: Admin/Role
        public ActionResult Index()
        {
            if (Session["roleId"].Equals(1))
            {
                return View(db.Roles.OrderByDescending(x => x.id).ToList());
            }
            Session["Message"] = "Bạn không có quyền truy cập trang quản lý quyền hạn!";
            return RedirectToAction("Index", "Dashboard");
        }

        // GET: Admin/Role/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["roleId"].Equals(1))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Role role = db.Roles.Find(id);
                if (role == null)
                {
                    return HttpNotFound();
                }
                return View(role);
            }
            Session["Message"] = "Bạn không có quyền truy cập trang quản lý quyền hạn!";
            return RedirectToAction("Index", "Dashboard");
        }

        // GET: Admin/Role/Create
        public ActionResult Create()
        {
            if (Session["roleId"].Equals(1))
            {
                return View(new Role());
            }
            Session["Message"] = "Bạn không có quyền truy cập trang quản lý quyền hạn!";
            return RedirectToAction("Index", "Dashboard");
        }

        // POST: Admin/Role/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] Role role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Roles.Add(role);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu! " + ex.Message;
                return View(role);
            }
        }

        // GET: Admin/Role/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["roleId"].Equals(1))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Role role = db.Roles.Find(id);
                if (role == null)
                {
                    return HttpNotFound();
                }
                return View(role);
            }
            Session["Message"] = "Bạn không có quyền truy cập trang quản lý quyền hạn!";
            return RedirectToAction("Index", "Dashboard");
        }

        // POST: Admin/Role/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] Role role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(role).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu! " + ex.Message;
                return View(role);
            }
        }

        // GET: Admin/Role/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["roleId"].Equals(1))
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Role role = db.Roles.Find(id);
                if (role == null)
                {
                    return HttpNotFound();
                }
                return View(role);
            }
            Session["Message"] = "Bạn không có quyền truy cập trang quản lý quyền hạn!";
            return RedirectToAction("Index", "Dashboard");
        }

        // POST: Admin/Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Role role = db.Roles.Find(id);
            try
            {
                db.Roles.Remove(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Không thể xóa bản ghi" + ex.Message;
                return View(role);
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
