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

            routes.MapRoute(SearchRoutes.Index, "Search/Index");
            routes.MapRoute(SearchRoutes.Group, "Search/Group/{id}");

            routes.MapRoute(UserRoutes.Index, "User/Index/{id}");
            routes.MapRoute(UserRoutes.Add, "User/Add");
            routes.MapRoute(UserRoutes.Edit, "User/Edit/{id}");

            routes.MapRoute(AdminRoutes.SetRole, "Admin/SetRole/{id}");
            routes.MapRoute(AdminRoutes.Ban, "Admin/Ban/{id}");
            routes.MapRoute(AdminRoutes.Unban, "Admin/Unban/{id}");

           
        }
    }

    public class HomeRoutes
    {
        public const string Home = "iseu.home";
        public const string Login = "iseu.home-login";
        public const string Register = "iseu.home-register";
        public const string Logout = "iseu.home-logout";
    }

    public class SearchRoutes
    {
        public static string Index = "iseu.search";
        public static string Group = "iseu.search-group";
    }

    public class UserRoutes
    {
        public static string Index = "iseu.index";
        public static string Edit = "iseu.user-edit";
        public static string Add = "iseu.user-add";
    }

    public class AdminRoutes
    {
        public static string Ban = "iseu.admin-ban";
        public static string Unban = "iseu.admin-unban";
        public static string SetRole = "iseu.admin-set";
    }
}