using System;
using System.Threading.Tasks;

namespace Quartz.NetCore.Web.Jobs
{
    public class JobA : IJob
    {
        private readonly ITestService _testService;

        public JobA(ITestService testService)
        {
            _testService = testService;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _testService.Test();
            var jobKey = context.JobDetail.Key;
            Console.WriteLine("JobA says: {0} executing at {1}", jobKey, DateTime.Now.ToString("r"));
            return Task.FromResult(0);
        }
    }
}