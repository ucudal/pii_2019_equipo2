using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Models;

namespace MercadoIgnis.Pages.Calificaciones
{
    public class IndexModel : PageModel
    {
        private readonly MercadoIgnis.Models.MercadoIgnisContext _context;

        public IndexModel(MercadoIgnis.Models.MercadoIgnisContext context)
        {
            _context = context;
        }

        public IList<Calificacion> Calificacion { get;set; }

        public async Task OnGetAsync()
        {
            Calificacion = await _context.Calificacion.ToListAsync();
        }
    }
}
