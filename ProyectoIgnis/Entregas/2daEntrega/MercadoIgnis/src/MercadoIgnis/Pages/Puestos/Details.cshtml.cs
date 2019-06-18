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
    public class DetailsModel : PageModel
    {
        private readonly IdentityContext _context;

        public DetailsModel(IdentityContext context)
        {
            _context = context;
        }

        public Puesto Puesto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Puesto = await _context.Puesto
                .Include(p => p.Especialidad).FirstOrDefaultAsync(m => m.ID == id);

            if (Puesto == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
