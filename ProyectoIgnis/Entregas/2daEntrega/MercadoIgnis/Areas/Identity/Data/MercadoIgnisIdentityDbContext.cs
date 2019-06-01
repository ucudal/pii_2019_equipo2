using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Areas.Identity.Data;

namespace MercadoIgnis.Areas.Identity.Data
{
    public class MercadoIgnisIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public MercadoIgnisIdentityDbContext(DbContextOptions<MercadoIgnisIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<MercadoIgnis.Areas.Identity.Data.MercadoIgnisUser> MercadoIgnisUser { get; set; }
    }
}
