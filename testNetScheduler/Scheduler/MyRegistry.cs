using FluentScheduler;

namespace testNetScheduler.Scheduler
{
    public class MyRegistry : Registry
    {
        public MyRegistry()
        {
            Schedule<MyJob>().ToRunNow().AndEvery(10).Seconds();

            Schedule<MyJob2>().NonReentrant().ToRunEvery(3).Seconds();
        }
    }
}