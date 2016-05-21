using System.Web.Optimization;

namespace LTWEB2.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/script/jquery").Include(
                        "~/Scripts/jquery-1.11.1.js"));

            bundles.Add(new ScriptBundle("~/script/jqueryval").Include(
                        "~/Scripts/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/script/modernizr").Include(
                        "~/Scripts/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/script/bootstrap").Include(
                      "~/Scripts/Scripts/bootstrap.js",
                      "~/Scripts/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/css/bootstrap").Include(
                      "~/Content/Content/bootstrap.css",
                      "~/Content/Content/custom_bootstrap.css"
                        ));

            //my script
            bundles.Add(new ScriptBundle("~/script/myscripts").Include(
                "~/Scripts/Scripts/default.js"
            ));

            //my style
            bundles.Add(new StyleBundle("~/css/mystyles").Include(
                "~/Content/Content/default.css"

            ));
        }
    }
}