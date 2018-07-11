using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Unity.Microsoft.DependencyInjection;
using NLog;
using NLog.Web;

namespace TEST.API.Analytics.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                var host = BuildWebHost(args);
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<Model>();
                    DbInitializer.Initialize(context);
                }
                host.Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Failed to start program due to exception.");
            } finally
            {
                LogManager.Shutdown();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUnityServiceProvider()
                .UseStartup<Startup>()
                .ConfigureLogging(logging => 
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                })
                .UseNLog()
                .Build();
    }
}
