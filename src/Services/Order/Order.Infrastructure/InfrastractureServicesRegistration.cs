using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Application.Contracts.Infra;
using Order.Domain.Abstraction;
using Order.Application.Models;
using Order.Infrastructure.EntityFramework;
using Order.Infrastructure.Infra;
using Order.Infrastructure.Repositories;
using Order.Domain.Repositories;
using Order.Infrastructure.EntityFramework.Interceptors;
using Quartz;
using Order.Infrastructure.BackgroundJobs;

using System.Xml.Linq;

namespace Order.Infrastructure
{
    public static class InfrastractureServicesRegistration
    {
        public static IServiceCollection AddInfrastractureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ConvertDomainEventToOutboxMessageInterceptor>();
            
            services.AddDbContext<OrderContext>((sp,options) => 
            {
                var interceptor = sp.GetService<ConvertDomainEventToOutboxMessageInterceptor>();
                options.UseSqlServer(configuration.GetConnectionString("OrderingConnectionString"))
                .AddInterceptors(interceptor);
             });
            
            services.AddQuartz(config =>
            {
                var jobKey = new JobKey(nameof(ProcessOutboxMessagesJob));

                config.AddJob<ProcessOutboxMessagesJob>(jobKey)
                        .AddTrigger(trigger =>
                            trigger.ForJob(jobKey)
                           .WithSimpleSchedule(schedule =>
                                schedule.WithIntervalInSeconds(5)
                            )); 
            });

            services.AddQuartzHostedService();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            return services;
        }
    }
}
