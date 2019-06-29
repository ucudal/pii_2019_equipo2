using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Models;
using MercadoIgnis.Areas.Identity.Data;


namespace MercadoIgnis.Pages.Puestos
{
    public class IndexModel : PageModel
    {
        private readonly IdentityContext _context;

        public IndexModel(IdentityContext context)
        {
            _context = context;
        }

        public IList<Puesto> Puesto { get;set; }
        public int ProyectoIgnisID {get; set;} 
        public int EspecialidadID {get; set;}
        public async Task OnGetAsync()
        {
            Puesto = await _context.Puesto
                .Include(p => p.Especialidad)
                .Include(p => p.ProyectoIgnis)
                .ToListAsync();
        }
    }
}
