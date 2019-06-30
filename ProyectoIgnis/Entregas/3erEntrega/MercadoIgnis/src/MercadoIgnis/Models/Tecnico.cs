using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using MercadoIgnis.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace MercadoIgnis.Models
{
    public class Tecnico 
    {
         
        //Relacion con el ApplicationUser, en ID guardo el del Application user, no es autogenerado
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID{get;set;}
        
        
        public bool EsEgresado{ get; set; }
        public ICollection<Proyecto> Proyectos { get; set; }
        public ICollection<Especialidad> Especialidades { get; set; }

    }
}