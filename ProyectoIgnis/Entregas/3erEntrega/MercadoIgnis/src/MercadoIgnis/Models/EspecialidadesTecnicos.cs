using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using MercadoIgnis.Areas.Identity.Data;
namespace MercadoIgnis.Models
{
    public class EspecialidadesTecnicos
    {
        //Este es el modelo de las especialidades de los tecnicos
        //Genera la relacion n a n entre Especialidades y Tecnicos
        public int ID{get; set;}
        
        [ScaffoldColumn(false)]
        public int TecnicoID {get; set;}
        public int EspecialidadID {get; set;}

        public Tecnico Tecnico {get; set;}
        public Especialidad Especialidad {get; set;}


       
       

        
    }
}