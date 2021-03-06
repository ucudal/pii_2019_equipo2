using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using MercadoIgnis.Areas.Identity.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace MercadoIgnis.Models
{
    //Mantiene una referencia única a la instancia del contexto, al usermanager y a rolemanager que pueden ser usadas desde cualquier parte de la aplicacion sin usar dependency injection 
    //para hacer consultas en la bd, o usar la funcionalidades de user y role manager. 
    //Se inicializa pasandole el serviceProvider en el Program.
    public sealed class ContextoSingleton
    {
        private readonly static ContextoSingleton _instance = new ContextoSingleton();
        public IdentityContext Contexto { get; set; }
        public UserManager<ApplicationUser> userManager { get; set; }
        public RoleManager<IdentityRole> roleManager { get; set; }
        private ContextoSingleton()
        {
        }
        public static ContextoSingleton Instance
        {
            get
            {
                return _instance;
            }
        }

        public void Initialize(IServiceProvider serviceProvider)
        {
            Contexto = new IdentityContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<IdentityContext>>());
            userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        }

    }
}