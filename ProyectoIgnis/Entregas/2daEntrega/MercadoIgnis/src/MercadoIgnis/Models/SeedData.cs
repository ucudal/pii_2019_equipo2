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
                        ID = 12,
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
                         ID=5389412,
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
                        Area = "Foto Fija",
                        Nivel = "Básico"
                    }
                );
                     
                    
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 2,
                        Area = "Foto Fija",
                        Nivel = "Avanzado"
                    }
  
                );
                
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 3,
                        Area = "Asistente de cámara",
                        Nivel = "Básico"
                    }
  
                );
                
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 4,
                        Area = "Asistente de producción",
                        Nivel = "Básico"
                    }
  
                );
                
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 5,
                        Area = "Asistente de dirección",
                        Nivel = "Básico"
                    }

                );
               
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 6,
                        Area = "Asistente de arte (escenografía, vestuario, utilería)",
                        Nivel = "Básico"
                    }
  
                );
                
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 7,
                        Area = "Sonidista",
                        Nivel = "Básico"
                    }
  
                );
                
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 8,
                        Area = "Editor",
                        Nivel = "Básico"
                    }

                );
                
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 9,
                        Area = "Redactor creativo",
                        Nivel = "Básico"
                    }

                );
                
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 10,
                        Area = "Presentador / conductor",
                        Nivel = "Básico"
                    }

                );
                
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 11,
                        Area = "Ilustrador",
                        Nivel = "Básico"
                    }
    
                );
                
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 12,
                        Area = "Diseñador gráfico",
                        Nivel = "Básico"
                    }
  
                );
                
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 13,
                        Area = "Operador de Cabina 02",
                        Nivel = "Básico"
                    }
  
                );
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 14,
                        Area = "Operador de Cabina 02",
                        Nivel = "Básico"
                    }

                );
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 145,
                        Area = "Operador de Cabina 03 y Estudio de Radio",
                        Nivel = "Básico"
                    }
  
                );
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 15,
                        Area = "Cámara y asistente de cámara",
                        Nivel = "Avanzado"
                    }

                );
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 16,
                        Area = "Cámara 360º",
                        Nivel = "Avanzado"
                    }
  
                );
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 17,
                        Area = "Postproductor de imagen",
                        Nivel = "Avanzado"
                    }
  
                );
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 18,
                        Area = "Editor",
                        Nivel = "Avanzado"
                    }

                );
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 19,
                        Area = "Sonidista",
                        Nivel = "Avanzado"
                    }
  
                );
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 20,
                        Area = "Postproductor de sonido",
                        Nivel = "Avanzado"
                    }
  
                );
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 21,
                        Area = "Redactor creativo",
                        Nivel = "Avanzado"
                    }
  
                );
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 22,
                        Area = "Presentador / conductor",
                        Nivel = "Avanzado"
                    }
  
                );
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 23,
                        Area = "Animador / infografista",
                        Nivel = "Avanzado"
                    }

                );
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 24,
                        Area = "Operador de Cabina 01 Estudio de Grabación",
                        Nivel = "Avanzado"
                    }
  
                ); 

                if (context.ProyectoIgnis.Any())
                {
                    return;   // DB has been seeded
                }

                context.ProyectoIgnis.AddRange(
                    new ProyectoIgnis
                    {
                        ID = 1,
                        FechaComienzo= DateTime.Parse("2019-2-12"),
                        FechaFinalizacion=DateTime.Parse("2019-3-12"),
                        Descripcion= "Proyecto de Cine"
                    }
                );
                context.SaveChanges();
                
            }
        }
    }
}
                              