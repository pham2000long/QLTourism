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
    public class SliderController : Controller
    {
        private TourismDB db = new TourismDB();

        // GET: Admin/Sliders
        public ActionResult Index()
        {
            return View(db.Sliders.OrderByDescending(x => x.id).ToList());
        }

        // GET: Admin/Sliders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // GET: Admin/Sliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sliders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,imagePath,urlPath")] Slider slider, HttpPostedFileBase imagePath)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (imagePath != null && imagePath.ContentLength > 0)
                    {
                        string fileName = System.IO.Path.GetFileName(imagePath.FileName);
                        string urlImage = Server.MapPath("~/Areas/Admin/wwwroot/slider/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + fileName);
                        imagePath.SaveAs(urlImage);
                        slider.imagePath = DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + fileName;
                    }
                    db.Sliders.Add(slider);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(slider);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu!" + ex.Message;
                return View(slider);
            }
        }

        // GET: Admin/Sliders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Admin/Sliders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,urlPath")] Slider slider, HttpPostedFileBase editImage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Slider modifySlider = db.Sliders.Find(slider.id);
                    modifySlider.name = slider.name;
                    modifySlider.urlPath = slider.urlPath;
                    if (modifySlider != null)
                    {
                        if (editImage != null && editImage.ContentLength > 0)
                        {
                            string fileName = System.IO.Path.GetFileName(editImage.FileName);
                            string urlImage = Server.MapPath("~/Areas/Admin/wwwroot/slider/" + DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + fileName);
                            editImage.SaveAs(urlImage);
                            modifySlider.imagePath = DateTime.Now.ToString("ddMMyyyy_hhmmss_tt_") + fileName;
                        }
                    }

                    db.Entry(modifySlider).State = EntityState.Modified;
                    db.SaveChanges();
                    Session["imagePath"] = db.Sliders.Find(slider.id).imagePath;
                    return RedirectToAction("Index");
                }
                return View(slider);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu!" + ex.Message;
                return View(slider);
            }
        }

        // GET: Admin/Sliders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Admin/Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slider = db.Sliders.Find(id);
            try
            {
                db.Sliders.Remove(slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu!" + ex.Message;
                return View(slider);
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
