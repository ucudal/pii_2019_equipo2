using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MercadoIgnis.Models
{
    public class Puesto
    {
        public int ID { get; set; }
        public Calificacion Calificacion { get; set; }

        public int EspecialidadID {get;set;}
    }
}