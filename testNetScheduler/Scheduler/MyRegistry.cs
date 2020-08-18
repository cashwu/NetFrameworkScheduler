using System;
using System.Threading;
using System.Web.Mvc;
using Autofac;
using FluentScheduler;

namespace testNetScheduler.Scheduler
{
    public class MyRegistry : Registry
    {
        public MyRegistry()
        {
            Schedule<MyJob>().ToRunNow().AndEvery(10).Seconds();

            Schedule<MyJob2>().ToRunEvery(20).Seconds();
        }
    }

    public class MyJob2 : IJob
    {
        public void Execute()
        {
            Thread.Sleep(5000);
            Console.WriteLine($"MyJob 02 every 20s - {DateTime.Now}");
        }
    }

    internal class MyJob : IJob
    {
        private readonly ITest _test;

        public MyJob()
        {
            _test = MvcApplication.Container.Resolve<ITest>();
        }
        
        public void Execute()
        {
            Thread.Sleep(5000);
            Console.WriteLine($"MyJob 01 every 10s , {_test.Get()} - {DateTime.Now}");
        }
    }
}