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
    public class DeleteModel : PageModel
    {
        private readonly IdentityContext _context;

        public DeleteModel(IdentityContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
           
            Puesto = await _context.Puesto.FindAsync(id);

            if (Puesto != null)
            {
                _context.Puesto.Remove(Puesto);
                await _context.SaveChangesAsync();
            }

           return RedirectToPage("../ProyectosIgnis/Index",new{id=Puesto.ProyectoIgnisID});
        }
    }
}
