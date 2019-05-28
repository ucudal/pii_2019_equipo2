using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MercadoIgnis.Models;

namespace MercadoIgnis.Pages.ProyectosPersonales
{
    public class CreateModel : PageModel
    {
        private readonly MercadoIgnis.Models.MercadoIgnisContext _context;

        public CreateModel(MercadoIgnis.Models.MercadoIgnisContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ProyectoPersonal ProyectoPersonal { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ProyectoPersonal.Add(ProyectoPersonal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}