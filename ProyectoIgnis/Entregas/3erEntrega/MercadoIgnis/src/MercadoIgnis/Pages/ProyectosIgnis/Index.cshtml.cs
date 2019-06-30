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

        public class ProyectosConNombreClientes
        {
            public ProyectoIgnis Proyecto{get;set;}
            public string NombrePropietario{get;set;}
        }
        public IList<ProyectosConNombreClientes> ListaProyectosConNombreCliente {get;set;}

        public async Task OnGetAsync()
        {
            if(User.IsInRole("Cliente"))
            {


                //Listo todos los proyectos, incluyo la relacion para traer el id del propietario
                 ProyectoIgnis = await _context.ProyectoIgnis.
                 Include(l => l.ProyectosIgnisClientes).
                 Where(m => m.ProyectosIgnisClientes.ClienteID == ContextoSingleton.Instance.userManager.GetUserId(User)).
                 ToListAsync();
    

                //Traigo la info de ApplicationUser para cada cliente
                ListaProyectosConNombreCliente = new List<ProyectosConNombreClientes>();

                 foreach(ProyectoIgnis p in this.ProyectoIgnis)
                 {
                        ProyectosConNombreClientes proyectoConNombre = new ProyectosConNombreClientes();
                        proyectoConNombre.Proyecto = p;
                        
                        proyectoConNombre.NombrePropietario = _context.ApplicationUsers
                        .Where(m => m.Id == p.ProyectosIgnisClientes.ClienteID)
                        .FirstOrDefaultAsync().Result.Name;
                        
                        if (proyectoConNombre != null)
                        {
                            ListaProyectosConNombreCliente.Add(proyectoConNombre);
                        }
                        
                 }


               
               
                
               


             }
             else if(User.IsInRole("Administrador"))
             {
                 //Listo todos los proyectos, incluyo la relacion para traer el id del propietario
                 ProyectoIgnis = await _context.ProyectoIgnis.
                 Include(l => l.ProyectosIgnisClientes).
                 ToListAsync();
    

                //Traigo la info de ApplicationUser para cada cliente
                ListaProyectosConNombreCliente = new List<ProyectosConNombreClientes>();

                 foreach(ProyectoIgnis p in this.ProyectoIgnis)
                 {
                        ProyectosConNombreClientes proyectoConNombre = new ProyectosConNombreClientes();
                        proyectoConNombre.Proyecto = p;
                        
                        proyectoConNombre.NombrePropietario = _context.ApplicationUsers
                        .Where(m => m.Id == p.ProyectosIgnisClientes.ClienteID)
                        .FirstOrDefaultAsync().Result.Name;
                        
                        if (proyectoConNombre != null)
                        {
                            ListaProyectosConNombreCliente.Add(proyectoConNombre);
                        }
                        
                 }
                 

                 
                

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
