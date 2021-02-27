using System;
using FitNass.Areas.Identity.Data;
using FitNass.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FitNass.Areas.Identity.IdentityHostingStartup))]
namespace FitNass.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<FitNassContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("FitNassContextConnection")));

                services.AddDefaultIdentity<FitNassUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                    .AddEntityFrameworkStores<FitNassContext>();
            });
        }
    }
}