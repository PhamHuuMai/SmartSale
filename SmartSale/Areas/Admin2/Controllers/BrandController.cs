using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartSale.Models.BaseModels;
using SmartSale.Models;
namespace SmartSale.Areas.Admin2.Controllers
{
    public class BrandController : Controller
    {
        BrandModel br = new BrandModel();
        // GET: Admin/Brand
        public ActionResult Index()
        {
            if (Session["admin"] == null)
                Response.Redirect("~/Admin2/Home/Login");
            return View("Brand");
        }
        public ActionResult TableBrand()
        {
            if (Session["admin"] == null)
                Response.Redirect("~/Admin2/Home/Login");
            return View(br.SelectListBrand());
        }
        public ActionResult DeleteBrand()
        {
            if (Session["admin"] == null)
                Response.Redirect("~/Admin2/Home/Login");
            try
            {
                int id = Convert.ToInt32(Request.Params["id"]);
                br.DeleteBrand(id);
            }
            catch
            {

            }
            return View("TableBrand", br.SelectListBrand());
        }
       
        public ActionResult FormBrand()
        {
            if (Session["admin"] == null)
                Response.Redirect("~/Admin2/Home/Login");
            Brand brand = new Brand();
            try
            {
              int id=Convert.ToInt32(Request.Params["id"]);
              if(id!=0)
                brand = br.SelectBrand(id);  
            }
            catch
            {

            }
            return View(brand);
        }
        [HttpPost]
        public ActionResult HandleFormBrand()
        {
            if (Session["admin"] == null)
                Response.Redirect("~/Admin2/Home/Login");
            try
            {
                String id = Request.Params["id"];
                String name = Request.Params["name"];
                String fromTo = Request.Params["fromto"];
                if (id.Equals("0"))
                {
                    Brand brand = new Brand();
                    brand.BrandName = name;
                    brand.FromTo = fromTo;
                    br.InsertBrand(brand);
                }
                else
                {
                    Brand brand = new Brand();
                    brand.ID = Convert.ToInt32(id);
                    brand.BrandName = name;
                    brand.FromTo = fromTo;
                    br.UpdateBrand(brand);
                }
            }
            catch
            {

            }
            return View("Brand");
        }

    }
}