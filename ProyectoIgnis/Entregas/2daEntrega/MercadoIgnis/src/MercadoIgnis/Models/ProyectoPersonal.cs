using System;
using System.ComponentModel.DataAnnotations;

namespace MercadoIgnis.Models
{
    public class ProyectoPersonal : Proyecto
    {
        //En este modelo se uso herecia por que tanto proyecto personal como proyecto Ignis son Proyectos, eso signifca que tienen atributos compartidos
        
        [Display(Name = "Tipo De Proyecto")]
        [DataType(DataType.Text)]
        public string TipoDeProyecto { get; set; }  
        
        
        

    }
}