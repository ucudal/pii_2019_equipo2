using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MercadoIgnis.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MercadoIgnisContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MercadoIgnisContext>>()))
            {
                // Look for any movies.
                if (context.ProyectoPersonal.Any())
                {
                    return;   // DB has been seeded
                }

                context.ProyectoPersonal.AddRange(
                    new ProyectoPersonal
                    {
                        ID = 133,
                        Descripcion = "Parque Batlle",
                        FechaComienzo = DateTime.Parse("2019-2-12"),
                        FechaFinalizacion = DateTime.Parse("2019-4-21"),
                        TipoDeProyecto = "Foto",
                        
                    }
  
                );
                if (context.Calificacion.Any())
                {
                    return;   // DB has been seeded
                }

                context.Calificacion.AddRange(
                     new Calificacion
                     {
                         ID=13,
                         Nota = 1,
                         Descripcion = "Parque Batlle",
                        
                     }
                 );
                
                if (context.Especialidad.Any())
                {
                    return;   // DB has been seeded
                }

                 context.Especialidad.AddRange(
                     new Especialidad
                     {
                         ID = 1,
                         Area = "Fotografía",
                         Nivel = "Básico"
                     }
                
  
                );
                
                context.SaveChanges();
                
            }
        }
    }
}