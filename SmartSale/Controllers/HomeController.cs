using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartSale.Models.TransportModels;
using SmartSale.Models.BaseModels;
using SmartSale.Until;
namespace SmartSale.Controllers
{
    public class HomeController : Controller
    {
        // GET: H
        public ActionResult Index()
        {
            ProductModel pm = new ProductModel();
            TransportIndex ti = new TransportIndex();
            int dd ;
            try
            {
                dd=Convert.ToInt32(Request.Params["page"]) == 0 ? 1 : Convert.ToInt32(Request.Params["page"]);
            }catch
            {
                dd = 1;
            }
            int ss = 0;
            ti.ListProduct = pm.SelectALLProduct(dd, ref ss);
            Static.pageNum = ss;
            ti.SpecialProduct = pm.SelectProduct();
            ti.Tag = pm.GetTag().Take(6);
            return View(ti);
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }

    }
}