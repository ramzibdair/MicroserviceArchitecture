using IdentityServer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

[assembly: HostingStartup(typeof(IdentityServer.IdentityHostingStartup))]
namespace IdentityServer
{

    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<IdentityProviderContext>(options =>
                    options.UseSqlServer(
                        context.Configuration
                            .GetConnectionString("IdentityConnectionString")));

                services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                    options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<IdentityProviderContext>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders();

                services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>,
                    ApplicationUserClaimsPrincipalFactory>();
                services.AddTransient<IEmailSender, EmailSender>();

                //services.AddAuthentication()
                //    .AddGoogle(o =>
                //    {
                //        o.ClientId = "686977813024-1pabqkfoar3btu6tsh7puhu3pogcivi0.apps.googleusercontent.com";
                //        o.ClientSecret = context.Configuration["Google:ClientSecret"];
                //    });


            });
        }
    }
}
