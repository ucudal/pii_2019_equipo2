using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Models;

namespace MercadoIgnis.Models
{
    public class MercadoIgnisContext : DbContext
    {
        public MercadoIgnisContext (DbContextOptions<MercadoIgnisContext> options)
            : base(options)
        {
        }

        public DbSet<MercadoIgnis.Models.Especialidad> Especialidad { get; set; }

        public DbSet<MercadoIgnis.Models.ProyectoPersonal> ProyectoPersonal { get; set; }

    }
}