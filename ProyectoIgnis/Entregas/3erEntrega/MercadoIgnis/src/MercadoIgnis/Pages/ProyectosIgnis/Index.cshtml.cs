using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Models;
using MercadoIgnis.Areas.Identity.Data;
//Patron Expert
//Patron Creator
//IndexModel tiene los datos que serán provistos al constructor para inicializar instancias de ProyectoIgnis -por lo que IndexModel es un experto conrespecto a crear ProyectoIgnis-.
namespace MercadoIgnis.Pages.ProyectosIgnis
{
    public class IndexModel : PageModel
    {
        private readonly IdentityContext _context;

        public IndexModel(IdentityContext context)
        {
            _context = context;
        }
        public IEnumerable<ProyectosIgnisClientes> ProyectosIgnisClientes { get; set; }

        public IList<ProyectoIgnis> ProyectoIgnis { get;set; }


        [BindProperty]
        public Cliente Cliente { get; set; }
        public IEnumerable<ProyectoIgnis> Proyectos { get; set; }

        public async Task OnGetAsync()
        {
            if(User.IsInRole("Cliente"))
            {
               
                //Traigo toda lo relacionado con el cliente logueado
                Cliente = await _context.Cliente
                    .Where(m => m.ID == ContextoSingleton.Instance.userManager.GetUserId(User))
                    .Include(l => l.ProyectosIgnisClientes)
                        .ThenInclude(a => a.ProyectoIgnis)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
        
                if(Cliente != null)
                {
                
                    // Traigo los ProyectosIgnis del Cliente
                    this.Proyectos = Cliente.ProyectosIgnisClientes
                        .Select(a => a.ProyectoIgnis);
                    this.ProyectoIgnis = Proyectos.ToList();
                }
                
               


             }
             else if(User.IsInRole("Administrador"))
             {
                 //Listo todos los proyectos, incluyo la relacion para traer el id del propietario
                 ProyectoIgnis = await _context.ProyectoIgnis.
                 Include(l => l.ProyectosIgnisClientes).
                 ToListAsync();
             }
             else if(User.IsInRole("Tecnico"))
             {
                 //Traer los proyectos ignis del tecnico
             }
             else
             {
                 //throw exception
             }

            
        }
    }
}
