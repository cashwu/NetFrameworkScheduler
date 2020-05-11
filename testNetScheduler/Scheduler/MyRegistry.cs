using System;
using System.Threading;
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
            Console.WriteLine($"MyJob2 123 - {DateTime.Now}");
        }
    }

    internal class MyJob : IJob
    {
        public void Execute()
        {
            Thread.Sleep(5000);
            Console.WriteLine($"MyJob 123 - {DateTime.Now}");
        }
    }
}