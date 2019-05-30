using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Models;

namespace ProyectoIgnis.Pages.Calificaciones
{
    public class DeleteModel : PageModel
    {
        private readonly MercadoIgnis.Models.MercadoIgnisContext _context;

        public DeleteModel(MercadoIgnis.Models.MercadoIgnisContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Calificacion = await _context.Calificacion.FindAsync(id);

            if (Calificacion != null)
            {
                _context.Calificacion.Remove(Calificacion);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
