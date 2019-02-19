using RdlcWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RdlcWebApp.Controllers
{
    public class HomeController : Controller
    {
        //private Entities db = new Entities();
        public ActionResult Index()

        {
            //var list = db.SBL_INDX_MOBILE.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}