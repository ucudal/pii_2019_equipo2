using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using MercadoIgnis.Areas.Identity.Data;
namespace MercadoIgnis.Models
{
    public class ProyectosIgnisClientes
    {
        //Genera la relacion n a n entre ProyectosIgnis y Clientes   
        public int ID { get; set; }
        public ProyectosIgnisClientes(string clienteID, int proyectoIgnisID)
        {
            ClienteID = clienteID;
            ProyectoIgnisID = proyectoIgnisID;
        }
        public string ClienteID { get; set; }
        public int ProyectoIgnisID { get; set; }

        public Cliente Cliente { get; set; }
        public ProyectoIgnis ProyectoIgnis { get; set; }
    }
}