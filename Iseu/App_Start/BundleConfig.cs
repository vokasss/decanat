using System.Web;
using System.Web.Optimization;

namespace Iseu
{
    public class BundleConfig
    {
        // Дополнительные сведения о Bundling см. по адресу http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Resources/Scripts/jquery-{version}.js",
                        "~/Resources/Scripts/jquery-1.8.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                       "~/Resources/Scripts/main.js",
                       "~/Resources/Scripts/admin.js",
                       "~/Resources/Scripts/syllabus.js",
                       "~/Resources/Plugins/arcticModal/jquery.arcticmodal.js",
                       "~/Resources/Plugins/jqModal/jqModal.js"));
            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство построения на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Resources/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Resources/Styles/css").Include(
                "~/Resources/Styles/index.css",
                "~/Resources/Styles/header.css",
                "~/Resources/Styles/table.css",
                "~/Resources/Styles/sidebar.css",
                "~/Resources/Styles/list.css",
                "~/Resources/Styles/footer.css",
                "~/Resources/Styles/register.css",
                "~/Resources/Styles/add.css",
                "~/Resources/Styles/profile.css",
                "~/Resources/Plugins/arcticModal/themes/dark.css",
                "~/Resources/Plugins/arcticModal/themes/simple.css",
                "~/Resources/Plugins/arcticModal/jquery.arcticmodal-0.3.css"
                ));
        }
    }
}