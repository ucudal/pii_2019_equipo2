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
//DetailsModel tiene los datos que serán provistos al constructor para inicializar instancias de Calificacion -por lo que DetailsModel es un experto conrespecto a crear Calificacion-.
namespace MercadoIgnis.Pages.Calificaciones
{
    public class DetailsModel : PageModel
    {
        //Details Model: en esta pagina de Calificaciones, ve los detalles las mismas
        private readonly IdentityContext _context;

        public DetailsModel(IdentityContext context)
        {
            _context = context;
        }

        public Calificacion Calificacion { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Check.Precondition(id != null);
            Calificacion = await _context.Calificacion.FirstOrDefaultAsync(m => m.ID == id);
            Check.Postcondition(Calificacion != null);

            if (Calificacion == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
