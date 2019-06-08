using System;
using System.ComponentModel.DataAnnotations;

namespace MercadoIgnis.Models
{
    public class Calificacion
    {
        public int ID { get; set; }

        [Display(Name = "Nota")]
        [DataType(DataType.Text)]
        public int Nota {get; set;}

        [Display(Name = "Descripcion")]
        [DataType(DataType.Text)]
        public string Descripcion {get; set;}
    }

}