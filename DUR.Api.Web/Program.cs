using System;
using System.IO;
using Autofac.Extensions.DependencyInjection;
using DUR.Api.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Slack;

namespace DUR.Api.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, true).AddJsonFile("appsettings.Development.json", true, true).AddEnvironmentVariables().Build();
            var logSettings = configuration.GetSection("LogSettings").Get<LogSettings>();

            Log.Logger = new LoggerConfiguration()
                .Enrich.WithProperty("Application", "DUR.API")
                .Enrich.WithProperty("Environment", "")
                .Enrich.WithMachineName()
                .Enrich.FromLogContext()
                .WriteTo.File(logSettings.LogPath, rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information)
                .WriteTo.Slack(new SlackSinkOptions()
                {
                    WebHookUrl = logSettings.SlackUrl,
                    CustomChannel = "#api",
                    BatchSizeLimit = 10,
                    CustomIcon = ":ghost:",
                    Period = TimeSpan.FromSeconds(10),
                    ShowDefaultAttachments = false,
                    ShowExceptionAttachments = true,
                }, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning)
                .CreateLogger();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
