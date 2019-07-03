using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Areas.Identity.Data;
using MercadoIgnis.Models;

namespace MercadoIgnis.Pages.TecnicosSugeridosPuesto
{
    public class DeleteModel : PageModel
    {
        private readonly MercadoIgnis.Areas.Identity.Data.IdentityContext _context;

        public DeleteModel(MercadoIgnis.Areas.Identity.Data.IdentityContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TecnicoSugeridoPuesto = await _context.TecnicoSugeridoPuesto.FindAsync(id);

            if (TecnicoSugeridoPuesto != null)
            {
                _context.TecnicoSugeridoPuesto.Remove(TecnicoSugeridoPuesto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
