using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MercadoIgnis.Areas.Identity.Data;
using MercadoIgnis.Models;

namespace MercadoIgnis.Pages.TecnicoSolicitudesPuesto
{
    public class CreateModel : PageModel
    {
        private readonly MercadoIgnis.Areas.Identity.Data.IdentityContext _context;

        public CreateModel(MercadoIgnis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PuestoID"] = new SelectList(_context.Puesto, "ID", "ID");
        ViewData["TecnicoID"] = new SelectList(_context.Tecnico, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public TecnicoSolicitudPuesto TecnicoSolicitudPuesto { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TecnicoSolicitudPuesto.Add(TecnicoSolicitudPuesto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}