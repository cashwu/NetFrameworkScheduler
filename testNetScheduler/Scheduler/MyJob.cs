using System;
using System.Threading;
using Autofac;
using FluentScheduler;

namespace testNetScheduler.Scheduler
{
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