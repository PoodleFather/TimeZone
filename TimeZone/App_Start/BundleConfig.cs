using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace TimeZone.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            ScriptBundle bootstrapbndl = new ScriptBundle("~/bundles/bootstrap");
            
            bootstrapbndl.Include(
                                "~/Scripts/bootstrap.js",
                                "~/Scripts/respond.js"
                              );
            
            bundles.Add(bootstrapbndl);
            ScriptBundle jquerybndl = new ScriptBundle("~/bundles/jquery");

            bootstrapbndl.Include(
                                "~/Scripts/jquery-1.10.2.js"
                              );

            bundles.Add(jquerybndl);

            ScriptBundle angularbndl = new ScriptBundle("~/bundles/angular");

            angularbndl.Include(
                                "~/Scripts/angular.js",
                                "~/Scripts/underscore.js"
                              );

            bundles.Add(angularbndl);

            BundleTable.EnableOptimizations = true;
        }
    }
}