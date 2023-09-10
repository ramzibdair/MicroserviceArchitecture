using Basket.API.ClientGprcServices;
using Basket.Domain.Reposities;
using Basket.Redis;
using Discount.Gprc;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;


namespace Basket.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Basket.API", Version = "v1" });
            });
            services.AddApiVersioning(opt =>
            {
                // Will provide the different api version which is available for the client
                opt.ReportApiVersions = true;
                // this configuration will allow the api to automaticaly take api_version=1.0 in case it was not specify
                opt.AssumeDefaultVersionWhenUnspecified = true;
                // We are giving the default version of 1.0 to the api
                opt.DefaultApiVersion = ApiVersion.Default; // new ApiVersion(1, 0);
            });
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration.GetValue<string>("Redis:ConnectionString");
            });

            services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(opt => 
            opt.Address = new Uri(Configuration.GetValue<string>("DiscountGprcServerSetting:Address")));
            // General Configuration

            // MassTransit-RabbitMQ Configuration
            services.AddMassTransit(config => {
                config.UsingRabbitMq((ctx, cfg) => {
                    cfg.Host(Configuration["EventBusSettings:HostAddress"]);
                });
            });
            services.AddMassTransitHostedService();

            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<DiscountServiceClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Basket.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
