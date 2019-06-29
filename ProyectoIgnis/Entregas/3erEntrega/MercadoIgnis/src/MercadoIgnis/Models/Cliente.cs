using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using MercadoIgnis.Areas.Identity.Data;

namespace MercadoIgnis.Models
{
    public class Cliente : ApplicationUser
    {
        
        public double RUT {get; set;}
        public ICollection<ProyectoIgnis> ProyectosIgnis { get; set; }
    }
}