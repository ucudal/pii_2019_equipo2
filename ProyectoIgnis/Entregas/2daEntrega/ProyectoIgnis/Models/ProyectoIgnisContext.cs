using Microsoft.EntityFrameworkCore;

namespace MercadoIgnis.Models
{
    public class MercadoIgnisContext : DbContext
    {
        public MercadoIgnisContext (DbContextOptions<MercadoIgnisContext> options)
            : base(options)
        {
        }

        public DbSet<MercadoIgnis.Models.Especialidad> Especialidad { get; set; }
    }
}