using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Models;
using MercadoIgnis.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

//Patron Expert
//Patron Creator
//DeleteModel tiene los datos que serán provistos al constructor para inicializar instancias de Especialidad -por lo que DeleteModel es un experto conrespecto a crear Especialidad-.

namespace MercadoIgnis.Pages.Especialidades
{
    [Authorize(Roles = IdentityData.AdminRoleName)] // Solo los usuarios con rol administrador pueden acceder a este controlador
    public class DeleteModel : PageModel
    {
        private readonly IdentityContext _context;

        public DeleteModel(IdentityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Especialidad Especialidad { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Check.Postcondition(id!=null);
            Especialidad = await _context.Especialidad.FirstOrDefaultAsync(m => m.ID == id);

            if (Especialidad == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Especialidad = await _context.Especialidad.FindAsync(id);

            if (Especialidad != null)
            {
                _context.Especialidad.Remove(Especialidad);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
