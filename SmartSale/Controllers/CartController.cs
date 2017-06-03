using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartSale.Until;
using System.Collections;
using SmartSale.Models.BaseModels;
using SmartSale.Models;

namespace SmartSale.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult AddItem()
        {
            try
            {

                int id = Convert.ToInt32(Request.Params["id"]);

                if (id == 0)
                    throw new Exception();
                else
                {
                    ShoppingCart ss = (ShoppingCart)Session["ShoppingCart"];
                    if (Session["ShoppingCart"] == null)
                    {
                        ss = new ShoppingCart();
                    }
                    ss.AddToCard(id, 1);
                    //   int s=((ShoppingCart)Session["ShoppingCart"]).GetNumberItem();
                    Response.Redirect(Request.UrlReferrer.PathAndQuery);

                }
            }
            catch
            {
                //
            }
            return View();
        }
        public void RemoveItem()
        {
            try
            {
                int id = Convert.ToInt32(Request.Params["id"]);
                if (id == 0)
                    throw new Exception();
                else
                {
                    ShoppingCart ss = (ShoppingCart)Session["ShoppingCart"];
                    if (Session["ShoppingCart"] == null)
                    {
                        ss = new ShoppingCart();
                    }
                    ss.RemoveItem(id);
                    Response.Redirect(Request.UrlReferrer.PathAndQuery);
                }
            }
            catch
            {
                Response.Redirect(Request.UrlReferrer.PathAndQuery);
            }
            //  return View();
        }
        //
        public ActionResult FormBill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HandleCart()
        {
            if ("Cập nhật đơn hàng".Equals(Request.Params["Submit"]))
            {
                ShoppingCart ss = (ShoppingCart)Session["ShoppingCart"];
                if (Session["ShoppingCart"] == null)
                {
                    ss = new ShoppingCart();
                }
                IEnumerator ll = ss.Key();
               while (ll.MoveNext())
                {
                    object temp = ll.Current;
                    ss.UpdateItem((int)temp,Convert.ToInt32(Request.Params[temp.ToString()]));
                }
                Response.Redirect(Request.UrlReferrer.PathAndQuery);
            }
            return View();
        }
        public void ClearCart()
        {
            try
            {
                ShoppingCart ss = (ShoppingCart)Session["ShoppingCart"];
                if (Session["ShoppingCart"] == null)
                {
                    ss = new ShoppingCart();
                }
                ss.RemoveAll();
                Response.Redirect(Request.UrlReferrer.PathAndQuery);
            }
            catch
            {
            }
        }
        public ActionResult ViewCart()
        {
            return View();
        }
        [HttpPost]
        public void Action()
        {
            ShoppingCart ss = (ShoppingCart)Session["ShoppingCart"];
            BillModel bm = new BillModel();
            Bill bill = new Bill();
            bill.DateTime = DateTime.Now;
            bill.Email = Request["email"];
            bill.Address = Request["address"];
            bill.PhoneNumber = Request["phone"];
            bm.InsertBill(bill,ss.Cart());
            Session["ShoppingCart"] = new ShoppingCart();
            Response.Redirect(Request.UrlReferrer.PathAndQuery);
        }
    }
}