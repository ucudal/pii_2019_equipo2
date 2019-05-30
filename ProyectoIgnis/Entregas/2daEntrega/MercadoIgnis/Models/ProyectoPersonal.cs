using System;
using System.ComponentModel.DataAnnotations;

namespace MercadoIgnis.Models
{
    public class ProyectoPersonal : Proyecto
    {
        
        
        [Display(Name = "Tipo De Proyecto")]
        [DataType(DataType.Text)]
        public string TipoDeProyecto { get; set; }  
        
        
        

    }
}