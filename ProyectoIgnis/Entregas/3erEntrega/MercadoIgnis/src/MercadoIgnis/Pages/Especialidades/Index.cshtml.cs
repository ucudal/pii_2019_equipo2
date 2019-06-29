using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using MercadoIgnis.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

//Patron Expert
//Patron Creator
//IndexModel tiene los datos que serán provistos al constructor para inicializar instancias de Especialidad -por lo que IndexModel es un experto conrespecto a crear Especialidad-.

namespace MercadoIgnis.Pages.Especialidades
{
    [Authorize(Roles=IdentityData.AdminRoleName)] // Solo los usuarios con rol administrador pueden acceder a este controlador
    public class IndexModel : PageModel
    {
        private readonly IdentityContext _context;

        public IndexModel(IdentityContext context)
        {
            _context = context;
        }

        public IList<Especialidad> Especialidad { get;set; }
         [BindProperty(SupportsGet = true)]

        public string busquedaPorTexto { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Niveles { get; set; }
        [BindProperty(SupportsGet = true)]
        public string NivelEspecialidad { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of niveles.
            IQueryable<string> nivelesQuery = from m in _context.Especialidad
                                            orderby m.Nivel
                                            select m.Nivel;

            
 
            Especialidad = await _context.Especialidad.ToListAsync();

            var especialidades = from m in _context.Especialidad
                 select m;
            
            //Si Recibo algo no nulo del campo de texto
            if (!string.IsNullOrEmpty(busquedaPorTexto))
            {
                especialidades = especialidades.Where(s => s.Area.Contains(busquedaPorTexto,StringComparison.CurrentCultureIgnoreCase));
            }

            //Si recibo algo no nulo del option box con los niveles
            if (!string.IsNullOrEmpty(NivelEspecialidad))
            {
                especialidades = especialidades.Where(x => x.Nivel == NivelEspecialidad);
            }
            Niveles = new SelectList(await nivelesQuery.Distinct().ToListAsync());
        }
    }
}
