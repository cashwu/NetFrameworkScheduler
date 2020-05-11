using System;
using System.Linq;
using System.Threading.Tasks;
using Quartz;

namespace testQuartz.Jobs
{
    public class TestJob01 : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            var dmap = context.JobDetail.JobDataMap.Select(a => $"{a.Key} - {a.Value}").FirstOrDefault();
            Console.WriteLine($"{context.JobDetail.Description}, {context.JobDetail.Key.Name}, {context.JobDetail.Key.Group} - {DateTime.Now}, {dmap}");
            
            return Task.CompletedTask;
        }
    }
}