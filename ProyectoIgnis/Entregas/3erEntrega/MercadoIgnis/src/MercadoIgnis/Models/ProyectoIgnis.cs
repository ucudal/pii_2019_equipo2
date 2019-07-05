using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MercadoIgnis.Models
{
    
    public class ProyectoIgnis : Proyecto
    {
        //Este es el modelo de Proyectos Ignis
        //En este modelo se uso herecia por que tanto proyecto personal como proyecto Ignis son Proyectos, eso signifca que tienen atributos compartidos
        //Proyecto Ignis es subtipo de Proyecto
        public enum EnumEstadoProyecto
        {
            EnSeleccion,
            EnProceso,
            Finalizado,
            Cancelado
        };
       
        
        [Display(Name = "Estado Proyecto")]
        [DataType(DataType.Text)]
        public EnumEstadoProyecto Estado { get; set; }
        //Collecion de Puestos
        public ICollection<Puesto> Puestos { get; set; }

        public ProyectosIgnisClientes ProyectosIgnisClientes {get; set; } //estaba como collection
       
    }
}