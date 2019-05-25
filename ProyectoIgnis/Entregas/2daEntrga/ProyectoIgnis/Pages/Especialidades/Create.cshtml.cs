using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoIgnis.Models;

namespace ProyectoIgnis.Pages.Especialidades
{
    public class CreateModel : PageModel
    {
        private readonly ProyectoIgnis.Models.ProyectoIgnisContext _context;

        public CreateModel(ProyectoIgnis.Models.ProyectoIgnisContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Especialidad Especialidad { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Especialidad.Add(Especialidad);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}