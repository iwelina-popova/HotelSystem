namespace HotelSystem.Web
{
    using System.Web.Optimization;

    public static class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //// bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            ////             "~/Scripts/jquery-{version}.js"));
            ////
            //// bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            ////             "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //// bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            ////             "~/Scripts/modernizr-*"));

            //// bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            ////           "~/Scripts/bootstrap.js",
            ////           "~/Scripts/respond.js"));
            ////
            //// bundles.Add(new StyleBundle("~/Content/css").Include(
            ////           "~/Content/bootstrap.css",
            ////           "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css/custom").Include(
                "~/Content/custom/bootstrap.css",
                "~/Content/custom/JFFormStyle-1.css",
                "~/Content/custom/jquery-ui.css",
                "~/Content/custom/owl.carousel.css",
                "~/Content/custom/style.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/custom/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                "~/Scripts/custom/JFCore.js",
                "~/Scripts/custom/JFForms.js",
                "~/Scripts/custom/jquery-ui.js",
                "~/Scripts/custom/jquery.flexisel.js",
                "~/Scripts/custom/owl.carousel.js",
                "~/Scripts/custom/responsiveslides.min.js"));
        }
    }
}
