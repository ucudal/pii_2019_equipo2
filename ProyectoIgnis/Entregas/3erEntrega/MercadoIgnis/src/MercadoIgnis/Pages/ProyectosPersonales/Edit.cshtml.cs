using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Models;
using MercadoIgnis.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
//Patron Expert
//Patron Creator
//EditModel tiene los datos que serán provistos al constructor para inicializar instancias de ProyectosPersonales -por lo que EditModel es un experto conrespecto a crear ProyectosPersonales-.
namespace MercadoIgnis.Pages.ProyectosPersonales
{
    [Authorize(Roles=IdentityData.AuthAdminOTecnico)] // Solo los usuarios con rol administrador o tecnico pueden acceder a este controlador
    public class EditModel : PageModel
    {
        private readonly IdentityContext _context;

        public EditModel(IdentityContext context)
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
