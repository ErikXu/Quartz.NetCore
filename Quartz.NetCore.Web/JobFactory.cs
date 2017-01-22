using System;
using Quartz.Spi;

namespace Quartz.NetCore.Web
{
    public class JobFactory : IJobFactory
    {
        private readonly Func<Type, IJob> _factory;

        public JobFactory(Func<Type, IJob> factory)
        {
            _factory = factory;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return _factory(bundle.JobDetail.JobType);
        }

        public void ReturnJob(IJob job)
        {
           
        }
    }
}