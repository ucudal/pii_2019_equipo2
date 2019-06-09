using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Models;
//Patron Expert
//Patron Creator
//DeleteModel tiene los datos que serán provistos al constructor para inicializar instancias de Especialidad -por lo que DeleteModel es un experto conrespecto a crear Especialidad-.
namespace MercadoIgnis.Pages.Especialidades
{
    public class DeleteModel : PageModel
    {
        private readonly MercadoIgnis.Models.MercadoIgnisContext _context;

        public DeleteModel(MercadoIgnis.Models.MercadoIgnisContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Especialidad = await _context.Especialidad.FindAsync(id);

            if (Especialidad != null)
            {
                _context.Especialidad.Remove(Especialidad);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
