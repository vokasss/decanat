using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;

namespace Iseu.Routing
{
    public static class RouteCollectionExtension
    {
        public static void RegisterRoutes(this RouteCollection routes)
        {
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
            routes.MapRoute(HomeRoutes.Home, "Home/Index");
            routes.MapRoute(HomeRoutes.Login, "Home/Login");
            routes.MapRoute(HomeRoutes.Register, "Home/Register");
            routes.MapRoute(HomeRoutes.Logout, "Home/Logout");
            routes.MapRoute(HomeRoutes.Search, "Home/Search");
            /*routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });*/
        }
    }
    public class HomeRoutes
    {
        public const string Home = "iseu.home";
        public const string Login = "iseu.login";
        public const string Register = "iseu.register";
        public const string Logout = "iseu.logout";
        public static string Search = "iseu.search";
        /*public static string Home = "iseu.home";
        public static string Home = "iseu.home";
        public static string Home = "iseu.home";
        public static string Home = "iseu.home";*/
    }
}