using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTourism.Models;

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
                var pkg = db.Packages.Where(p => dsPkg.Contains(p.id));
                ViewBag.dsSession = ds;
                ViewBag.Pkg = pkg;
            }
            return View();
        }

        [HttpPost]
        public ActionResult addToCart(int priceId, int numberBuy , int pkgId)
        {
            try
            {
                if (Session["CartItem"] == null)
                {
                    Session["CartItem"] = priceId + "|" + numberBuy + "|" + pkgId;
                    return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Session["CartItem"] = Session["CartItem"] + "&" + priceId + "|" + numberBuy + "|" + pkgId;
                    return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
                }
            }
            catch(Exception ex)
            {
                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}