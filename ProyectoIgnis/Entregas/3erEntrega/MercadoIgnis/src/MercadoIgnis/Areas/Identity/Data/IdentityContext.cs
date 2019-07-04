using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Areas.Identity.Data;
using MercadoIgnis.Models;

namespace MercadoIgnis.Areas.Identity.Data
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("ApplicationUser");
        }

        public DbSet<MercadoIgnis.Models.Tecnico> Tecnico { get; set; }
        public DbSet<MercadoIgnis.Models.Cliente> Cliente { get; set; }
        public DbSet<Identity.Data.ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<MercadoIgnis.Models.Especialidad> Especialidad { get; set; }
        public DbSet<MercadoIgnis.Models.ProyectoPersonal> ProyectoPersonal { get; set; }
        public DbSet<MercadoIgnis.Models.ProyectoIgnis> ProyectoIgnis { get; set; }
        public DbSet<MercadoIgnis.Models.Puesto> Puesto { get; set; }
        public DbSet<MercadoIgnis.Models.Calificacion> Calificacion { get; set; }

        public DbSet<MercadoIgnis.Models.ProyectosIgnisClientes> ProyectosIgnisClientes { get; set; }

        public DbSet<MercadoIgnis.Models.EspecialidadesTecnicos> EspecialidadesTecnicos { get; set; }

        public DbSet<MercadoIgnis.Models.TecnicoSugeridoPuesto> TecnicoSugeridoPuesto { get; set; }

        public DbSet<MercadoIgnis.Models.TecnicoSolicitudPuesto> TecnicoSolicitudPuesto { get; set; }

        

        
    }
}
