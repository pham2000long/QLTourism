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
                string z = Session["CartItem"].ToString();
                int total = 0;
                int totalprice = 0;
                foreach (var item in z.Split('&'))
                {
                    var a = item.Split('|');
                    total += Int32.Parse(a[1]);
                    int zzz = Int32.Parse(a[0]);
                    totalprice += Int32.Parse(a[1]) * Int32.Parse(db.Prices.AsNoTracking().Where(p => p.id == zzz).FirstOrDefault().price1.ToString());
                }
                ViewBag.total = total;
                ViewBag.totalprice = totalprice;
            }
            else
            {
                ViewBag.total = 0;
                ViewBag.totalprice = 0;
            }
            return View();
        }
        public ActionResult cartItems()
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
                var pkg = db.Packages.Include(p => p.Prices).Where(p => dsPkg.Contains(p.id));
                ViewBag.dsSession = ds;
                ViewBag.pkg = pkg;
                ViewBag.all = pkg.Count();
            }
            return PartialView();
        }

        public ActionResult Delete(int id)
        {
            if (Session["CartItem"] != null)
            {
                string[] Ses = Session["CartItem"].ToString().Split('&');
                if (Ses.Length <= 1)
                {
                    Session.Remove("CartItem");
                    return Json(new { Success = 1, total = 0, totalprice = 0, count = 0 }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    string newSes = "";
                    int total = 0;
                    int totalprice = 0;
                    foreach (var item in Ses)
                    {
                        string[] splitarr = item.Split('|');
                        if (Int32.Parse(splitarr[2]) != id)
                        {
                            newSes += splitarr[0] + "|" + splitarr[1] + "|" + splitarr[2] + "&";
                            total += Int32.Parse(splitarr[1]);
                            int zzz = Int32.Parse(splitarr[0]);
                            totalprice += Int32.Parse(splitarr[1]) * Int32.Parse(db.Prices.AsNoTracking().Where(p => p.id == zzz).FirstOrDefault().price1.ToString());
                        }
                    }
                    newSes = newSes.Substring(0, newSes.Length - 1);
                    int count = newSes.Split('&').Count();
                    return Json(new { Success = 1, total = total, totalprice = totalprice, count = count }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Success = 0 }, JsonRequestBehavior.AllowGet);
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
        public ActionResult updateCart(string ses, string returnUrl)
        {
            try
            {
                if (Session["CartItem"] != null)
                {
                    if(String.IsNullOrEmpty(ses))
                    {
                        int total = 0;
                        int totalprice = 0;
                        string[] addedSes = Session["CartItem"].ToString().Split('&');
                        foreach (var item in addedSes)
                        {
                            var a = item.Split('|');
                            total += Int32.Parse(a[1]);
                            int zzz = Int32.Parse(a[0]);
                            totalprice += Int32.Parse(a[1]) * Int32.Parse(db.Prices.AsNoTracking().Where(p => p.id == zzz).FirstOrDefault().price1.ToString());
                        }
                        int itemCountAll = addedSes.Count();
                        return Json(new { totalz = total, totalpricez = totalprice, itemcount = itemCountAll, isEmpty = 0 }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        string[] addedSes = Session["CartItem"].ToString().Split('&');
                        string[] sesSplited = ses.Split('&');
                        if (addedSes.Count() > sesSplited.Count())
                        {
                            for (int i = sesSplited.Count(); i < addedSes.Count(); i++)
                            {
                                ses += "&" + addedSes[i];
                            }
                        }
                        int total = 0;
                        int totalprice = 0;
                        foreach (var item in ses.Split('&'))
                        {
                            var a = item.Split('|');
                            total += Int32.Parse(a[1]);
                            int zzz = Int32.Parse(a[0]);
                            totalprice += Int32.Parse(a[1]) * Int32.Parse(db.Prices.AsNoTracking().Where(p => p.id == zzz).FirstOrDefault().price1.ToString());
                        }
                        Session["CartItem"] = ses;
                        int itemCountAll = ses.Split('&').Count();
                        return Json(new { totalz = total, totalpricez = totalprice, itemcount = itemCountAll, isEmpty = 0 }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isEmpty = 1 }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { isEmpty = 2 }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Checkout(string returnUrl)
        {
            if (Session["ClientidUser"] == null)
            {
                Session["Message"] = "Bạn cần đăng nhập để tiếp tục thanh toán!";
                return RedirectToAction("LoginPage", "ClientLogin", new { returnUrl = returnUrl });
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
                var pkg = db.Packages.Where(p => dsPkg.Contains(p.id)).Include(p => p.Prices).ToList();
                
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
                ViewBag.Booking = Session["CartItem"].ToString();
            }
            else
            {
                Session["Message"] = "Giỏ hàng của bạn hiện trống nên chưa thể tiến hành đặt hàng!";
                return Redirect(returnUrl);
            }
            return View(customer);
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
            return View(booking);
        }

        public ActionResult Finish()
        {
            if (Session["ClientidUser"] == null)
            {
                return RedirectToAction("LoginPage", "ClientLogin", new { returnUrl = "/Home/Index" });
            }
            else
            {
                return View();
            }
        }

        public ActionResult FinishBooking(int customerId, string country = "", string city = "", string address = "", string customerNote = "", string bookingInfor = "")
        {
            if (Session["ClientidUser"] == null)
            {
                return Json(new { Success = 0 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Booking booking = new Booking();
                booking.customerId = customerId;
                booking.country = country;
                booking.city = city;
                booking.address = address;
                booking.bookingDate = DateTime.Now;
                booking.customerNote = customerNote;
                Random r = new Random();
                int num = r.Next(10000000, 99999999);
                booking.bookingNo = num.ToString() + customerId.ToString();
                db.Bookings.Add(booking);
                db.SaveChanges();
                foreach(string item in bookingInfor.Split('&'))
                {
                    string[] arr = item.Split('|');
                    BookingDetail detail = new BookingDetail();
                    detail.bookingId = booking.id;
                    detail.packageId = Int32.Parse(arr[2]);
                    int zzz = Int32.Parse(arr[0]);
                    Price cb = db.Prices.AsNoTracking().Where(p => p.id == zzz).FirstOrDefault();
                    detail.Price = Int32.Parse(arr[1]) * Int32.Parse(cb.price1.ToString());
                    detail.bookingInfor = cb.title + " - " + arr[1] + " suất";
                    db.BookingDetails.Add(detail);
                    db.SaveChanges();
                }
                Session.Remove("CartItem");
                return Json(new { Success = 1 }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}