using System;
using System.ComponentModel.DataAnnotations;

namespace MercadoIgnis.Models
{
    public abstract class Proyecto
    {
        //Proyecto es supertipo de Proyecto Ignis y Proyecto Personal
        //Este es el modelo de los proyectos
        // Principio de inversion de dependencia. Esta clase es una abstraccion, los detalles dependen de esta, esta clase no depende de los detalles
        public int ID { get; set; }

        [Display(Name = "Descripcion")]
        [DataType(DataType.Text)]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha Comienzo")]
        [DataType(DataType.Date)]
        public DateTime FechaComienzo { get; set; }

        [Display(Name = "Fecha Finalización")]
        [DataType(DataType.Date)]
        public DateTime FechaFinalizacion { get; set; }

    }
}