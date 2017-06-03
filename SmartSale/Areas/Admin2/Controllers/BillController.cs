using SmartSale.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartSale.Areas.Admin2.Controllers
{
    public class BillController : Controller
    {
        // GET: Admin2/Bill

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BillTable()
        {
            BillModel bm = new BillModel();
            return View(bm.GetBill());
        }
        public ActionResult CheckBill()
        {
            BillModel bm = new BillModel();
            bm.CheckBill(Convert.ToInt32(Request["id"]));
            return View("BillTable", bm.GetBill());
        }
        public ActionResult ViewBill()
        {
            BillModel bm = new BillModel();          
            return View(bm.GetTicket(Convert.ToInt32(Request["id"])));
        }
        public ActionResult DeleteBill()
        {
            BillModel bm = new BillModel();
            bm.DeleteBill(Convert.ToInt32(Request["id"]));
            return View("BillTable", bm.GetBill());
        }
    }
}