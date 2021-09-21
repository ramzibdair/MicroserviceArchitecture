using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Application.Contracts.Infra;
using Order.Application.Contracts.Repositories;
using Order.Application.Models;
using Order.Infrastructure.EntityFramework;
using Order.Infrastructure.Infra;
using Order.Infrastructure.Repositories;


namespace Order.Infrastructure
{
   public static class InfrastractureServicesRegistration
    {
        public static IServiceCollection AddInfrastractureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("OrderingConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            return services;
        }
    }
}
