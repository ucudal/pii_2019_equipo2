using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MercadoIgnis.Models;
using MercadoIgnis.Areas.Identity.Data;
//Patron Expert
//Patron Creator
//CreateModel tiene los datos que serán provistos al constructor para inicializar instancias de Calificacion -por lo que CreateModel es un experto conrespecto a crear Calificacion-.

namespace MercadoIgnis.Pages.Calificaciones
{
    public class CreateModel : PageModel
    {
        //Create Model: en esta pagina de Calificaciones, crea las mismas
        private readonly IdentityContext _context;

        public CreateModel(IdentityContext context)
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