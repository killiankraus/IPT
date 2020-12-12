using System.Web;
using System.Web.Optimization;

namespace SIA
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/sweetalert.min.js",
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/Login").Include(
                       "~/Scripts/jquery-{version}.js",
                       "~/Scripts/sweetalert.min.js",
                       "~/Scripts/jquery.validate.js",
                       "~/Scripts/login.js"));
            
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/Content/logincss").Include(
                        "~/Content/bootstrap.css",
                      "~/Content/login.css"));
            bundles.Add(new ScriptBundle("~/Content/registrationcss").Include(
                        "~/Content/bootstrap.css",
                      "~/Content/registration.css"));

        }
    }
}
