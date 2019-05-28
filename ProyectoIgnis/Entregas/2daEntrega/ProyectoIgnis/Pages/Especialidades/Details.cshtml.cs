using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Models;

namespace MercadoIgnis.Pages.Especialidades
{
    public class DetailsModel : PageModel
    {
        private readonly MercadoIgnis.Models.MercadoIgnisContext _context;

        public DetailsModel(MercadoIgnis.Models.MercadoIgnisContext context)
        {
            _context = context;
        }

        public Especialidad Especialidad { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Especialidad = await _context.Especialidad.FirstOrDefaultAsync(m => m.ID == id);

            if (Especialidad == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
