using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MercadoIgnis.Models;
using MercadoIgnis.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

//Patron Expert
//Patron Creator
//CreateModel tiene los datos que serán provistos al constructor para inicializar instancias de ProyectosPersonales -por lo que CreateModel es un experto conrespecto a crear ProyectosPersonales-.
namespace MercadoIgnis.Pages.ProyectosPersonales
{
    [Authorize(Roles = IdentityData.AuthAdminOTecnico)] // Solo los usuarios con rol administrador o tecnico pueden acceder a este controlador
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