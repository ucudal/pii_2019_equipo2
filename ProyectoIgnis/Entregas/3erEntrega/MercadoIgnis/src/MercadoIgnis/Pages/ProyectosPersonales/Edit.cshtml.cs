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

namespace MercadoIgnis.Pages.ProyectosPersonales
{
    public class EditModel : PageModel
    {
        //Edit Model: en esta pagina de Proyectos Personales, edita las mismas
        private readonly MercadoIgnis.Areas.Identity.Data.IdentityContext _context;

        public EditModel(MercadoIgnis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProyectoPersonal ProyectoPersonal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProyectoPersonal = await _context.ProyectoPersonal.FirstOrDefaultAsync(m => m.ID == id);

            if (ProyectoPersonal == null)
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

            _context.Attach(ProyectoPersonal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectoPersonalExists(ProyectoPersonal.ID))
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

        private bool ProyectoPersonalExists(int id)
        {
            return _context.ProyectoPersonal.Any(e => e.ID == id);
        }
    }
}
