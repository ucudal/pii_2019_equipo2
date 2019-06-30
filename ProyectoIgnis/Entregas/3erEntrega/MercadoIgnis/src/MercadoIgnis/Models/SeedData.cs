using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using MercadoIgnis.Areas.Identity.Data;
namespace MercadoIgnis.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new IdentityContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<IdentityContext>>()))
            {
                // Look for any movies.
                if (context.ProyectoPersonal.Any())
                {
                    return;   // DB has been seeded
                }

                context.ProyectoPersonal.AddRange(
                    new ProyectoPersonal
                    {
                        ID = 1,
                        Descripcion = "Fotos en el Parque Batlle",
                        FechaComienzo = DateTime.Parse("2019-2-12"),
                        FechaFinalizacion = DateTime.Parse("2019-4-21"),
                        TipoDeProyecto = "Foto",
                    }

                );
                context.ProyectoPersonal.AddRange(
                    new ProyectoPersonal
                    {
                        ID = 2,
                        Descripcion = "Animación 3d",
                        FechaComienzo = DateTime.Parse("2019-2-16"),
                        FechaFinalizacion = DateTime.Parse("2019-2-19"),
                        TipoDeProyecto = "Edicion 3d",
                    }

                );
                
                if (context.Calificacion.Any())
                {
                    return;   // DB has been seeded
                }

                context.Calificacion.AddRange(
                    new Calificacion
                    {
                        ID = 1,
                        Nota = 1,
                        Descripcion = "Descripcion de prueba, calificaciones de un tecnico de proyectos terminados",

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
                        Area = "Foto Fija - Básico ",
                        Nivel = "Básico"
                    }
                );


                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 2,
                        Area = "Foto Fija - Avanzado",
                        Nivel = "Avanzado"
                    }

                );

                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 3,
                        Area = "Asistente de cámara - Básico",
                        Nivel = "Básico"
                    }

                );

                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 4,
                        Area = "Asistente de producción - Básico",
                        Nivel = "Básico"
                    }

                );

                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 5,
                        Area = "Asistente de dirección - Básico",
                        Nivel = "Básico"
                    }

                );

                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 6,
                        Area = "Asistente de arte (escenografía, vestuario, utilería) - Básico",
                        Nivel = "Básico"
                    }

                );

                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 7,
                        Area = "Sonidista - Básico",
                        Nivel = "Básico"
                    }

                );

                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 8,
                        Area = "Editor - Básico",
                        Nivel = "Básico"
                    }

                );

                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 9,
                        Area = "Redactor creativo - Básico",
                        Nivel = "Básico"
                    }

                );

                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 10,
                        Area = "Presentador / conductor - Básico",
                        Nivel = "Básico"
                    }

                );

                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 11,
                        Area = "Ilustrador - Básico",
                        Nivel = "Básico"
                    }

                );

                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 12,
                        Area = "Diseñador gráfico - Básico",
                        Nivel = "Básico"
                    }

                );

                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 13,
                        Area = "Operador de Cabina 02 - Básico",
                        Nivel = "Básico"
                    }

                );
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 14,
                        Area = "Operador de Cabina 02 - Básico",
                        Nivel = "Básico"
                    }

                );

                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 15,
                        Area = "Cámara y asistente de cámara - Avanzado",
                        Nivel = "Avanzado"
                    }

                );
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 16,
                        Area = "Cámara 360º - Avanzado",
                        Nivel = "Avanzado"
                    }

                );
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 17,
                        Area = "Postproductor de imagen - Avanzado",
                        Nivel = "Avanzado"
                    }

                );
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 18,
                        Area = "Editor - Avanzado",
                        Nivel = "Avanzado"
                    }

                );
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 19,
                        Area = "Sonidista - Avanzado",
                        Nivel = "Avanzado"
                    }

                );
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 20,
                        Area = "Postproductor de sonido - Avanzado",
                        Nivel = "Avanzado"
                    }

                );
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 21,
                        Area = "Redactor creativo - Avanzado",
                        Nivel = "Avanzado"
                    }

                );
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 22,
                        Area = "Presentador / conductor - Avanzado",
                        Nivel = "Avanzado"
                    }

                );
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 23,
                        Area = "Animador / infografista - Avanzado",
                        Nivel = "Avanzado"
                    }

                );
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 24,
                        Area = "Operador de Cabina 01 Estudio de Grabación - Avanzado",
                        Nivel = "Avanzado"
                    }

                );
                context.Especialidad.AddRange(
                    new Especialidad
                    {
                        ID = 25,
                        Area = "Operador de Cabina 03 y Estudio de Radio - Básico",
                        Nivel = "Básico"
                    }
  
                ); 
                
                /* deshabilitados porque falta agregar la relacion con el cliente que lo creó
                if (context.ProyectoIgnis.Any())
                {
                    return;   // DB has been seeded
                }
                
                context.ProyectoIgnis.AddRange(
                    new ProyectoIgnis
                    {
                        ID = 3,
                        FechaComienzo = DateTime.Parse("2019-2-12"),
                        FechaFinalizacion = DateTime.Parse("2019-3-12"),
                        Descripcion = "Proyecto de Cine"
                    }
                );
                context.ProyectoIgnis.AddRange(
                    new ProyectoIgnis
                    {
                        ID = 4,
                        FechaComienzo = DateTime.Parse("2019-3-15"),
                        FechaFinalizacion = DateTime.Parse("2019-3-20"),
                        Descripcion = "Cortometraje"
                    }
                );
                context.ProyectoIgnis.AddRange(
                    new ProyectoIgnis
                    {
                        ID = 5,
                        FechaComienzo = DateTime.Parse("2019-7-1"),
                        FechaFinalizacion = DateTime.Parse("2019-7-10"),
                        Descripcion = "Demo de canción"
                    }
                );
                */
                context.SaveChanges();
                 
                
            }
        }
    }
}