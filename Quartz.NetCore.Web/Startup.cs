using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz.NetCore.Web.Jobs;
using Quartz.Spi;

namespace Quartz.NetCore.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<JobA, JobA>();
            services.AddSingleton<JobB, JobB>();
            services.AddSingleton<Func<Type, IJob>>(n =>
            {
                return t => n.GetService(t) as IJob;
            });

            services.AddSingleton<IJobFactory, JobFactory>();
            services.AddSingleton<IQuartzService, QuartzService>();

            services.AddSingleton<ITestService, TestService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseQuartz();
        }
    }
}
