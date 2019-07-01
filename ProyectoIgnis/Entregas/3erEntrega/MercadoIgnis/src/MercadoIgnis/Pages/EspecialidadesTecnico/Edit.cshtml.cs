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

namespace MercadoIgnis.Pages.EspecialidadesTecnico
{
    public class EditModel : PageModel
    {
        private readonly MercadoIgnis.Areas.Identity.Data.IdentityContext _context;

        public EditModel(MercadoIgnis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EspecialidadesTecnicos EspecialidadesTecnicos { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EspecialidadesTecnicos = await _context.EspecialidadesTecnicos
                .Include(e => e.Especialidad)
                .Include(e => e.Tecnico).FirstOrDefaultAsync(m => m.ID == id);

            if (EspecialidadesTecnicos == null)
            {
                return NotFound();
            }
            ViewData["EspecialidadID"] = new SelectList(_context.Especialidad, "ID", "ID");
            ViewData["TecnicoID"] = new SelectList(_context.Tecnico, "ID", "ID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EspecialidadesTecnicos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecialidadesTecnicosExists(EspecialidadesTecnicos.ID))
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

        private bool EspecialidadesTecnicosExists(int id)
        {
            return _context.EspecialidadesTecnicos.Any(e => e.ID == id);
        }
    }
}
