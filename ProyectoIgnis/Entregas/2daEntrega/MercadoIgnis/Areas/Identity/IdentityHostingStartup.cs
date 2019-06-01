using System;
using MercadoIgnis.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(MercadoIgnis.Areas.Identity.IdentityHostingStartup))]
namespace MercadoIgnis.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MercadoIgnisIdentityDbContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("MercadoIgnisIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<MercadoIgnisIdentityDbContext>();
            });
        }
    }
}