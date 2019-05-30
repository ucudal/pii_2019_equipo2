using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ProyectoIgnis.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProyectoIgnisContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ProyectoIgnisContext>>()))
            {
                // Look for any movies.
                if (context.Especialidad.Any())
                {
                    return;   // DB has been seeded
                }

                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        Area = "Camarografo",
                        Nivel = "Avanzado",
                        Rating = "R"
                    },

                    new Especialidad
                    {
                        Area = "Fotografo",
                        Nivel = "Basico",
                        Rating = "R"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}