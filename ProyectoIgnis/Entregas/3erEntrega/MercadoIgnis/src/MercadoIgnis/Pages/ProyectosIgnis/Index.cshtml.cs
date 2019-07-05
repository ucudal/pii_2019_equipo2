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
        //Index Model: en esta pagina de Proyectos Ignis, te carga la vista principal
        private readonly IdentityContext _context;

        public IndexModel(IdentityContext context)
        {
            _context = context;
        }
        public int ProyectoIgnisID{get;set;}
        public int PuestoID{get;set;}
        public IEnumerable<ProyectosIgnisClientes> ProyectosIgnisClientes {get; set;}

        //Usadas para listar
        public List<ProyectoIgnis> ProyectoIgnis {get; set;}
        public List<Puesto> PuestosProyecto {get;set;}
        
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

                //Si tengo algun proyecto seleccionado, muestro los puestos
                if (id != null)
                {
                    ProyectoIgnisID = id.Value;
                    //Selecciono los puestos de ese proyecto
                    PuestosProyecto = await _context.Puesto
                    .Include(e=>e.Especialidad)
                    .Include(t=>t.Tecnico)
                    .ThenInclude(a=>a.ApplicationUser)
                    .Where(p=>p.ProyectoIgnisID==id.Value).              
                    ToListAsync();
                    
                    
                }

                
            }
            else if (User.IsInRole("Administrador"))
            {
                //Listo todos los proyectos del sistema, incluyo la relacion para traer el nombre de los clientes de ApplicationUser
                ProyectoIgnis = await _context.ProyectoIgnis.
                Include(l => l.ProyectosIgnisClientes).
                ThenInclude(c => c.Cliente).
                ThenInclude(a => a.ApplicationUser).                
                ToListAsync();

                //Si tengo algun proyecto seleccionado, muestro los puestos
                if (id != null)
                {
                    ProyectoIgnisID = id.Value;
                    //Selecciono los puestos de ese proyecto
                    PuestosProyecto = await _context.Puesto
                    .Include(e=>e.Especialidad)
                    .Include(t=>t.Tecnico)
                    .ThenInclude(a=>a.ApplicationUser)
                    .Where(p=>p.ProyectoIgnisID==id.Value).              
                    ToListAsync();
                    
                }

            }
            
            else if (User.IsInRole("Técnico"))
            {
                //Listo todos los proyectos del tecnico, incluyo la relacion para traer el nombre del cliente de ApplicationUser
                //Obtengo el id Tecnico usando el Id de logueo (ApplicationUserId)
                int IdTecnico = await new OperacionesUsuario().IdDeTecnicoConIdApplicationUser(ContextoSingleton.Instance.userManager.GetUserId(User));

                //Todos los proyectos con sus puestos, solicitudes de tecnicos y tecnicos
                var ProyectosIgnisGral = await _context.ProyectoIgnis.
                Include(l => l.Puestos).
                ThenInclude(a => a.Tecnico).
                ThenInclude(a => a.ApplicationUser).
                Where(p=>p.Estado == Models.ProyectoIgnis.EnumEstadoProyecto.Finalizado).
                ToListAsync();
                ProyectoIgnis = new List<ProyectoIgnis>();
                PuestosProyecto = new List<Puesto>();

                var Especialidades =await _context.Especialidad.ToListAsync();

                foreach(ProyectoIgnis t in ProyectosIgnisGral)
                {
                    //_context.TecnicoSolicitudesPuesto.Where(s => s.TecnicoID == t.ID).Load();
                    if (t.Puestos != null)
                    {
                        foreach (Puesto p in t.Puestos)
                        {
                            if(p.TecnicoID==IdTecnico)
                            {   
                                if(ProyectoIgnis.Find(a=>a.ID == t.ID) == null)
                                {
                                    ProyectoIgnis.Add(t);
                                }
                            }
                                            
                                    


                        }
                    }

                }

              




            }
            else
            {
                //throw exception
            }
            



        }
    }
}
