using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using MercadoIgnis.Areas.Identity.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using MercadoIgnis.Models;

namespace MercadoIgnis.Models
{
    //Operaciones utiles para trabajar con ApplicationUser y Cliente/Tecnico/Administrador con comodidad
    public class OperacionesUsuario
    {
        //Devuelve el Id de cliente (int) que se usa en las relaciones, usando el Id de ApplicationUser que es el que está acccesible en la variable de sesion User
        public async Task<int> IdDeClienteConIdApplicationUser(string IdApplicationUser)
        {
            Cliente Cliente = await ContextoSingleton.Instance.Contexto.Cliente
                            .Where(a=> a.ApplicationUserId==IdApplicationUser)
                            .FirstOrDefaultAsync();
            
            return Cliente.ID;
        }
        //Devuelve el Id de tecnico (int) que se usa en las relaciones, usando el Id de ApplicationUser que es el que está acccesible en la variable de sesion User
         public async Task<int> IdDeTecnicoConIdApplicationUser(string IdApplicationUser)
        {
            Tecnico Tecnico = await ContextoSingleton.Instance.Contexto.Tecnico
                            .Where(a=> a.ApplicationUserId==IdApplicationUser)
                            .FirstOrDefaultAsync();
            
            return Tecnico.ID;
        }

        

        



        
    }
}