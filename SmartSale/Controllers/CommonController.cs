using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartSale.Until;
using SmartSale.Models.TransportModels;
using System.Collections;
namespace SmartSale.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        public String PagePartion()
        {
            //< ul id = "pagination-digg" >
            //    <li class="previous-off">«Previous</li>
            //    <li class="active">1</li>
            //    <li><a href="?page=2">2</a></li>
            //    <li class="next"><a href="?page=2" >Next »</a></li>
            //</ul>
            int cur;
            int page = Static.pageNum;
            String cat = "&cat=", brand = "&brand=";
            String html = "<ul id=\"pagination-digg\">";
            try
            {
                cat = Convert.ToInt32(Request.Params["cat"]) == 0 ? "" : cat + Convert.ToInt32(Request.Params["cat"]);
            }
            catch
            {
                cat = "";
            }
            try
            {
                brand = Convert.ToInt32(Request.Params["brand"]) == 0 ? "" : brand + Convert.ToInt32(Request.Params["brand"]);
            }
            catch
            {
                brand = "";
            }
            try
            {
                cur = Convert.ToInt32(Request.Params["page"]) == 0 ? 1 : Convert.ToInt32(Request.Params["page"]);
            }
            catch
            {
                cur = 1;
            }
            if (cur != 1)
                html = html + "<li class=\"next\"><a href=\"?page=" + (cur - 1) + cat + brand + "\">«Previous</a></li>";
            for (int i = (cur - 5) < 0 ? 1 : (cur - 5); i <= ((cur + 4) >= page ? page : (cur + 4)); i++)
            {
                if (i == cur)
                    html = html + "<li class=\"active\">" + i + "</li>";
                else
                    html = html + "<li><a href=\"?page=" + i + cat + brand + "\">" + i + "</a></li>";
            }
            if (cur != page)
                html = html + "<li class=\"next\"><a href=\"?page=" + (cur + 1) + cat + brand + "\">Next »</a></li>";
            return html + "</ul>";
        }
        public ActionResult SideBar()
        {

            return View("sidebar", new TransportSidebar());
        }
        public ActionResult Cart()
        {
            int total = 0;
            if (Session["ShoppingCart"] == null)
            {
                Session.Add("ShoppingCart", new ShoppingCart());   
            }
            total = ((ShoppingCart)Session["ShoppingCart"]).GetNumberItem();
            return View(total);
        }
    }
}