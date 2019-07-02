using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using MercadoIgnis.Areas.Identity.Data;
namespace MercadoIgnis.Models
{
    public class TecnicosSugeridosPuestos 
    {
        //Genera la relacion n a n entre Tecnicos y Puestos
        public int ID{get; set;}
        
        [ScaffoldColumn(false)]
        public int TecnicoID {get; set;}
        public int PuestoID {get; set;}

        public Tecnico Tecnico {get; set;}
        public Puesto Puesto {get; set;}


       
       


    }
}