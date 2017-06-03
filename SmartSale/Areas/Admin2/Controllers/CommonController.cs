using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartSale.Areas.Admin2.Controllers
{
    public class CommonController : Controller
    {
        // GET: Admin2/Common
        public ActionResult Header()
        {
      
            return View();
        }
        public ActionResult Menu()
        {
            
            return View();
        }
        public ActionResult Footer()
        { 
            return View();
        }
        public ActionResult LeftContent()
        {
            return View();
        }
        public ActionResult RightContent()
        {
            return View();
        }
    }
}