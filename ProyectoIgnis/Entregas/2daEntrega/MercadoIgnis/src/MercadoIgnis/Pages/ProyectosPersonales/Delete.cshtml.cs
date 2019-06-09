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
//DeleteModel tiene los datos que serán provistos al constructor para inicializar instancias de ProyectosPersonales -por lo que DeleteModel es un experto conrespecto a crear ProyectosPersonales-.
namespace MercadoIgnis.Pages.ProyectosPersonales
{
    public class DeleteModel : PageModel
    {
        private readonly MercadoIgnis.Models.MercadoIgnisContext _context;

        public DeleteModel(MercadoIgnis.Models.MercadoIgnisContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProyectoPersonal = await _context.ProyectoPersonal.FindAsync(id);

            if (ProyectoPersonal != null)
            {
                _context.ProyectoPersonal.Remove(ProyectoPersonal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
