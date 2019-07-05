using System;
using System.ComponentModel.DataAnnotations;

namespace MercadoIgnis.Models
{
    public class ProyectoPersonal : Proyecto
    {
        //Este es el modelo de Proyectos Personal
        //En este modelo se uso herecia por que tanto proyecto personal como proyecto Ignis son Proyectos, eso signifca que tienen atributos compartido
        // OCP- Proyecto Personal expande el tipo Proyecto, respetando el tipo base y expandiendo sobre él.
        /// y siempre podemos agregar nuevos métodos.
        public enum EnumTipoProyectoPersonal
        {
            Freelance, TrabajoDeClase, ProyectoDeFinDeCurso, ProyectoDeGrado, Hobby
        };


        [Display(Name = "Tipo De Proyecto")]
        [DataType(DataType.Text)]
        public EnumTipoProyectoPersonal Tipos { get; set; }
    }
}