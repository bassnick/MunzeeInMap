using System.Web.Mvc;
using System.Web.Routing;

namespace MunzeeInMap
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            
            routes.MapRoute(
                name: "Autorizace",
                url: "Autorizace",
                defaults: new { controller = "Authorize", action = "Index", id = UrlParameter.Optional }
            );
            /*
            routes.MapRoute(
                name: "Autorizace2",
                url: "Autorizace2",
                defaults: new { controller = "Authorize", action = "Index2", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Print",
                url: "MunzeeInMap/Print",
                defaults: new {controller = "MunzeeInMap", action = "Print", id = UrlParameter.Optional}
            );
            */
            routes.MapRoute(
               name: "Battle1505",
               url: "Klani",
               defaults: new { controller = "ClanBattle", action = "Klani", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "MunzeeApi",
                url: "MunzeeInMap",
                defaults: new { controller = "MunzeeInMap", action = "BoundingBox", code = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "MunzeeApiSwitch",
                url: "MunzeeInMapSwitch",
                defaults: new { controller = "MunzeeInMap", action = "MunzeeApp", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "NewBattle",
                url: "TestNewBattle",
                defaults: new { controller = "ClanBattle", action = "NoveKlani", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ClanBattle", action = "Klani", id = UrlParameter.Optional }  
            );
            
        }
    }
}