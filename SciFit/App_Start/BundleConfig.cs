using System.Web.Optimization;

namespace SciFit
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                    "~/Scripts/bootstrap.js",
                    "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/Site.css",
                    "~/Content/Plan.css",
                    "~/Content/fullcalendar.css"));

            bundles.Add(new StyleBundle("~/Content/default-theme").Include(
                    "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/journal-theme").Include(
                    "~/Content/journal.min.css"));

            bundles.Add(new StyleBundle("~/Content/cerulean-theme").Include(
                    "~/Content/cerulean.min.css"));

            bundles.Add(new StyleBundle("~/Content/green-theme").Include(
                    "~/Content/green.css"));

            bundles.Add(new StyleBundle("~/Content/orange-theme").Include(
                    "~/Content/orange.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/Scripts/angular/moment.js",
                      "~/Scripts/angular/jquery-1.11.3.js",//? leave or not
                      "~/Scripts/angular/angular.js",
                      "~/Scripts/angular/calendar.js",
                      "~/Scripts/angular/fullcalendar.js",
                      "~/Scripts/angular/gcal.js",
                      "~/Scripts/angular/myApp.js"
            ));
        }
    }
}
