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

            routes.MapRoute(HomeRoutes.Home, String.Empty);
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

            routes.MapRoute(StudentRoutes.Add, "Student/Add");
            routes.MapRoute(StudentRoutes.Edit, "Student/Edit/{id}");
            routes.MapRoute(StudentRoutes.Notes, "Student/Notes/{id}");
            routes.MapRoute(StudentRoutes.Activate, "Student/Activate/{id}");
            routes.MapRoute(StudentRoutes.Graduate, "Student/Graduate/{id}");
            routes.MapRoute(StudentRoutes.Expelle, "Student/Expelle/{id}");

            routes.MapRoute(ProfessorRoutes.Add, "Professor/Add");
            routes.MapRoute(ProfessorRoutes.Edit, "Professor/Edit/{id}");

            routes.MapRoute(SyllabusRoutes.Index, "Syllabus/{id}");
            routes.MapRoute(SyllabusRoutes.Add, "Syllabus/Add");
            routes.MapRoute(SyllabusRoutes.Edit, "Syllabus/Edit/{id}");

            routes.MapRoute(SubjectRoutes.Subject, "Subject/{id}");
            routes.MapRoute(SubjectRoutes.Add, "Subject/Add");
            routes.MapRoute(SubjectRoutes.Edit, "Subject/Edit/{id}");
        }
    }

    public class HomeRoutes
    {
        public const string Home = "iseu.home";
        public const string Login = "iseu.home-login";
        public const string Register = "iseu.home-register";
        public const string Logout = "iseu.home-logout";
    }

    public class AdminRoutes
    {
        public const string Ban = "iseu.admin-ban";
        public const string Unban = "iseu.admin-unban";
        public const string SetRole = "iseu.admin-set";
    }

    public class SyllabusRoutes
    {
        public const string Index = "iseu.syllabus";
        public const string Add = "iseu.syllabus-add";
        public const string Edit = "iseu.syllabus-edit";
    }

    public class SearchRoutes
    {
        public const string Index = "iseu.search";
        public const string Group = "iseu.search-group";
    }

    public class UserRoutes
    {
        public const string Index = "iseu.index";
        public const string Add = "iseu.user-add";
        public const string Edit = "iseu.user-edit";
    }

    public class StudentRoutes
    {
        public const string Add = "iseu.student-add";
        public const string Edit = "iseu.student-edit";
        public const string Notes = "iseu.student-notes";
        public const string Graduate = "iseu.student-graduate";
        public const string Expelle = "iseu.student-expelle";
        public const string Activate = "iseu.student-activate";
    }

    public class ProfessorRoutes
    {
        public const string Add = "iseu.professor-add";
        public const string Edit = "iseu.professor-edit";
    }

    public class SubjectRoutes
    {
        public const string Subject = "iseu.subject";
        public const string Add = "iseu.subject-add";
        public const string Edit = "iseu.subject-edit";
    }
}