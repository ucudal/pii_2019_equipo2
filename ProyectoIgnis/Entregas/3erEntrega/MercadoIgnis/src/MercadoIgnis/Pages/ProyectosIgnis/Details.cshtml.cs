using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Models;
using MercadoIgnis.Areas.Identity.Data;
//Patron Expert
//Patron Creator
//DetailsModel tiene los datos que serán provistos al constructor para inicializar instancias de ProyectoIgnis -por lo que DetailsModel es un experto conrespecto a crear ProyectoIgnis-.
namespace MercadoIgnis.Pages.ProyectosIgnis
{
    public class DetailsModel : PageModel
    {
        private readonly IdentityContext _context;

        public DetailsModel(IdentityContext context)
        {
            _context = context;
        }

        public ProyectoIgnis ProyectoIgnis { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProyectoIgnis = await _context.ProyectoIgnis.FirstOrDefaultAsync(m => m.ID == id);

            if (ProyectoIgnis == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
