using System;
using FluentScheduler;

namespace testNetScheduler.Scheduler
{
    public class MyRegistry : Registry
    {
        public MyRegistry()
        {
            Schedule<MyJob>().ToRunNow().AndEvery(20).Seconds();

            Schedule<MyJob2>().ToRunEvery(20).Seconds();
        }
    }

    public class MyJob2 : IJob
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }

    internal class MyJob : IJob
    {
        public void Execute()
        {
            Console.WriteLine($"test 123 - {DateTime.Now}");
        }
    }
}