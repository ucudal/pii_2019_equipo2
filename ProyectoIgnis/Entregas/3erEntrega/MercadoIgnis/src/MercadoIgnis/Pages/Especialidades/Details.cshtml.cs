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
//DetailsModel tiene los datos que serán provistos al constructor para inicializar instancias de Especialidad -por lo que DetailsModel es un experto conrespecto a crear Especialidad-.

namespace MercadoIgnis.Pages.Especialidades
{
    [Authorize(Roles=IdentityData.AdminRoleName)] // Solo los usuarios con rol administrador pueden acceder a este controlador
    public class DetailsModel : PageModel
    {
        private readonly IdentityContext _context;

        public DetailsModel(IdentityContext context)
        {
            _context = context;
        }

        public Especialidad Especialidad { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Especialidad = await _context.Especialidad.FirstOrDefaultAsync(m => m.ID == id);
            
            if (Especialidad == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
