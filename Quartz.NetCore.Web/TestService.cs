using System;

namespace Quartz.NetCore.Web
{
    public interface ITestService
    {
        void Test();
    }

    public class TestService : ITestService
    {
        public void Test()
        {
            Console.WriteLine("Test!");
        }
    }
}