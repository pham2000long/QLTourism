using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLTourism.Views.Home
{
    public class ClientLoginController : Controller
    {
        // GET: ClientLogin
        public ActionResult Index(string username, string password, string url)
        {
            return Redirect(url);
        }

        public ActionResult login()
        {
            return PartialView();
        }
    }
}