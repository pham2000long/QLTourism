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
                foreach (var item in z.Split('&'))
                {
                    var a = item.Split('|');
                    ds.Add(a);
                    dsPkg.Add(Int32.Parse(a[2]));
                }
                var pkg = db.Packages.Where(p => dsPkg.Contains(p.id)).Include(p => p.Prices);
                ViewBag.dsSession = ds;
                ViewBag.pkg = pkg;
                ViewBag.all = pkg.Count();
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
    }
}