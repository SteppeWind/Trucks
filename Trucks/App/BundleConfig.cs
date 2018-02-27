using System.Web.Optimization;
using Trucks.Web.Common.App;

namespace Trucks.Web.App
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles()
        {
            BundleTable.Bundles.Add(new ScriptBundle("~/Scripts/common/bundle").Include("~/Scripts/helpers.js"));

            BundleTable.Bundles.Add(new ScriptBundle("~/Scripts/jquery/bundle").Include(
                "~/Scripts/jquery-{version}.js",      
                "~/Scripts/form2js.js",
                "~/Scripts/jquery.toObject.js"));

            BundleTable.Bundles.Add(new ScriptBundle("~/Scripts/jqueryValidation/bundle").Include(
                "~/Scripts/jquery.validate*"));

            BundleTable.Bundles.Add(new ScriptBundle("~/Scripts/bootstrap/bundle").Include(
                "~/Scripts/respond.js",
                "~/Scripts/popper.min.js",
                "~/Scripts/popper.js", 
                "~/Scripts/bootstrap.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/bootstrap-select.min.js"));

            BundleTable.Bundles.Add(new ScriptBundle("~/Scripts/jsRender/bundle").Include(
                "~/Scripts/jsrender.js",
                "~/Scripts/jsRender.ext.js"));

            BundleTable.Bundles.Add(new ScriptBundle("~/Scripts/datatable/bundle").Include(
                "~/Scripts/jquery.dataTables.js",
                "~/Scripts/jquery.dataTables.colReorder.js",
                "~/Scripts/jquery.dataTables.colResize.js",
                "~/Scripts/jquery.dataTables.buttons.js",
                "~/Scripts/jquery.dataTables.rowReorder.min.js"));

            BundleTable.Bundles.Add(new ScriptBundle("~/Scripts/underscore/bundle").Include(
                "~/Scripts/underscore.js"));

            BundleTable.Bundles.Add(new ScriptBundle("~/Scripts/backbone/bundle").Include(
                "~/Scripts/backbone.js"));

            BundleTable.Bundles.Add(new ScriptBundle("~/Scripts/modernizr/bundle").Include(
                        "~/Scripts/modernizr-2.8.3.js"));

            BundleTable.Bundles.Add(new StyleBundle("~/Content/site/bundle").Include(
                      "~/Content/main.css",
                      "~/Content/site.css"));

            BundleTable.Bundles.Add(new StyleBundle("~/Content/fonts/bundle").Include(
                "~/Content/fonts/font-awesome.min.css"));

            BundleTable.Bundles.Add(new StyleBundle("~/Content/bootstrap/bundle").Include(
                "~/Content/bootstrap-theme.css",
                "~/Content/bootstrap-theme.min.css",
                "~/Content/bootstrap.css",
                "~/Content/bootstrap.min.css",
                "~/Content/bootstrap-select.min.css"));

            BundleTable.Bundles.Add(new ScriptBundle("~/Scripts/app/modules/customers/list/bundle").IncludeDirectory(
                "~/Scripts/app/modules/customers/list", "*.js"));

            BundleTable.Bundles.Add(new ScriptBundle("~/Scripts/app/modules/customers/create/bundle").IncludeDirectory(
                "~/Scripts/app/modules/customers/create", "*.js"));

            BundleTable.Bundles.Add(new ScriptBundle("~/Scripts/app/modules/points/list/bundle").IncludeDirectory(
                "~/Scripts/app/modules/points/list", "*.js"));

            BundleTable.Bundles.Add(new ScriptBundle("~/Scripts/app/modules/points/create/bundle").IncludeDirectory(
                "~/Scripts/app/modules/points/create", "*.js"));

            BundleTable.Bundles.Add(new StyleBundle("~/Content/dataTables/css/bundle").Include(
                "~/Content/dataTables/css/jquery.dataTables.css",
                "~/Content/dataTables/css/jquery.dataTables.rowReorder.min.css"));
        }
    }
}