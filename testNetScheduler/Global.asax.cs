using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FluentScheduler;
using testNetScheduler.Scheduler;

namespace testNetScheduler
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Console.WriteLine($"--- application start {DateTime.Now}---");
            Console.WriteLine($"--- start job {DateTime.Now}---");
            JobManager.Initialize(new MyRegistry());

            JobManager.JobException += info =>
            {
                Console.WriteLine("--- error ---");
                Console.WriteLine(info.Exception.ToString());
            };
            
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            Console.WriteLine($"--- application start end {DateTime.Now}---");
        }
    }
}