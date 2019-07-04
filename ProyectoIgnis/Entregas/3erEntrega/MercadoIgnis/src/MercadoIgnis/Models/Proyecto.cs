using System;
using System.ComponentModel.DataAnnotations;

namespace MercadoIgnis.Models
{
    public abstract class Proyecto
    {
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