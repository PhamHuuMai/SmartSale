using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SmartSale
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
           // AreaRegistration.RegisterAllAreas(routes);
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "SmartSale.Controllers" }

            );
            routes.MapRoute(
                name: "About",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
            );
           routes.MapRoute(
              name: "Category",
              url: "{controller}/{action}/{cat}/{id}",
              defaults: new { controller = "Redirect", action = "Category",cat= UrlParameter.Optional, id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "Brand",
              url: "{controller}/{action}/{cat}/{id}",
              defaults: new { controller = "Redirect", action = "Brand", cat = UrlParameter.Optional, id = UrlParameter.Optional }
          );

        }
    }
}
