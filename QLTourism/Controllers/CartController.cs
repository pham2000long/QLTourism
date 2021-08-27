using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLTourism.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
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