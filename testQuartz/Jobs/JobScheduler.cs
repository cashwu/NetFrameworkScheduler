using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;

namespace testQuartz.Jobs
{
    /// <summary>
    /// https://www.cnblogs.com/youring2/p/quartz_net.html
    /// </summary>
    public class JobScheduler
    {
        private static IScheduler _scheduler;

        public static async Task Start()
        {
            LogProvider.SetCurrentLogProvider(new QLog());
            
            _scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            
            await _scheduler.Start();

            var jobDetail = JobBuilder.Create<TestJob01>()
                                      .WithIdentity("test job 01", "group 01")
                                      .WithDescription("desc 01")
                                      .SetJobData(new JobDataMap
                                      {
                                          new KeyValuePair<string, object>("k", "abc")
                                      })
                                      .Build();

            var trigger = TriggerBuilder.Create()
                                        .WithIdentity("job name")
                                        .StartAt(DateTimeOffset.Now.AddSeconds(10))
                                        // .WithSimpleSchedule(a => a.WithIntervalInSeconds(10).RepeatForever())
                                        // .WithSimpleSchedule(a => a.WithIntervalInSeconds(10).WithRepeatCount(1))
                                        .WithSimpleSchedule(a => a.WithIntervalInSeconds(10).WithRepeatCount(0))
                                        .Build();

            await _scheduler.ScheduleJob(jobDetail, trigger);
        }

        public static async Task Stop()
        {
            await _scheduler.Shutdown();
        }
    }

    class QLog : ILogProvider
    {
        public Logger GetLogger(string name)
        {
            return (level, func, exception, parameters) =>
            {
                if (level >= LogLevel.Info && func != null)
                {
                    Console.WriteLine("[" + DateTime.Now.ToLongTimeString() + "] [" + level + "] " + func(), parameters);
                }
                return true;
            };
        }

        public IDisposable OpenNestedContext(string message)
        {
            throw new NotImplementedException();
        }

        public IDisposable OpenMappedContext(string key, string value)
        {
            throw new NotImplementedException();
        }
    }
}