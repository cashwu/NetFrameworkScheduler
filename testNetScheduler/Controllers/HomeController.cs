using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac;
using FluentScheduler;

namespace testNetScheduler.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITest _test;

        public HomeController(ITest test)
        {
            _test = test;
        }
        
        public ActionResult Index()
        {
            Console.WriteLine($"action begin - {DateTime.Now}");    
            
            JobManager.AddJob(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
                
                var test = MvcApplication.Container.Resolve<ITest>();
                Console.WriteLine($"action job, {test.Get()} - {DateTime.Now}");    
            }, s =>
            {
                s.ToRunNow();
            });
            
            Console.WriteLine($"action end - {DateTime.Now}");    

            return View();
        }
    }
}