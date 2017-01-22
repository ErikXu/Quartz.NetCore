using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Quartz.NetCore.Web
{
    public static class QuartzApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseQuartz(this IApplicationBuilder app)
        {
            var service = app.ApplicationServices.GetRequiredService<IQuartzService>();
            service.Run().Wait();
            return app;
        }
    }
}