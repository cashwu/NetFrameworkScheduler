using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using testQuartz.Jobs;

namespace testQuartz
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Console.WriteLine($"--- application start {DateTime.Now}---");
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            JobScheduler.Start().GetAwaiter().GetResult();
            Console.WriteLine($"--- application start eee end {DateTime.Now}---");
        }
    }
}