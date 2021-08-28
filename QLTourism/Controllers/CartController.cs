using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTourism.Models;
using System.Data.Entity;

namespace QLTourism.Controllers
{
    public class CartController : Controller
    {
        private TourismDB db = new TourismDB();
        // GET: Cart
        public ActionResult Index()
        {
            if (Session["CartItem"] != null)
            {
                List<string[]> ds = new List<string[]>();
                List<int> dsPkg = new List<int>();
                string z = Session["CartItem"].ToString();
                int total = 0;
                int totalprice = 0;
                foreach (var item in z.Split('&'))
                {
                    var a = item.Split('|');
                    ds.Add(a);
                    dsPkg.Add(Int32.Parse(a[2]));
                    total += Int32.Parse(a[1]);
                    int zzz = Int32.Parse(a[0]);
                    totalprice += Int32.Parse(a[1]) * Int32.Parse(db.Prices.AsNoTracking().Where(p => p.id == zzz).FirstOrDefault().price1.ToString());
                }
                var pkg = db.Packages.Where(p => dsPkg.Contains(p.id)).Include(p => p.Prices);
                ViewBag.total = total;
                ViewBag.totalprice = totalprice;
                ViewBag.dsSession = ds;
                ViewBag.pkg = pkg;
                ViewBag.all = pkg.Count();
            }
            else
            {
                ViewBag.total = 0;
                ViewBag.totalprice = 0;
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            if (Session["CartItem"] != null)
            {
                List<string[]> ds = new List<string[]>();
                List<int> dsPkg = new List<int>();
                string z = Session["CartItem"].ToString();
                foreach (var item in z.Split('&'))
                {
                    var a = item.Split('|');
                    ds.Add(a);
                    dsPkg.Add(Int32.Parse(a[2]));
                }
                string ses = "";
                foreach(var it in ds)
                {
                    if (Int32.Parse(it[2]) != id)
                    {
                        ses += it[0] + "|" + it[1] + "|" + it[2] + "&";
                    }
                }
                if (ses.Length >= 1)
                {
                    ses = ses.Substring(0,ses.Length - 1);
                    Session["CartItem"] = ses;
                }
                else
                {
                    Session["CartItem"] = null;
                }
                return RedirectToAction("Index", "Cart");
            }
            else
            {
                return RedirectToAction("Index", "Cart");
            }
        }

        [HttpPost]
        public ActionResult addToCart(int priceId, int numberBuy , int pkgId)
        {
            try
            {
                if(numberBuy == 0)
                {
                    return Json(new { Success = 3 }, JsonRequestBehavior.AllowGet);
                }
                if (Session["CartItem"] == null)
                {
                    Session["CartItem"] = priceId + "|" + numberBuy + "|" + pkgId;
                    return Json(new { Success = 1 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    string a = Session["CartItem"].ToString();
                    string[] b = a.Split('&');
                    foreach(var z in b)
                    {
                        string[] c = z.Split('|');
                        if (Int32.Parse(c[2]) == pkgId)
                            return Json(new { Success = 2 }, JsonRequestBehavior.AllowGet);
                    }
                    Session["CartItem"] = Session["CartItem"] + "&" + priceId + "|" + numberBuy + "|" + pkgId;
                    return Json(new { Success = 1 }, JsonRequestBehavior.AllowGet);
                }
            }
            catch(Exception ex)
            {
                return Json(new { Success = 0 }, JsonRequestBehavior.AllowGet);
            }
            
        }

        [HttpPost]
        public ActionResult updateCart(string ses)
        {
            try
            {
                List<string[]> ds = new List<string[]>();
                List<int> dsPkg = new List<int>();
                string z = ses;
                int total = 0;
                int totalprice = 0;
                foreach (var item in z.Split('&'))
                {
                    var a = item.Split('|');
                    ds.Add(a);
                    dsPkg.Add(Int32.Parse(a[2]));
                    total += Int32.Parse(a[1]);
                    int zzz = Int32.Parse(a[0]);
                    totalprice += Int32.Parse(a[1]) * Int32.Parse(db.Prices.AsNoTracking().Where(p => p.id == zzz).FirstOrDefault().price1.ToString());
                }
                var pkg = db.Packages.Where(p => dsPkg.Contains(p.id)).Include(p => p.Prices);
                ViewBag.total = total;
                ViewBag.totalprice = totalprice;
                Session["CartItem"] = ses;
                //Session["total"] = total;
                //Session["totalprice"] = totalprice;
                return Json(new { totalz = total, totalpricez = totalprice }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { totalz = 0, totalpricez = 0 }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Checkout()
        {
            if (Session["ClientidUser"] == null)
            {
                Session["Message"] = "Bạn cần đăng nhập để tiếp tục thanh toán!";
                Session["isCart"] = 1;
                return RedirectToAction("LoginPage", "ClientLogin");
            }
            Customer customer = db.Customers.Find(Session["ClientidUser"]);
            if (Session["CartItem"] != null)
            {
                List<string[]> ds = new List<string[]>();
                List<int> dsPkg = new List<int>();
                int total2 = 0, totalprice2 = 0;
                string z = Session["CartItem"].ToString();
                foreach (var item in z.Split('&'))
                {
                    var a = item.Split('|');
                    ds.Add(a);
                    total2 += Int32.Parse(a[1]);
                    dsPkg.Add(Int32.Parse(a[2]));
                    int zzz = Int32.Parse(a[0]);
                    totalprice2 += Int32.Parse(a[1]) * Int32.Parse(db.Prices.AsNoTracking().Where(p => p.id == zzz).FirstOrDefault().price1.ToString());
                }
                var pkg = db.Packages.Where(p => dsPkg.Contains(p.id)).Include(p => p.Prices);
                
                if (Session["total"] != null)
                {
                    ViewBag.total = Session["total"];
                    ViewBag.totalprice = Session["totalprice"];
                }
                else
                {
                    ViewBag.total = total2;
                    ViewBag.totalprice = totalprice2;
                }
                ViewBag.dsSession = ds;
                ViewBag.pkg = pkg;
                ViewBag.all = pkg.Count();
            }
            else
            {
                ViewBag.total = 0;
                ViewBag.totalprice = 0;
            }
            return View(customer);
        }

        
        [HttpPost]
        public ActionResult UpdateCus(Customer CusObj)
        {
            Customer customer = db.Customers.Find(Session["ClientidUser"]);
            customer.name = CusObj.name;
            customer.email = CusObj.email;
            customer.phone = CusObj.phone;
            customer.country = CusObj.country;
            customer.city = CusObj.city;
            customer.address = CusObj.address;
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Payment([Bind(Include = "id,travelerCount,customerId,packageId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                booking.bookingDate = DateTime.Now;
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customerId = Session["ClientidUser"];
            ViewBag.packageId = new SelectList(db.Packages, "id", "pkgName", booking.packageId);
            ViewBag.tripTypeId = new SelectList(db.TripTypes, "id", "ttName", booking.tripTypeId);
            return View(booking);
        }

    }
}