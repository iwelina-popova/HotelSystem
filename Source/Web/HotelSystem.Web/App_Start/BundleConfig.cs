namespace HotelSystem.Web
{
    using System.Web.Optimization;

    public static class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScrips(bundles);
            RegisterStyles(bundles);
        }

        private static void RegisterScrips(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                "~/Scripts/custom/JFCore.js",
                "~/Scripts/custom/JFForms.js",
                "~/Scripts/custom/jquery-ui.js",
                "~/Scripts/custom/jquery.flexisel.js",
                "~/Scripts/custom/owl.carousel.js",
                "~/Scripts/custom/responsiveslides.min.js"));
        }

        private static void RegisterStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css/bootstrap").Include(
               "~/Content/custom/bootstrap.css"));
            bundles.Add(new StyleBundle("~/Content/css/custom").Include(
                 "~/Content/custom/JFFormStyle-1.css",
                 "~/Content/custom/jquery-ui.css",
                 "~/Content/custom/owl.carousel.css",
                 "~/Content/custom/style.css"));
        }
    }
}
