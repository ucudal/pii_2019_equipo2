using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoIgnis.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoIgnis.Pages.Especialidades
{
    public class IndexModel : PageModel
    {
        private readonly ProyectoIgnis.Models.ProyectoIgnisContext _context;

        public IndexModel(ProyectoIgnis.Models.ProyectoIgnisContext context)
        {
            _context = context;
        }
        
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Area { get; set; }
        [BindProperty(SupportsGet = true)]
        public string EspecialidadArea { get; set; }

        public IList<Especialidad> Especialidad { get;set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> AreaQuery = from m in _context.Especialidad
                                    orderby m.Area
                                    select m.Area;
                                    
            var Especialidades = from m in _context.Especialidad
                        select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                Especialidades = Especialidades.Where(s => s.Area.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(EspecialidadArea))
            {
                Especialidades = Especialidades.Where(x => x.Area == EspecialidadArea);
            }
            Area = new SelectList(await AreaQuery.Distinct().ToListAsync());

            Especialidad = await Especialidades.ToListAsync();
        }
    }
}
