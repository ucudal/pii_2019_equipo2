using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MercadoIgnis.Models
{
    public class ProyectoIgnis : Proyecto
    {
        //En este modelo se uso herecia por que tanto proyecto personal como proyecto Ignis son Proyectos, eso signifca que tienen atributos compartidos
        public enum EnumEstadoProyecto {
            EnSeleccion,
            EnProceso,
            Finalizado,
            Cancelado 
            };

        [ScaffoldColumn(false)]
        [Display(Name = "Estado Proyecto")]
        [DataType(DataType.Text)]
        public EnumEstadoProyecto Estado {get; set;}

        public IList<Puesto> Puestos { get; set; }
        // public Cliente cliente {get; set;}
        // public int clienteID {get; set;}
    }
}