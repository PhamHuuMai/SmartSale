using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartSale.Models.BaseModels;
using SmartSale.Areas.Admin2.Models;
using SmartSale.Models;
namespace SmartSale.Areas.Admin2.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        CategoryModel cat = new CategoryModel();
        public ActionResult Index()
        {
            if (Session["admin"] == null)
                Response.Redirect("~/Admin2/Home/Login");
            return View("Category");
        }

        public ActionResult CategoryTable()
        {
            if (Session["admin"] == null)
                Response.Redirect("~/Admin2/Home/Login");
            return View(cat.SelectCategory());
        }
        public ActionResult FormCategory()
        {
            if (Session["admin"] == null)
                Response.Redirect("~/Admin2/Home/Login");
            int id = Convert.ToInt32(Request.Params["id"]);
            ModelFormCategory m = new ModelFormCategory(cat.SelectCategory(id), cat.SelectParentCategory());
            return View(m);
        }
        public ActionResult DeleteCategory()
        {
            if (Session["admin"] == null)
                Response.Redirect("~/Admin2/Home/Login");
            try
            {
                int id = Convert.ToInt32(Request.Params["id"]);
                cat.DeleteCategory(id);
            }
            catch
            {

            }
            return View("CategoryTable", cat.SelectCategory());
        }
        [HttpPost]
        public ActionResult HandleForm()
        {
            if (Session["admin"] == null)
                Response.Redirect("~/Admin2/Home/Login");
            try
            {
                String id = Request.Params["id"];
                if (id.Equals("0"))
                {
                    Category c = new Category();
                    c.CategoryName = Request.Params["name"];
                    if (Request.Params["parent"].Equals("0"))
                        c.CategoryParent = null;
                    else
                        c.CategoryParent = Convert.ToInt32(Request.Params["parent"]);
                    cat.InsertCategory(c);
                }
                else
                {
                    Category c = new Category();
                    c.ID= Convert.ToInt32(Request.Params["id"]);
                    c.CategoryName = Request.Params["name"];
                    if (Request.Params["parent"].Equals("0"))
                        c.CategoryParent = null;
                    else
                        c.CategoryParent = Convert.ToInt32(Request.Params["parent"]);
                    cat.UpdateCategory(c);
                }
            }
            catch(Exception ee) {
            }
            return View("Category");
        }

    }
}