using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartSale.Models;
using SmartSale.Models.BaseModels;
using SmartSale.Areas.Admin2.Models;
using System.IO;

namespace SmartSale.Areas.Admin2.Controllers
{
    public class ProductController : Controller
    {
        ProductModel pro = new ProductModel();
        // GET: Admin/Product
        public ActionResult Index()
        {
            if (Session["admin"] == null)
                Response.Redirect("~/Admin2/Home/Login");
            return View("Product");
        }

        public ActionResult SeachProduct(String key)
        {
            return View("SeachProduct", pro.SeachProduct(key));
        }

        public ActionResult ProductTable()
        {
            if (Session["admin"] == null)
                Response.Redirect("~/Admin2/Home/Login");
            return View(pro.SelectALLProduct());
        }
        public ActionResult DeleteProduct()
        {
            if (Session["admin"] == null)
                Response.Redirect("~/Admin2/Home/Login");
            try
            {
                int id = Convert.ToInt32(Request.Params["id"]);
                pro.DeleteProduct(id);
            }
            catch
            {
            }
            return View("ProductTable", pro.SelectALLProduct());
        }
        public ActionResult FormProduct()
        {
            if (Session["admin"] == null)
                Response.Redirect("~/Admin2/Home/Login");
            ModelFormProduct m = new ModelFormProduct();
            try
            {
                int id = Convert.ToInt32(Request.Params["id"]);
                m.Product = pro.SelectProduct(id);
                m.Brand = (new BrandModel()).SelectListBrand();
                m.Category = (new CategoryModel()).SelectCategory();
            }
            catch
            {

            }
            return View(m);
        }
        [HttpPost]
        public void UploadImg()
        {
            foreach (string upload in Request.Files)
            {
                if (Request.Files[upload].ContentLength == 0) continue;
                string pathToSave = Server.MapPath("~/Asset/images/");//Phần vị trí lưu File .
                string filename = Path.GetFileName(Request.Files[upload].FileName);
                DateTime now = DateTime.Now;
                filename = now.Year+""+now.Month+""+now.Day+""+now.Hour+""+now.Minute+""+now.Second+""+now.Millisecond+"."+filename.Split('.')[1];
                if (Session["queueimg"] == null)
                    Session["queueimg"] = "";
                else
                    Session["queueimg"] = Session["queueimg"] + filename + "-";
                Request.Files[upload].SaveAs(Path.Combine(pathToSave, filename));
                ModelState.AddModelError("", "Update thanh cong");
            }


        }
        [HttpPost]
        public void HandleForm()
        {
            int iden = 0;
            if (Session["admin"] == null)
                Response.Redirect("~/Admin2/Home/Login");
            try
            {
                String id = Request.Params["id"];
                if (id.Equals("0"))
                {
                    Product c = new Product();
                    c.ProductName = Request.Params["name"];
                    c.Description = Request.Params["description"];
                    c.Color = Request.Params["color"];
                    c.Model= Request.Params["model"];
                    c.NewPrice=Convert.ToDouble(Request.Params["price"]);
                    c.ReviewProduct= Request.Params["review"];
                    c.Size=Convert.ToInt32(Request.Params["size"]);
                    c.Tag= Request.Params["tag"];
                    c.IDBrand=Convert.ToInt32(Request.Params["brand"]);
                    c.IDCategory=Convert.ToInt32(Request.Params["category"]);
                    iden=pro.InsertProduct(c);
                }
                else
                {
                    Product p = new Product();
                    p.ID = Convert.ToInt32(Request.Params["id"]);
                    p.ProductName = Request.Params["name"];
                    p.Color = Request.Params["color"];
                    p.Description = Request.Params["description"];
                    p.Model = Request.Params["model"];
                    p.NewPrice =Convert.ToDouble(Request.Params["price"]);
                    p.ReviewProduct = Request.Params["review"];
                    p.Size =Convert.ToInt32(Request.Params["size"]);
                    p.Tag = Request.Params["tag"];
                    p.IDBrand = Convert.ToInt32(Request.Params["brand"]);
                    p.IDCategory = Convert.ToInt32(Request.Params["category"]);
                    string img = Request.Params["nonimg"];
                    String[] imgs= img.Split('-');
                    foreach(var i in imgs)
                    {
                        (new ImageModel()).DeleteImg(i);
                    }
                    pro.UpdateProduct(p);
                    iden = p.ID;
                }
                (new ImageModel()).InsertImg(iden, Session["queueimg"].ToString());
                Session["queueimg"] = "";
            }
            catch (Exception ee)
            {
            }
           // return View("Product");
        }
    }
}