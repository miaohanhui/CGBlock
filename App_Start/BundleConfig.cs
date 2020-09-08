using System.Web;
using System.Web.Optimization;

namespace CGBlcok
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备就绪，请使用 https://modernizr.com 上的生成工具仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/assets_css").Include(
                      "~/Content/assets/css/font-awesome.css",
                      "~/Content/assets/css/owl.carousel.css",
                      "~/Content/assets/css/owl.theme.css",
                      "~/Content/assets/css/bootstrap.min.css",
                      "~/Content/assets/css/style.css"));

            bundles.Add(new StyleBundle("~/Content/assets_js").Include(
                      "~/Content/assets/js/jquery-2.1.4.js",
                      "~/Content/assets/js/bootstrap.min.js",
                      "~/Content/assets/js/jquery.slicknav.js",
                      "~/Content/assets/js/isotope.pkgd.min.js",
                      "~/Content/assets/js/owl.carousel.js",
                      "~/Content/assets/js/main.js"));
        }
    }
}
