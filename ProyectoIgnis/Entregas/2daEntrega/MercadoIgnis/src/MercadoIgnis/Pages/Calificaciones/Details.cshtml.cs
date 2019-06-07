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
    public class DetailsModel : PageModel
    {
        private readonly MercadoIgnis.Models.MercadoIgnisContext _context;

        public DetailsModel(MercadoIgnis.Models.MercadoIgnisContext context)
        {
            _context = context;
        }

        public Calificacion Calificacion { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Calificacion = await _context.Calificacion.FirstOrDefaultAsync(m => m.ID == id);

            if (Calificacion == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
