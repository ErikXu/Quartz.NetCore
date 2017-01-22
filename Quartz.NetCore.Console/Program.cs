using System;
using System.Threading.Tasks;
using Quartz.Impl;

namespace Quartz.NetCore.Console
{
    public class Program
    {
        private static IScheduler _sched;
        public static void Main(string[] args)
        {
            System.Console.CancelKeyPress += Exit;

            Run().Wait();

            System.Console.ReadKey();
        }

        private static async Task Run()
        {
            var sf = new StdSchedulerFactory();
            _sched = await sf.GetScheduler();
            await _sched.Start();
        }

        private static void Exit(object sender, ConsoleCancelEventArgs args)
        {
            _sched.Shutdown(false).Wait();
        }
    }
}
