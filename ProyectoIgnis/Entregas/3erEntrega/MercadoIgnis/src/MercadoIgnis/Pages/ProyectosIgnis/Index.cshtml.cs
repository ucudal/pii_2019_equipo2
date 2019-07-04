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
        public int ProyectoIgnisID{get;set;}
        public int PuestoID{get;set;}
        public IEnumerable<ProyectosIgnisClientes> ProyectosIgnisClientes {get; set;}

        //Usadas para listar
        public IList<ProyectoIgnis> ProyectoIgnis {get; set;}
        public IList<Puesto> PuestosProyecto {get;set;}
        
        [BindProperty]
        public Cliente Cliente { get; set; }
        public IEnumerable<ProyectoIgnis> Proyectos { get; set; }

        
        public async Task OnGetAsync(int? id, int? actorID)
        {
            
            if (User.IsInRole("Cliente"))
            {

                //Listo todos los proyectos del cliente, incluyo la relacion para traer el nombre del cliente de ApplicationUser
                //Obtengo el id Cliente usando el Id de logueo (ApplicationUserId)
                int IdCliente = await new OperacionesUsuario().IdDeClienteConIdApplicationUser(ContextoSingleton.Instance.userManager.GetUserId(User));

                ProyectoIgnis = await _context.ProyectoIgnis.
                Include(l => l.ProyectosIgnisClientes).
                ThenInclude(c => c.Cliente).
                ThenInclude(a => a.ApplicationUser).
                Where(m => m.ProyectosIgnisClientes.ClienteID == IdCliente).
                ToListAsync();

                
            }
            else if (User.IsInRole("Administrador"))
            {
                //Listo todos los proyectos del sistema, incluyo la relacion para traer el nombre de los clientes de ApplicationUser
                ProyectoIgnis = await _context.ProyectoIgnis.
                Include(l => l.ProyectosIgnisClientes).
                ThenInclude(c => c.Cliente).
                ThenInclude(a => a.ApplicationUser).                
                ToListAsync();

            }
            
            else if (User.IsInRole("Tecnico"))
            {
                //Traer los proyectos ignis del tecnico
            }
            else
            {
                //throw exception
            }
            //Si tengo algun proyecto seleccionado, muestro los puestos
            if (id != null)
            {
                ProyectoIgnisID = id.Value;
                //Selecciono los puestos de ese proyecto
                PuestosProyecto = await _context.Puesto
                .Include(e=>e.Especialidad)
                .Where(p=>p.ProyectoIgnisID==id.Value).              
                ToListAsync();
                
                
            }



        }
    }
}
