using SmartSale.Areas.Admin2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartSale.Areas.Admin2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin2/Home
        public ActionResult Index()
        {
            if (Session["admin"] == null)
                Response.Redirect("~/Admin2/Home/Login");
            return View();
        }
        public ActionResult Login()
        {   
           
            if (Session["admin"] != null)
                return View("Index");
            else
                return View();
        }
        public void Logout()
        {
            Session["admin"] = null;
            Response.Redirect("~/Admin2/Home/Login");
        }
        [HttpPost]
        public ActionResult Authentication()
        {
            LoginModel lg = new LoginModel();
            if (lg.CheckAccount(Request["acc"], Request["pass"]))
            {
                Session["admin"] = Request["acc"];
                return View("Index");
            }
            else
                return View("Login");
        }
    }
}