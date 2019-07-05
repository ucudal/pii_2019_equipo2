using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Areas.Identity.Data;
using MercadoIgnis.Models;

namespace MercadoIgnis.Pages.EspecialidadesTecnico
{
    public class DeleteModel : PageModel
    {
        //Delete Model: En esta pagina de Especialidades de los tecnicos, elimina las mismas
        private readonly MercadoIgnis.Areas.Identity.Data.IdentityContext _context;

        public DeleteModel(MercadoIgnis.Areas.Identity.Data.IdentityContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EspecialidadesTecnicos = await _context.EspecialidadesTecnicos.FindAsync(id);

            if (EspecialidadesTecnicos != null)
            {
                _context.EspecialidadesTecnicos.Remove(EspecialidadesTecnicos);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
