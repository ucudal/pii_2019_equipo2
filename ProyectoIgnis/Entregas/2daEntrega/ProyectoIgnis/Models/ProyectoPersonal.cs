using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoIgnis.Models
{
    public class ProyectoPersonal
    {
        public int ID { get; set; }
        
        [Display(Name = "Tipo De Proyecto")]
        [DataType(DataType.Date)]
        public string TipoDeProyecto { get; set; }  
        [Display(Name = "Tiempo De Realizacion")]
        [DataType(DataType.Date)]
        public DateTime TiempoDeRealizacion { get; set; }
        

    }
}