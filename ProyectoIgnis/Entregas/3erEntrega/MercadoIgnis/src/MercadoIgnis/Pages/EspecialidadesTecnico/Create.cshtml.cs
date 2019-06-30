using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MercadoIgnis.Areas.Identity.Data;
using MercadoIgnis.Models;

namespace MercadoIgnis.Pages.EspecialidadesTecnico
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
        ViewData["EspecialidadID"] = new SelectList(_context.Especialidad,"ID","Area");
        ViewData["TecnicoID"] = new SelectList(_context.Tecnico, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public EspecialidadesTecnicos EspecialidadesTecnicos { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            EspecialidadesTecnicos.TecnicoID=ContextoSingleton.Instance.userManager.GetUserId(User);
            _context.EspecialidadesTecnicos.Add(EspecialidadesTecnicos);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}