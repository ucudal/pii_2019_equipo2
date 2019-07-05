using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using MercadoIgnis.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace MercadoIgnis.Models
{
    public class Tecnico
    {
        //Este es el modelo de los tecnicos
        //Tecnico esta compuesto por aplicationUser y eso en si refleja que tiene un usuario web

        [Key]
        public int ID { get; set; }

        //Relacion con el ApplicationUser, en ID guardo el del Application user, no es autogenerado
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<EspecialidadesTecnicos> EspecialidadesTecnicos { get; set; }

        public ICollection<TecnicoSugeridoPuesto> TecnicosSugeridoPuesto { get; set; }
        public ICollection<TecnicoSolicitudPuesto> TecnicosSolicitudPuesto { get; set; }

    }
}