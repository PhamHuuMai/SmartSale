using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartSale.Models;
using SmartSale.Models.TransportModels;
using SmartSale.Models.BaseModels;
using SmartSale.Until;
namespace SmartSale.Controllers
{
    public class RedirectController : Controller
    {
        // GET: Redirect
        public ActionResult Category()
        {
            ProductModel pm = new ProductModel();
            TransportIndex ti = new TransportIndex();
            int idCat;
            int dd;
            try
            {
                dd = Convert.ToInt32(Request.Params["page"]) == 0 ? 1 : Convert.ToInt32(Request.Params["page"]);
                idCat = Convert.ToInt32(Request.Params["cat"]);
            }
            catch
            {
                dd = 1;
                idCat = 1;
            }
            int ss = 0;
            ti.ListProduct = pm.SelectProductByCat(dd, ref ss, idCat);
            Static.pageNum = ss;
            ti.SpecialProduct = pm.SelectProduct();
            ti.Tag = pm.GetTag().Take(6);
            return View("../Home/Index", ti);
        }
        public ActionResult Brand()
        {
            ProductModel pm = new ProductModel();
            TransportIndex ti = new TransportIndex();
            int idBr;
            int dd;
            try
            {
                dd = Convert.ToInt32(Request.Params["page"]) == 0 ? 1 : Convert.ToInt32(Request.Params["page"]);
                idBr = Convert.ToInt32(Request.Params["Brand"]);
            }
            catch
            {
                dd = 1;
                idBr = 1;
            }
            int ss = 0;
            ti.ListProduct = pm.SelectProductByCat(dd, ref ss, idBr);
            Static.pageNum = ss;
            ti.SpecialProduct = pm.SelectProduct();
            ti.Tag = pm.GetTag().Take(6);
            return View("../Home/Index", ti);
        }
        public ActionResult Product()
        {
            try
            {
                int id = Convert.ToInt32(Request.Params["id"]);
                if (id != 0)
                {
                    Product pro = (new ProductModel()).SelectProduct(id);
                    return View("Detail", pro);
                }
                else
                    return View("Error");
            }
            catch
            {
                return View("Error");
            }

        }
    }
}