using System;
using System.ComponentModel.DataAnnotations;

namespace MercadoIgnis.Models
{
    public class Calificacion
    {
        //Este es el modelo de las calificaciones
        public int ID { get; set; }

        [Display(Name = "Nota")]
        [DataType(DataType.Text)]
        public int Nota { get; set; }

        [Display(Name = "Descripcion")]
        [DataType(DataType.Text)]
        public string Descripcion { get; set; }
    }

}