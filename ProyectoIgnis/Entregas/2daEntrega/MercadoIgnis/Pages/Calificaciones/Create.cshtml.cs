using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MercadoIgnis.Models;

namespace ProyectoIgnis.Pages.Calificaciones
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
        public Calificacion Calificacion { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Calificacion.Add(Calificacion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}