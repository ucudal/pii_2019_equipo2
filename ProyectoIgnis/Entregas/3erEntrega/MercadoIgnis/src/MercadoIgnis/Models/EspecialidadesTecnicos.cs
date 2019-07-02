using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using MercadoIgnis.Areas.Identity.Data;
namespace MercadoIgnis.Models
{
    public class EspecialidadesTecnicos
    {
        //Genera la relacion n a n entre Especialidades y Tecnicos
        public int ID { get; set; }

        [ScaffoldColumn(false)]
        public string TecnicoID { get; set; }
        public int EspecialidadID { get; set; }

        public Tecnico Tecnico { get; set; }
        public Especialidad Especialidad { get; set; }
    }
}