using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoIgnis.Models;

namespace ProyectoIgnis.Pages.Especialidades
{
    public class EditModel : PageModel
    {
        private readonly ProyectoIgnis.Models.ProyectoIgnisContext _context;

        public EditModel(ProyectoIgnis.Models.ProyectoIgnisContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Especialidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecialidadExists(Especialidad.ID))
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

        private bool EspecialidadExists(int id)
        {
            return _context.Especialidad.Any(e => e.ID == id);
        }
    }
}
