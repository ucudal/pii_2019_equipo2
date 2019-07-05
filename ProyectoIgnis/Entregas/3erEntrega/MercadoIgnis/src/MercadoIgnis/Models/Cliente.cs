using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using MercadoIgnis.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace MercadoIgnis.Models
{
    public class Cliente
    {
        //Este es el modelo de los Clientes
        [Key]
        public int ID{get;set;}

        //Relacion con el ApplicationUser, en ID guardo el del Application user, no es autogenerado
        public string ApplicationUserId{get;set;}
       
        
        public ApplicationUser ApplicationUser{get;set;}
        //Colleccion de ProyectosIgnisClientes
        public ICollection<ProyectosIgnisClientes> ProyectosIgnisClientes { get; set; }
    }
}