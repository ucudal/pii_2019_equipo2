using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Areas.Identity.Data;
using MercadoIgnis.Models;

namespace MercadoIgnis.Pages.TecnicosSugeridosPuesto
{
    public class EditModel : PageModel
    {
        private readonly MercadoIgnis.Areas.Identity.Data.IdentityContext _context;

        public EditModel(MercadoIgnis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TecnicoSugeridoPuesto TecnicoSugeridoPuesto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TecnicoSugeridoPuesto = await _context.TecnicoSugeridoPuesto
                .Include(t => t.Puesto)
                .Include(t => t.Tecnico).FirstOrDefaultAsync(m => m.ID == id);

            if (TecnicoSugeridoPuesto == null)
            {
                return NotFound();
            }
           ViewData["PuestoID"] = new SelectList(_context.Puesto, "ID", "ID");
           ViewData["TecnicoID"] = new SelectList(_context.Tecnico, "ID", "ID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TecnicoSugeridoPuesto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TecnicoSugeridoPuestoExists(TecnicoSugeridoPuesto.ID))
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

        private bool TecnicoSugeridoPuestoExists(int id)
        {
            return _context.TecnicoSugeridoPuesto.Any(e => e.ID == id);
        }
    }
}
