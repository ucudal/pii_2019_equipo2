using System;
using System.ComponentModel.DataAnnotations;

namespace MercadoIgnis.Models
{
    public class Especialidad
    {
        public int ID { get; set; }

        [Display(Name = "Area")]
        [DataType(DataType.Text)]
        public string Area { get; set; }

        [Display(Name = "Nivel")]
        [DataType(DataType.Text)]
        public string Nivel { get; set; }

    }
}