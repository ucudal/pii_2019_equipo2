using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MercadoIgnis.Models;
//Patron Expert
//Patron Creator
//CreateModel tiene los datos que serán provistos al constructor para inicializar instancias de Especialidad -por lo que CreateModel es un experto conrespecto a crear Especialidad-.
namespace MercadoIgnis.Pages.Especialidades
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