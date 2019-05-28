using Microsoft.EntityFrameworkCore;
using ProyectoIgnis.Models;

namespace ProyectoIgnis.Models
{
    public class ProyectoIgnisContext : DbContext
    {
        public ProyectoIgnisContext (DbContextOptions<ProyectoIgnisContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoIgnis.Models.Especialidad> Especialidad { get; set; }

        public DbSet<ProyectoIgnis.Models.ProyectoPersonal> ProyectoPersonal { get; set; }
    }
}