using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Models;
using MercadoIgnis.Areas.Identity.Data;

namespace MercadoIgnis.Pages.Puestos
{
    public class EditModel : PageModel
    {
        //Edit Model: en esta pagina de Puestos, edita las mismas
        private readonly IdentityContext _context;

        public EditModel(IdentityContext context)
        {
            _context = context;
        }

        [BindProperty]
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
            ViewData["EspecialidadID"] = new SelectList(_context.Especialidad, "ID", "ID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Puesto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuestoExists(Puesto.ID))
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

        private bool PuestoExists(int id)
        {
            return _context.Puesto.Any(e => e.ID == id);
        }
    }
}
