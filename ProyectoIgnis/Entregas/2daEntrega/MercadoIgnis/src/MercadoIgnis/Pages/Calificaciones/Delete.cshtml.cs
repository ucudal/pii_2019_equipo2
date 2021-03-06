using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Models;
using MercadoIgnis.Areas.Identity.Data;
//Patron Expert
//Patron Creator
//DeleteModel tiene los datos que serán provistos al constructor para inicializar instancias de Calificacion -por lo que DeleteModel es un experto conrespecto a crear Calificacion-.
namespace MercadoIgnis.Pages.Calificaciones
{
    public class DeleteModel : PageModel
    {
        private readonly IdentityContext _context;

        public DeleteModel(IdentityContext context)
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
