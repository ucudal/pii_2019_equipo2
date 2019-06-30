using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using MercadoIgnis.Areas.Identity.Data;
namespace MercadoIgnis.Models
{
    public class Tecnico : ApplicationUser
    {
        public bool EsEgresado { get; set; }
        public ICollection<Proyecto> Proyectos { get; set; }
        public ICollection<Especialidad> Especialidades { get; set; }
        
    }
}