using Microsoft.EntityFrameworkCore;

namespace ProyectoIgnis.Models
{
    public class ProyectoIgnisContext : DbContext
    {
        public ProyectoIgnisContext (DbContextOptions<ProyectoIgnisContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoIgnis.Models.Especialidad> Especialidad { get; set; }
    }
}