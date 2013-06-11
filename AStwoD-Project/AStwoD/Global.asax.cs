using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AStwoD
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

             routes.MapRoute(
                 "Account", // Route name
                 "{controller}/{action}/{labelForURL}", // URL with parameters
                 new { controller = "Home", action = "LogOn", labelForURL = UrlParameter.Optional },
                 new { controller = "Account" } // Parameter defaults
             );

             routes.MapRoute(
                "Sitemap", // Route name
                "{controller}/{action}/{labelForURL}", // URL with parameters
                new { controller = "Home", action = "Index", labelForURL = UrlParameter.Optional },
                new { controller = "Sitemap" } // Parameter defaults
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{labelForURL}", // URL with parameters
                new { controller = "Home", action = "Index", labelForURL = UrlParameter.Optional },
                new { controller = "ControlPanel" } // Parameter defaults
            );



            routes.MapRoute(
              "HomeAction", // Route name
              "{action}", // URL with parameters
              new { controller = "Home", action = "Index" },
              new { action = "RequestRepair" } // Parameter defaults
          );



            routes.MapRoute(
              "DefaultCP", // Route name
              "{*labelForURL}", // URL with parameters
              new { controller = "Home", action = "Index", labelForURL = UrlParameter.Optional } // Parameter defaults
          );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}