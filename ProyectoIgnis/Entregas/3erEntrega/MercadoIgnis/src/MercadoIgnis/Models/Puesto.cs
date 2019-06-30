using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace MercadoIgnis.Models
{
    public class Puesto
    {
        public int ID { get; set; }

        [ScaffoldColumn(false)]
        public int EspecialidadID { get; set; }
        public Especialidad Especialidad { get; set; } //Se carga con el ID Especialidad

        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public ProyectoIgnis ProyectoIgnis { get; set; }
        public int ProyectoIgnisID { get; set; }
    }
}