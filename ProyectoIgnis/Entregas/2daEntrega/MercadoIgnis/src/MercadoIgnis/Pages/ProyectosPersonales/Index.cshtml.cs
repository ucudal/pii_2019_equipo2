using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using MercadoIgnis.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
//Patron Expert
//Patron Creator
//IndexModel tiene los datos que serán provistos al constructor para inicializar instancias de ProyectosPersonales -por lo que IndexModel es un experto conrespecto a crear ProyectosPersonales-.
namespace MercadoIgnis.Pages.ProyectosPersonales
{
    [Authorize(Roles=IdentityData.AuthAdminOTecnico)] // Solo los usuarios con rol administrador o tecnico pueden acceder a este controlador
    public class IndexModel : PageModel
    {
        private readonly MercadoIgnis.Models.MercadoIgnisContext _context;

        public IndexModel(MercadoIgnis.Models.MercadoIgnisContext context)
        {
            _context = context;
        }

        public IList<ProyectoPersonal> ProyectoPersonal { get;set; }
         [BindProperty(SupportsGet = true)]

        public string busquedaPorTipo { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Tipo { get; set; }
        [BindProperty(SupportsGet = true)]
      
        public string FechadeComienzo { get; set; }  
        public async Task OnGetAsync()
        {
            // // Use LINQ to get list of niveles.
            IQueryable<string> TipoQuery = from m in _context.ProyectoPersonal
                                            orderby m.TipoDeProyecto
                                            select m.TipoDeProyecto;
            

            
 
            ProyectoPersonal = await _context.ProyectoPersonal.ToListAsync();

            var ProyectosPersonales = from m in _context.ProyectoPersonal
                 select m;
            
            //Si Recibo algo no nulo del campo de texto
            if (!string.IsNullOrEmpty(busquedaPorTipo))
            {
                ProyectosPersonales = ProyectosPersonales.Where(s => s.TipoDeProyecto.Contains(busquedaPorTipo));
            }
            DateTime date;
            //Si recibo algo no nulo del option box con los niveles
            if (!string.IsNullOrEmpty(FechadeComienzo))
            {
                if (DateTime.TryParse(FechadeComienzo, out date))
                {
                    ProyectosPersonales = ProyectosPersonales.Where(x => x.FechaComienzo >= DateTime.Parse(FechadeComienzo));
                }
                
            }
            Tipo = new SelectList(await TipoQuery.Distinct().ToListAsync());
            ProyectoPersonal = await ProyectosPersonales.ToListAsync();

        }
    }
}
