using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace EcommerceSystem.Spec.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private static IHost _host;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _host = WebApplication.CreateBuilder().Build();

            _host.Start();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _host.StopAsync().Wait();
        }
    }
}
