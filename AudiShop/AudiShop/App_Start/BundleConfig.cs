using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace AudiShop.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/JS/sc").Include("~/Scripts/jquery.unobtrusive-ajax.min.js")
                .Include("~/JS/BodyLoaded.js")
                .Include("~/Scripts/jquery.unobtrusive-ajax.js")
                .Include("~/Scripts/jquery-3.4.1.intellisense.js")
                .Include("~/Scripts/jquery-3.4.1.js")
                .Include("~/Scripts/jquery-3.4.1.min.js"));
            //bundles.Add(new ScriptBundle("~/Scripts/jquery.unobtrusive-ajax.min.js"));
        }
    }
}