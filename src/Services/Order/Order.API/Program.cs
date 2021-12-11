using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Order.Infrastructure.EntityFramework;
using Order.API.Extentions;
using Order.Infrastructure.EntityFramework.Seed;

namespace Order.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build()
                  .MigrateDatabase<OrderContext>((context, services) =>
                  {
                      var logger = services.GetService<ILogger<OderSeed>>();
                      OderSeed.SeedAsync(context, logger)
                          .Wait();
                  }).Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
