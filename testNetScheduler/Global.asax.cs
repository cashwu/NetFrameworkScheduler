using System;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using FluentScheduler;
using testNetScheduler.Scheduler;

namespace testNetScheduler
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IContainer Container { get; private set; }

        protected void Application_Start()
        {
            Console.WriteLine($"--- application start begin {DateTime.Now}---");
            Console.WriteLine($"--- start job {DateTime.Now}---");

            JobManager.JobException += info =>
            {
                Console.WriteLine("--- error ---");
                Console.WriteLine(info.Exception.ToString());
            };
            
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            var builder = new ContainerBuilder();

            builder.RegisterType<Test>().As<ITest>().InstancePerLifetimeScope();

            var container = builder.Build();

            Container = container;

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            
            JobManager.Initialize(new MyRegistry());
            
            Console.WriteLine($"--- application start end {DateTime.Now}---");
        }
    }

    public interface ITest
    {
        int Get();
    }

    public class Test : ITest
    {
        public int Get()
        {
            return 123;
        }
    }
}