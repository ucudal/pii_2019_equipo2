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
//CreateModel tiene los datos que serán provistos al constructor para inicializar instancias de ProyectoIgnis -por lo que CreateModel es un experto conrespecto a crear ProyectoIgnis-.
namespace MercadoIgnis.Pages.ProyectosIgnis
{
    public class CreateModel : PageModel
    {
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
        public ProyectoIgnis ProyectoIgnis { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ProyectoIgnis.Add(ProyectoIgnis);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}