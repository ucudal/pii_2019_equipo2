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
    public class TecnicosSolicitudesModel : PageModel
    {
        private readonly IdentityContext _context;

        public TecnicosSolicitudesModel(IdentityContext context)
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

        
        public async Task OnGetAsync(int? id, int? accion, int? idPuesto)
        {
        
            if (User.IsInRole("Técnico"))
            {
                
                //Aceptar o Denegar Solicitudes
                //Accion 1 acepta
                //Accion 0 deniega (la elimina de la relacion)
                int TecnicoID = await new OperacionesUsuario().IdDeTecnicoConIdApplicationUser(ContextoSingleton.Instance.userManager.GetUserId(User));
                if((accion == 1)&&(idPuesto != null))
                {
                    
                    var Puesto = await _context.Puesto.Where(p=>p.ID==idPuesto).FirstOrDefaultAsync();
                    Puesto.Estado = Puesto.EnumEstadoPuesto.Ocupado;
                    Puesto.TecnicoID=TecnicoID;
                    await _context.SaveChangesAsync();
                }
                else if((accion == 0)&&(idPuesto != null))
                {
                    var Solicitud= await _context.TecnicoSolicitudPuesto.Where(s=>s.TecnicoID==TecnicoID && s.PuestoID==idPuesto).FirstOrDefaultAsync();
                    _context.TecnicoSolicitudPuesto.Remove(Solicitud);
                    await _context.SaveChangesAsync();
                    
                    
                }


                //Listo todos los proyectos del tecnico, incluyo la relacion para traer el nombre del cliente de ApplicationUser
                //Obtengo el id Tecnico usando el Id de logueo (ApplicationUserId)
                int IdTecnico = await new OperacionesUsuario().IdDeTecnicoConIdApplicationUser(ContextoSingleton.Instance.userManager.GetUserId(User));

                //Todos los proyectos con sus puestos, solicitudes de tecnicos y tecnicos
                var ProyectosIgnisGral = await _context.ProyectoIgnis.
                Include(l => l.Puestos).
                ThenInclude(c => c.TecnicosSolicitudesPuesto).
                ThenInclude(a => a.Tecnico).
                ThenInclude(a => a.ApplicationUser).
                ToListAsync();
                ProyectoIgnis = new List<ProyectoIgnis>();
                PuestosProyecto = new List<Puesto>();

                var Especialidades =await _context.Especialidad.ToListAsync();

                foreach(ProyectoIgnis t in ProyectosIgnisGral)
                {
                    if (t.Puestos != null)
                    {
                        foreach (Puesto p in t.Puestos)
                        {
                            
                            
                            if ((p.TecnicosSolicitudesPuesto != null))
                            {
                                foreach (TecnicoSolicitudPuesto s in p.TecnicosSolicitudesPuesto)
                                {
                                    //falta agregar estado
                                    if(s.TecnicoID==IdTecnico)
                                    {
                                        if(p.ProyectoIgnisID==id)
                                        {
                                            PuestosProyecto.Add(p);
                                        }
                                        
                                        p.Especialidad=Especialidades.Where(e=>e.ID==p.EspecialidadID).First();
                                        if(ProyectoIgnis.Find(a=>a.ID == t.ID) == null)
                                        {
                                            ProyectoIgnis.Add(t);
                                        }
                                           
                                    }
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
