using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoIgnis.Models;

namespace ProyectoIgnis.Pages.ProyectosPersonales
{
    public class IndexModel : PageModel
    {
        private readonly ProyectoIgnis.Models.ProyectoIgnisContext _context;

        public IndexModel(ProyectoIgnis.Models.ProyectoIgnisContext context)
        {
            _context = context;
        }

        public IList<ProyectoPersonal> ProyectoPersonal { get;set; }

        public async Task OnGetAsync()
        {
            ProyectoPersonal = await _context.ProyectoPersonal.ToListAsync();
        }
    }
}
