using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Models;

namespace MercadoIgnis.Pages.Calificaciones
{
    public class EditModel : PageModel
    {
        private readonly MercadoIgnis.Models.MercadoIgnisContext _context;

        public EditModel(MercadoIgnis.Models.MercadoIgnisContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Calificacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalificacionExists(Calificacion.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CalificacionExists(int id)
        {
            return _context.Calificacion.Any(e => e.ID == id);
        }
    }
}