using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoIgnis.Models
{
    public class Especialidad
    {
        public int ID { get; set; }
        public string Area { get; set; }

        public string Nivel { get; set; }
        public string Rating { get; set; }

    }
}