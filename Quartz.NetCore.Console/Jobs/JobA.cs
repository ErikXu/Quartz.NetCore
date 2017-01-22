using System;
using System.Threading.Tasks;

namespace Quartz.NetCore.Console.Jobs
{
    public class JobA : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            JobKey jobKey = context.JobDetail.Key;
            System.Console.WriteLine("JobA says: {0} executing at {1}", jobKey, DateTime.Now.ToString("r"));
            return Task.FromResult(0);
        }
    }
}