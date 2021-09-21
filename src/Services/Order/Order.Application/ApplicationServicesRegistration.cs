using FluentValidation;
using Microsoft.Extensions.Configuration;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Order.Application.Behaviours;
using Order.Application.Models;
using System.Reflection;

namespace Order.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));


            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationRequestBehaviour<,>));

            return services;
        }
    }
}
