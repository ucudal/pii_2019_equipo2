using System;
using System.ComponentModel.DataAnnotations;

namespace MercadoIgnis.Models
{
    public class ProyectoIgnis : Proyecto
    {
        [Display(Name = "Estado")]
        [DataType(DataType.Text)]
        public string Estado { get; set; }

    }
}