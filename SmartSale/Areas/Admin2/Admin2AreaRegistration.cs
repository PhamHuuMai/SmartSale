using System.Web.Mvc;

namespace SmartSale.Areas.Admin2
{
    public class Admin2AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin2";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin2_default",
                "Admin2/{controller}/{action}/{id}",
                new { controller="Home" ,action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "SmartSale.Areas.Admin2.Controllers" }
            );
        }
    }
}