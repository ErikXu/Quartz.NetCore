using System.Threading.Tasks;
using Quartz.Impl;
using Quartz.Spi;

namespace Quartz.NetCore.Web
{
    public interface IQuartzService
    {
        Task Run();

        Task Stop();
    }

    public class QuartzService : IQuartzService
    {
        private readonly IJobFactory _jobFactory;
        private IScheduler _scheduler;

        public QuartzService(IJobFactory jobFactory)
        {
            _jobFactory = jobFactory;
        }

        public async Task Run()
        {
            var sf = new StdSchedulerFactory();
            _scheduler = await sf.GetScheduler();
            _scheduler.JobFactory = _jobFactory;
            await _scheduler.Start();
        }

        public async Task Stop()
        {
            await _scheduler.Shutdown(true);
        }
    }
}