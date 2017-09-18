using System.Web;
using System.Web.Optimization;

namespace RYLLight
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            // 轮播展示产品js
            bundles.Add(new ScriptBundle("~/bundles/owl").Include(
                "~/Scripts/owl.carousel.js",
                "~/Scripts/ledinpro.js",
                "~/Scripts/glide.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/owl.carousel.css", 
                      "~/Content/owl.theme.css",
                      "~/Content/glide.core.min.css",
                      "~/Content/glide.theme.min.css"));
        }
    }
}
