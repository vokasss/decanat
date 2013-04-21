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

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Resources/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Resources/Scripts/jquery.unobtrusive*",
                        "~/Resources/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                       "~/Resources/Scripts/main.js",
                       "~/Resources/Plugins/arcticModal/jquery.arcticmodal.js",
                       "~/Resources/Plugins/jqModal/jqModal.js"));
            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство построения на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Resources/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new StyleBundle("~/Resources/Styles/css").Include(
                "~/Resources/Styles/index.css",
                "~/Resources/Styles/header.css",
                "~/Resources/Styles/table.css",
                "~/Resources/Styles/sidebar.css",
                "~/Resources/Styles/list.css",
                "~/Resources/Styles/footer.css",
                "~/Resources/Styles/register.css",
                "~/Resources/Styles/add.css",
                "~/Resources/Plugins/arcticModal/themes/dark.css",
                "~/Resources/Plugins/arcticModal/themes/simple.css",
                "~/Resources/Plugins/arcticModal/jquery.arcticmodal-0.3.css"
                ));
        }
    }
}