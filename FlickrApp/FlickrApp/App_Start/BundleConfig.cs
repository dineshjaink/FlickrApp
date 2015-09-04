using System.Web;
using System.Web.Optimization;

namespace FlickrApp
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

            bundles.Add(new ScriptBundle("~/bundles/script").Include(
                        "~/Scripts/script.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryfancy").Include(
                        "~/Scripts/jquery-migrate-1.2.1.js",
                        "~/Scripts/jquery.fancybox-1.3.4.pack.min.js")); 
           
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
           
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/Style").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css"));           
        }
    }
}
