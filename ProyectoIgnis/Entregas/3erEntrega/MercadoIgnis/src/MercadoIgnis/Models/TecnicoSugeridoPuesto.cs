using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using MercadoIgnis.Areas.Identity.Data;
namespace MercadoIgnis.Models
{
    public class TecnicoSugeridoPuesto 
    {
        //Este es el modelo de los Tecnicos sugeridos a puestos
        //Genera la relacion n a n entre Tecnicos y Puestos
        //Se usa el principio de responsablidad unica la unica responsabilidad que tiene esta clase es la de relaccionar un tecnico sugerido a un puesto

        public int ID{get; set;}
        
        [ScaffoldColumn(false)]
        public int TecnicoID {get; set;}
        public int PuestoID {get; set;}

        public Tecnico Tecnico {get; set;}
        public Puesto Puesto {get; set;}


       
       


    }
}