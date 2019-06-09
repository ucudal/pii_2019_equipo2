using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MercadoIgnis.Models
{
    public class ProyectoIgnis : Proyecto
    {
        
        public enum EnumEstadoProyecto {
            EnSeleccion,
            EnProceso,
            Finalizado,
            Cancelado 
            };

        [ScaffoldColumn(false)]
        [Display(Name = "Estado Proyecto")]
        [DataType(DataType.Text)]
        public EnumEstadoProyecto Estado { get; set; }

       // public ICollection<Puesto> Puestos { get; set; }
       


    }
}