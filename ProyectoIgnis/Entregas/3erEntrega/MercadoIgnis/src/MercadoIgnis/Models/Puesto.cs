using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace MercadoIgnis.Models
{
    public class Puesto
    {
        //Este es el modelo de Puestos
        public enum EnumEstadoPuesto
        {
            ALaEsperaDeTecnicos,
            ConTecnicosSugeridos,
            ALaEsperaDeConfirmacion,
            Ocupado
        };

        public int ID { get; set; }

        [ScaffoldColumn(false)]
        public int EspecialidadID { get; set; }
        public Especialidad Especialidad { get; set; }

        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public ProyectoIgnis ProyectoIgnis { get; set; }
        public int ProyectoIgnisID { get; set; }

        public EnumEstadoPuesto Estado { get; set; }

        //Tecnico asignado
        public int? TecnicoID { get; set; } //opcional para que se pueda crear un Puesto sin tecnico asignado
        public Tecnico Tecnico { get; set; }

        //Collecion de Tecnicos Sugeridos
        public ICollection<TecnicoSugeridoPuesto> TecnicosSugeridosPuesto { get; set; }
        //Coleccion de Tecnicos Solicitados
        public ICollection<TecnicoSolicitudPuesto> TecnicosSolicitudesPuesto { get; set; }

    }
}