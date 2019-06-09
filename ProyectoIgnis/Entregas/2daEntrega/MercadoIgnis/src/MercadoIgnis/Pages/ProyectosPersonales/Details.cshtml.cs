using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MercadoIgnis.Models;
//Patron Expert
//Patron Creator
//DetailsModel tiene los datos que serán provistos al constructor para inicializar instancias de ProyectosPersonales -por lo que DetailsModel es un experto conrespecto a crear ProyectosPersonales-.
namespace MercadoIgnis.Pages.ProyectosPersonales
{
    public class DetailsModel : PageModel
    {
        private readonly MercadoIgnis.Models.MercadoIgnisContext _context;

        public DetailsModel(MercadoIgnis.Models.MercadoIgnisContext context)
        {
            _context = context;
        }

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
    }
}
