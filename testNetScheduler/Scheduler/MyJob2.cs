using System;
using System.Threading;
using System.Web.Hosting;
using FluentScheduler;

namespace testNetScheduler.Scheduler
{
    public class MyJob2 : IJob, IRegisteredObject
    {
        private readonly object _lock = new object();
        private bool _shuttingDown;
        public MyJob2()
        {
            HostingEnvironment.RegisterObject(this);     
        }
        
        public void Execute()
        {
            try
            {
                lock (_lock)
                {
                    if (_shuttingDown)
                    {
                        return;
                    }

                    Thread.Sleep(TimeSpan.FromSeconds(5));
                    Console.WriteLine($"MyJob 02 every 3s - {DateTime.Now}");
                }
            }
            finally
            {
                HostingEnvironment.UnregisterObject(this);
            }
        }

        public void Stop(bool immediate)
        {
            lock (_lock)
            {
                _shuttingDown = true;
            }
            
            HostingEnvironment.UnregisterObject(this);
        }
    }
}