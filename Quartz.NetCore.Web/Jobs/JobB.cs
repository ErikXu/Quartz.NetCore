using System;
using System.Threading.Tasks;

namespace Quartz.NetCore.Web.Jobs
{
    public class JobB : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            JobKey jobKey = context.JobDetail.Key;
            System.Console.WriteLine("JobB says: {0} executing at {1}", jobKey, DateTime.Now.ToString("r"));
            return Task.FromResult(0);
        }
    }
}